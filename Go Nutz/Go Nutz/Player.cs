using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Go_Nutz
{
    partial class Player : GameObject
    {
        #region Fields
        int health;
        float speed;
        int maxNuts;
        int kickForce;
        Vector2 kickVector;
        Stack<PowerUp> powerUps;
        List<BoomNut> bombs;
        Keys[] movementKeys;
        #endregion


        public Player(Vector2 position, string imagePath, int health, float speed, int maxNuts, float scaleFactor, Keys[] movementKeys) : base(position, imagePath, scaleFactor)
        {
            this.position = position;
            //string[] imagePaths = imagePath.Split(';');
            this.health = health;
            this.Speed = speed;
            this.maxNuts = maxNuts;
            this.movementKeys = movementKeys;
            kickForce = 5;
        }

        //public float Speed { get => speed; set => speed = value; }
        public float Speed { get { return speed; } set { speed = value; } }
        public int GetHealth()
        {
            return health;
        }

        public int SetHealth(int val)
        {
            health += val;
            return health;
        }

        public void LoseHealth()
        {
            //lose 1 health
            SetHealth(-1);
            //drop nuts


            /* pseudo code:
             * move to home tree
             * be invincible for a short time
             * set sprite as transparent? blinking?
             */
        }

        #region Collision
        public void CheckCollision()
        {
            /// <summary>
            /// Check if a GameObject Collides with anohter
            /// </summary>
            foreach (GameObject gameObject in GameWorld.Objects)
            {
                if (gameObject != this)
                {
                    if (this.IsIntersectingWith(gameObject))
                    {
                        OnCollision(gameObject);
                    }
                }
            }
        }

        public void OnCollision(GameObject other)
        {
            ///<summary>
            ///depending on the other GameObject do something or nothing
            /// </summary>
            if (other is Wall || other is NutObject || other is Player || other is HomeTree)
            {
                //Checks top collision
                if (CollisionBox.Bottom > other.CollisionBox.Top && CollisionBox.Bottom < other.CollisionBox.Top + 30)
                {
                    position.Y = other.CollisionBox.Top - CollisionBox.Height;
                }
                //Checks bottom collision
                else if (CollisionBox.Top > other.CollisionBox.Bottom - 30 && CollisionBox.Top < other.CollisionBox.Bottom )
                {
                    position.Y = other.CollisionBox.Bottom;
                }
                //Checks right collision
                else if (CollisionBox.Right >= other.CollisionBox.Left && CollisionBox.Right <= other.CollisionBox.Left + 20)
                {
                    position.X = other.CollisionBox.Left - CollisionBox.Width;
                }
                //Checks left collision
                else if (CollisionBox.Left >= other.CollisionBox.Right - 20 && CollisionBox.Left <= other.CollisionBox.Right)
                {
                    position.X = other.CollisionBox.Right;
                }
            }
            else if (other is PowerUp) //if the object is powerup.
            {

                GameWorld.Objects.Remove(other);
            }
            else if (other is BoomNut) // if the other is BoomNut.
            {
                HandleBoomNut(other as BoomNut);
            }
        }
        //if two CollisionBoxes are colliding return true else false
        public bool IsIntersectingWith(GameObject other)
        {
            return CollisionBox.IntersectsWith(other.CollisionBox);
        }
        #endregion




        public override void Draw(Graphics dc)
        {
            Font f = new Font("Arial", 16);

            dc.DrawString(string.Format("P1 Score: {0}", Points_p1), f, Brushes.Black, 0, 600);
            dc.DrawString(string.Format("P2 Score: {0}", Points_p2), f, Brushes.Black, 1055, 600);

            base.Draw(dc);
        }

        public override void Update(float fps)
        {
            //Checks the players Collision
            CheckCollision();
            Movement();
            PlayerSpeed();

        }

        public void Kick(GameObject other)
        {
            kickVector = new Vector2((other.Position.X - position.X) * kickForce, (other.Position.Y - position.Y) * kickForce);
            other.MovementVector = kickVector;
            //Test element
            other.MovementVector = new Vector2(5, 0);
        }

        public static void DepositNuts()
        {

            if ((Keyboard.IsKeyDown(Keys.Q)) && Nut.P1Nuts > 0 && Nut.P1Nuts <= 6)
            {

                Points_p1 += 1;


                Nut.P1Nuts--;

            }

            if (Keyboard.IsKeyDown(Keys.U) && Nut.P2Nuts > 0 && Nut.P2Nuts <= 6)
            {

                Points_p2 += 1;


                Nut.P2Nuts--;

            }

        }

        public void Movement()
        {
            ///<summary>
            ///KEY order (LEFT,DOWN,RIGHT,UP,ACTIONKEY1(placeBomb),ACTIONKEY2)
            /// </summary>
            if (Keyboard.IsKeyDown(movementKeys[0]))
            {
                position.X -= Speed;
            }

            if (Keyboard.IsKeyDown(movementKeys[1]))
            {
                position.Y += Speed;
            }

            if (Keyboard.IsKeyDown(movementKeys[2]))
            {
                position.X += Speed;
            }

            if (Keyboard.IsKeyDown(movementKeys[3]))
            {
                position.Y -= Speed;
            }
            if (Keyboard.IsKeyDown(movementKeys[5]))
            {
                bool bombInPlace = false;
                foreach (GameObject item in GameWorld.Objects)
                {
                    if (item is BoomNut)
                    {
                        if (IsIntersectingWith(item))
                        {
                            bombInPlace = true;
                        }
                    }

                }
                if (!bombInPlace)
                {
                    PlaceBomb();
                }

            }
        }
    }
}
