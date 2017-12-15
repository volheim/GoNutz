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

        Image sprite;
        float scaleFactor;

        int kickForce;
        bool canPlaceBomb;
        Vector2 kickVector;
        
        GameObject bomb;
        Keys[] movementKeys;

        private string lastKeyPressed = "right";
        private string facing = "right";

        #endregion

        public Player(Vector2 position, string imagePath, int health, float speed, int maxNuts, float scaleFactor, Keys[] movementKeys) : base(position, imagePath, scaleFactor)
        {
            //this.position = position;
            //string[] imagePaths = imagePath.Split(';');
            this.health = health;
            this.Speed = speed;
            this.maxNuts = maxNuts;
            this.movementKeys = movementKeys;

            string[] Imagepaths = imagePath.Split(';');

            this.animationFrames = new List<Bitmap>();

            foreach (string path in Imagepaths)
            {
                Image img = Image.FromFile(path);
                Bitmap frame = new Bitmap(img);
                animationFrames.Add(frame);
            }

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
            Movement();
            CheckCollision();
            Turn();
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
        }
            
       
        ///<summary>
        ///KEY order (LEFT,DOWN,RIGHT,UP,ACTIONKEY1(placeBomb),ACTIONKEY2)
        /// </summary>
        public void Movement()
        {
            if (Keyboard.IsKeyDown(movementKeys[0]))
            {
                position.X -= Speed;
                lastKeyPressed = "left";
            }

            if (Keyboard.IsKeyDown(movementKeys[1]))
            {
                position.Y += Speed;
                lastKeyPressed = "down";
            }

            //Move right
            if (Keyboard.IsKeyDown(movementKeys[2]))
            {
                position.X += Speed;
                lastKeyPressed = "right";
            }

            // Move up
            if (Keyboard.IsKeyDown(movementKeys[3]))
            {
                position.Y -= Speed;
                lastKeyPressed = "up";
            }

            if (Keyboard.IsKeyDown(movementKeys[4]))
            {
                PlaceBomb();
            }
        }

        public void Turn()
        {
            if (lastKeyPressed == "left" && facing != "left")
            {
                TurnLeft();
            }

            if (lastKeyPressed == "down" && facing != "down")
            {
                TurnDown();
            }

            if (lastKeyPressed == "right" && facing != "right")
            {
                TurnRight();
            }

            if (lastKeyPressed == "up" && facing != "up")
            {
                TurnUp();
            }
        }
        

        public void TurnLeft()
        {
            switch (facing)
            {
                case "left":                    
                    break;

                case "down":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    break;

                case "right":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    }
                    break;

                case "up":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    break;

            }

            facing = "left";
        }

        public void TurnDown()
        {
            switch (facing)
            {
                case "left":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    break;

                case "down":
                    break;

                case "right":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    break;
                    
                case "up":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    }
                    break;
            }

            facing = "down";
        }
        
        public void TurnRight()
        {
            switch (facing)
            {
                case "left":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    }
                    break;

                case "down":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    break;

                case "right":
                    break;

                case "up":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    break;

            }

            facing = "right";
        }

        public void TurnUp()
        {
            switch (facing)
            {
                case "left":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    break;

                case "down":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    }
                    break;

                case "right":
                    foreach (Image img in animationFrames)
                    {
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    break;
                    
                case "up":
                    break;
            }

            facing = "up";
        }
    }
}