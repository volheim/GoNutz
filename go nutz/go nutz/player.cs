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
        int nutCount;
        int maxNuts;
        int kickForce;
        Vector2 kickVector;
        PlayerScore pointKeeper = new PlayerScore();
        Keys[] movementKeys;
        #endregion


        public Player(Vector2 position, string imagePath, int health, float speed, int maxNuts, float scaleFactor, Keys[] movementKeys) : base(position, imagePath, scaleFactor)
        {
            this.position = position;
            //string[] imagePaths = imagePath.Split(';');
            this.health = health;
            this.speed = speed;
            this.maxNuts = maxNuts;
            this.movementKeys = movementKeys;
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
                HandleBoomNut(other as BoomNut);
            }
        }
        public bool IsIntersectingWith(GameObject other)
        {
            return CollisionBox.IntersectsWith(other.CollisionBox);
        }
        #endregion

        public override void Update(float fps)
        {
            CheckCollision();
            Movement();
        }

        public void Kick(GameObject other)
        {
            kickVector = new Vector2((other.Position.X - position.X) * kickForce, (other.Position.Y - position.Y) * kickForce);
            other.MovementVector = kickVector;
        }

        public void DepositNuts()
        {
            pointKeeper.SetPoints(1);
            nutCount--;
        }
        public void Movement()
        {
            if (Keyboard.IsKeyDown(movementKeys[0]))
            {
                position.X -= speed;
            }

            if (Keyboard.IsKeyDown(movementKeys[1]))
            {
                position.Y += speed;
            }

            if (Keyboard.IsKeyDown(movementKeys[2]))
            {
                position.X += speed;
            }

            if (Keyboard.IsKeyDown(movementKeys[3]))
            {
                position.Y -= speed;
            }
        }
    }
}
