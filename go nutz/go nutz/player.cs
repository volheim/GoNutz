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

        float kickForce;
        bool canPlaceBomb;
        Vector2 kickVector;

        GameObject bomb;
        int nutCount;

        Stack<PowerUp> powerUps;
        List<BoomNut> bombs;
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


            kickForce = 0.2f;
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
            if (other is Wall || other is NutObject || other is Player)
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
            else if (other is Nut)
            {
                GameWorld.Removed_Objects.Add(other);
                
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
            kickVector = new Vector2((other.Position.X - Position.X) * kickForce, (other.Position.Y - Position.Y) * kickForce);
            other.MovementVector = kickVector;
            //Test element
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

            //Makes the player face the right direction
            Turn();
        }

        ///<summary>
        ///Makes player turn corresponding to the key pressed
        /// </summary>
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

        ///<summary>
        ///Makes player face left
        /// </summary>
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

        ///<summary>
        ///Makes player face down
        /// </summary>
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

        ///<summary>
        ///Makes player face right
        /// </summary>
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

        ///<summary>
        ///Makes player face up
        /// </summary>
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