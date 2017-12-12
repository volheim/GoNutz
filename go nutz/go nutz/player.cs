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
        private Graphics dc;
        int health;
        float speed;
        int maxNuts;
<<<<<<< HEAD

        Image sprite;
        float scaleFactor;

=======
>>>>>>> master
        int kickForce;
        bool canPlaceBomb;
        Vector2 kickVector;
<<<<<<< HEAD

        PlayerScore pointKeeper = new PlayerScore();
        GameObject bomb;
        Keys keyLeft;
        Keys keyDown;
        Keys keyRight;
        Keys keyUp;
        Keys keyPlaceBomb;
        Keys keyDepositeNut;
       
=======
        Keys[] movementKeys;
>>>>>>> master
        #endregion


        public Player(Vector2 position, string imagePath, int health, float speed, int maxNuts, float scaleFactor, Keys[] movementKeys) : base(position, imagePath, scaleFactor)
        {
            //this.position = position;
            //string[] imagePaths = imagePath.Split(';');
            this.health = health;
            this.Speed = speed;
            this.maxNuts = maxNuts;
            this.movementKeys = movementKeys;
        }

        public float Speed { get => speed; set => speed = value; }

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
        public override void CheckCollision()
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
            if (other is Wall || other is NutObject || other is Player)
            {
                //Checks top collision
                if (CollisionBox.Bottom > other.CollisionBox.Top && CollisionBox.Bottom < other.CollisionBox.Top + 30)
                {
                    position.Y = other.CollisionBox.Top - CollisionBox.Height;
                }
                //Checks bottom collision
                else if (CollisionBox.Top > other.CollisionBox.Bottom && CollisionBox.Top < other.CollisionBox.Bottom - 30)
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
<<<<<<< HEAD
#endregion
        public override void Update(float fps)
        {
            Movement();
            PlaceBomb();
            //Draw(dc);
            
=======
        #endregion
>>>>>>> master

        Font f = new Font("Arial", 16);

        

        public override void Draw(Graphics dc)
        {
            dc.DrawString(string.Format("P1 Score: {0}", Points_p1), f, Brushes.Black, 0, 600);
            dc.DrawString(string.Format("P2 Score: {0}", Points_p2), f, Brushes.Black, 1055, 600);

            base.Draw(dc);
        }
<<<<<<< HEAD
=======

        public override void Update(float fps)
        {
            //Checks the players Collision
            CheckCollision();
            Movement();
            PlayerSpeed();
            
        }
>>>>>>> master
        
        public void Kick(GameObject other)
        {
            kickVector = new Vector2((other.Position.X - position.X) * kickForce, (other.Position.Y - position.Y) * kickForce);
            other.MovementVector = kickVector;
            //Test element
            other.MovementVector = new Vector2(5,0);
        }

        public static void DepositNuts()
        {
           
            if ((Keyboard.IsKeyDown(Keys.Q)) && Nut.P1Nuts > 0 && Nut.P1Nuts <= 6)
            {

                Points_p1 += 1;
                

                Nut.P1Nuts--;
                
            }

<<<<<<< HEAD
        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Red), CollisionBox.X, CollisionBox.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
        }

        public void PlaceBomb()
        {
            ///<summary>
            ///the player places a bomb at his feet.
            ///as long as have not placed more all his bombs.
            /// </summary>
            //PlaceHolder Code
            
            if (Keyboard.IsKeyDown(keyPlaceBomb))
            {
                canPlaceBomb = true;
            }

            if (canPlaceBomb)
            {
                bomb = new BoomNut(new Vector2(position.X, position.Y), "Piperlok.png");
                GameWorld.Add_Objects.Add(bomb);
                canPlaceBomb = false;
            }
            
            //BoombsPlaced++;
            
=======
            if (Keyboard.IsKeyDown(Keys.U) && Nut.P2Nuts > 0 && Nut.P2Nuts <= 6)
            {
                
                Points_p2 += 1;
                
>>>>>>> master

                Nut.P2Nuts--;
                
            }
            
        }
        
        public void Movement()
        {
<<<<<<< HEAD
            Bitmap bmp = new Bitmap(sprite);

            //Move left
            if (Keyboard.IsKeyDown(keyLeft))
            {
                position.X -= speed;
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            //Move down
            if (Keyboard.IsKeyDown(keyDown))
=======
            ///<summary>
            ///KEY order (LEFT,DOWN,RIGHT,UP,ACTIONKEY1(placeBomb),ACTIONKEY2)
            /// </summary>
            if (Keyboard.IsKeyDown(movementKeys[0]))
            {
                position.X -= Speed;
            }

            if (Keyboard.IsKeyDown(movementKeys[1]))
>>>>>>> master
            {
                position.Y += Speed;
            }

<<<<<<< HEAD
            //Move right
            if (Keyboard.IsKeyDown(keyRight))
=======
            if (Keyboard.IsKeyDown(movementKeys[2]))
>>>>>>> master
            {
                position.X += Speed;
            }

<<<<<<< HEAD
            // Move up
            if (Keyboard.IsKeyDown(keyUp))
=======
            if (Keyboard.IsKeyDown(movementKeys[3]))
            {
                position.Y -= Speed;
            }
            if (Keyboard.IsKeyDown(movementKeys[4]))
>>>>>>> master
            {
                PlaceBomb();
            }
        }
    }
}
