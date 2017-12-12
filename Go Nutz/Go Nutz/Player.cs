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
        private Graphics dc;
        int health;
        float speed;
        int nutCount;
        int maxNuts;

        Image sprite;
        float scaleFactor;

        int kickForce;
        bool canPlaceBomb;
        Vector2 kickVector;

        PlayerScore pointKeeper = new PlayerScore();
        GameObject bomb;
        Keys keyLeft;
        Keys keyDown;
        Keys keyRight;
        Keys keyUp;
        Keys keyPlaceBomb;
        Keys keyDepositeNut;
       
        #endregion



        public Player(Vector2 position, string imagePath, int health, float speed, int maxNuts, Keys keyLeft, Keys keyDown, Keys keyRight, Keys keyUp, Keys keyPlaceBomb, Keys keyDepositeNut) : base(position, imagePath)
        {
            //this.position = position;
            //string[] imagePaths = imagePath.Split(';');
            this.health = health;
            this.speed = speed;
            this.maxNuts = maxNuts;
            this.keyLeft = keyLeft;
            this.keyDown = keyDown;
            this.keyRight = keyRight;
            this.keyUp = keyUp;
            this.keyPlaceBomb = keyPlaceBomb;
            this.keyDepositeNut = keyDepositeNut;
            
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
#endregion
        public override void Update(float fps)
        {
            Movement();
            PlaceBomb();
            //Draw(dc);
            



            //PlaceHolder Code
            /*
            if (bombsPlaced < BombCap)
                {
                    PlaceBomb();
                }
            */
        }
        
        public void Kick(GameObject other)
        {
            kickVector = new Vector2((other.Position.X - position.X) * kickForce, (other.Position.Y - position.Y) * kickForce);
            other.MovementVector = kickVector;
        }

        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
            set { CollisionBox = value; }
        }

        public void DepositNuts()
        {
            pointKeeper.SetPoints(1);
            nutCount--;
        }


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
            

        }
        public void Movement()
        {
            Bitmap bmp = new Bitmap(sprite);

            //Move left
            if (Keyboard.IsKeyDown(keyLeft))
            {
                position.X -= speed;
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            //Move down
            if (Keyboard.IsKeyDown(keyDown))
            {
                position.Y += speed;
            }

            //Move right
            if (Keyboard.IsKeyDown(keyRight))
            {
                position.X += speed;
            }

            // Move up
            if (Keyboard.IsKeyDown(keyUp))
            {
                position.Y -= speed;
            }
        }
    }
}
