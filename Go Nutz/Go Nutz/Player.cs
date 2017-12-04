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
    class Player : GameObject
    {
        #region Fields
        int health;
        float speed;
        int nutCount;
        int maxNuts;
        int kickForce;
        Vector2 kickVector;
        PlayerScore pointKeeper = new PlayerScore();
        #endregion

        public Player(Vector2 position, string imagePath, int health, float speed, int maxNuts) : base(position, imagePath)
        {
            this.position = position;
            this.health = health;
            this.speed = speed;
            this.maxNuts = maxNuts;
            //string[] imagePaths = imagePath.Split(';');

        }

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
            nutCount = 0;

            /* pseudo code:
             * move to home tree
             * be invincible for a short time
             * set sprite as transparent? blinking?
             */
        }

        // Collision
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
        public override void OnCollision(GameObject other)
        {
            ///<summary>
            ///depending on the other GameObject do something or nothing
            /// </summary>
            if (other is Wall || other is NutObject)
            {
                //Checks top collision
                if (position.Y + sprite.Height > other.CollisionBox.Top && position.Y + sprite.Height < other.CollisionBox.Top + 10)
                {
                    position.Y = other.CollisionBox.Top - collisionbox.Height;
                }
                //Checks bottom collision
                else if (position.Y > other.CollisionBox.Bottom && position.Y < other.CollisionBox.Bottom - 10)
                {
                    position.Y = other.CollisionBox.Bottom;
                }
                //Checks right collision
                else if (collisionbox.Right >= other.CollisionBox.Left && collisionbox.Right <= other.CollisionBox.Left + 20)
                {
                    position.X = other.CollisionBox.Left - collisionbox.Width;
                }
                //Checks left collision
                else if (collisionbox.Left >= other.CollisionBox.Right - 20 && collisionbox.Left <= other.CollisionBox.Right)
                {
                    position.X = other.CollisionBox.Right;
                }
            }
            else if (other is PowerUp)
            {

                GameWorld.Objects.Remove(other);
            }
            else if (other is BoomNut)
            {
                /*
                if(other.inMotion == true)
                {
                    other.MovementVector = new Vector2(0,0);
                    other.inMotion = false;
                }
                */
                Kick(other as BoomNut);
            }
            base.OnCollision(other);
        }
        public override bool IsIntersectingWith(GameObject other)
        {
            return CollisionBox.IntersectsWith(other.CollisionBox);
        }

        public void Update()
        {
            /*
            Keys[] movementKeys = new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.E, Keys.Q };
            if (Keyboard.IsKeyDown(movementKeys[0]))
            {
                this.position.X -= 1;
            }
            */



            
















            //PlaceHolder Code
            /*
            if (bombsPlaced < BombCap)
                {
                    PlaceBomb();
                }
            */
        }

        public void Kick(BoomNut other)
        {
            //the player kicks the bomb in front of him forward based on his direction.
            kickVector = new Vector2((other.Position.X - position.X) * kickForce, (other.Position.Y - position.Y) * kickForce);
            other.MovementVector = kickVector;
        }

        public void DepositNuts()
        {
            pointKeeper.SetPoints(1);
            nutCount--;
        }
        public void PlaceBomb()
        {
            ///<summary>
            ///the player places a bomb at his feet.
            ///as long as have not placed more all his bombs.
            /// </summary>
            //PlaceHolder Code
            /*
            new BoomNut(new Vector2(position.X, position.Y), "Sprite");
            BoombsPlaced++;
            */
        }
    }
}
