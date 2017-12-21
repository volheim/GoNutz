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
        byte counter = 0;
        bool playerRespawned = false;

        Image sprite;
        float scaleFactor;
        int DepositCd;
        int nutCount;
        int boomNutCount;
        float kickForce;
        bool canPlaceBomb;
        Vector2 kickVector;
        Vector2 startPosition;
        GameObject bomb;
        Stack<PowerUp> powerUps;
        Keys[] movementKeys;
        private string lastKeyPressed = "right";
        private string facing = "right";
        
        #endregion
        #region Properties
        public int BombNutCount
        {
            get { return boomNutCount; }
            set { boomNutCount = value; }

        }
        public int NutCount
        {
            get { return nutCount; }
            set { nutCount = value; }
        }
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        #endregion

        public Player(Vector2 position, string imagePath, int health, float speed, int maxNuts, float scaleFactor, Keys[] movementKeys) : base(position, imagePath, scaleFactor)
        {
            //this.position = position;
            //string[] imagePaths = imagePath.Split(';');
            this.health = health;
            this.Speed = speed;
            this.maxNuts = maxNuts;
            this.movementKeys = movementKeys;
            this.startPosition = position;
            string[] Imagepaths = imagePath.Split(';');
            this.animationFrames = new List<Bitmap>();
            foreach (string path in Imagepaths)
            {
                Image img = Image.FromFile(path);
                Bitmap frame = new Bitmap(img);
                animationFrames.Add(frame);
            }


            kickForce = 0.2f;
            nutCount = 3;
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
        public void RespawnPlayer()
        {
            Position = startPosition;
            health++;
        }
        public void DropNuts()
        {
            for (int i = 0; i < nutCount; i++)
            {
                GameWorld.Objects.Add(new Nut(this.position, @"Images/acornDrawn.png", 0.45f));
            }
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
            if (other is Wall || other is NutObject || other is Player || other is BorderWall || other is HomeTree)
            {
                //Checks top collision
                if (CollisionBox.Bottom > other.CollisionBox.Top && CollisionBox.Bottom < other.CollisionBox.Top + 30)
                {
                    position.Y = other.CollisionBox.Top - CollisionBox.Height;
                }
                //Checks bottom collision
                else if (CollisionBox.Top > other.CollisionBox.Bottom - 30 && CollisionBox.Top < other.CollisionBox.Bottom)
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
                powerUps.Push(new PowerUp(new Vector2(position.X, position.Y), "", 0.1f));
                GameWorld.Objects.Remove(other);
            }
            else if (other is BoomNut) // if the other is BoomNut.
            {
                HandleBoomNut(other as BoomNut);
            }
            else if (other is Nut)// if the other is Nut
            {
                //remove the nut from the worlda and add a nut to the players nutcount
                GameWorld.Removed_Objects.Add(other);
                nutCount++;
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

            //dc.DrawString(string.Format("P1 Score: {0}", Points_p1), f, Brushes.Black, 0, 600);
            //dc.DrawString(string.Format("P2 Score: {0}", Points_p2), f, Brushes.Black, 1055, 600);

            base.Draw(dc);
        }


        public override void Update(float fps)
        {
   
            if (nutCount != 0)
            {
                maxNuts = nutCount;
            }
            else
            {
                maxNuts = 1;
            }
            //Checks the players Collision
            Movement();
            //lower the deposit nut cooldown
            if (DepositCd > 0)
            {
                DepositCd--;
            }
            DepositNuts();
            CheckCollision();
            Turn();
            PlayerSpeed();

            if (health <= 0)
            {
                //Die();
                RespawnPlayer();
            }
            
            //if (Die())
            //{
            //    if (counter == 4)
            //    {
            //        RespawnPlayer();
            //        playerRespawned = true;
            //    }
            //    counter++;
            //}

            //if (playerRespawned)
            //{
            //    counter = 0;
            //    playerRespawned = false;
            //}
        }

        public void Kick(GameObject other)
        {
            kickVector = new Vector2((other.Position.X - Position.X) * kickForce, (other.Position.Y - Position.Y) * kickForce);
            other.MovementVector = kickVector;
        }

        #region Deposit Nuts
        /*
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
*/
        public void DepositNuts()
        {
            if ((Keyboard.IsKeyDown(movementKeys[4])) && nutCount > 0 && isHomeTree())
            {
                if (DepositCd <= 0)
                {
                    playerPoints++;
                    nutCount--;
                    DepositCd = 12;
                }
            }
        }
        public bool isHomeTree()
        {
            foreach (HomeTree home in GameWorld.Hometrees)
            {

                if (this.CollisionBox.IntersectsWith(home.DeliverZone))
                {
                    if (home.ValidatePlayer(this))
                    {
                        return true;
                    }
                }


            }
            return false;
        }
        #endregion
        #region Movement
        public void Movement()
        {
            ///<summary>
            ///if a player presses curtain keys let the player move a round the map
            ///KEY order (LEFT,DOWN,RIGHT,UP,ACTIONKEY1(DeliverNuts),ACTIONKEY2(PlaceBomb))
            /// </summary>
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
                //check if there is a bomb underneath the player
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

                if (!bombInPlace && BombNutCount < maxNuts)
                {
                    PlaceBomb();
                }

            }

            //Makes the player face the right direction
            Turn();
        }
        #endregion
        #region Turn
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
        #endregion
        
        public bool Die()
        {
            if (health <= 0)
            {

                //string ImagePath = @"Images\blood\Splat01.png;Images\blood\Splat02.png;Images\blood\Splat03.png;Images\blood\Splat04.png";
                //string[] ImagePaths = ImagePath.Split(';');

                //this.animationFrames = new List<Bitmap>();
                //foreach (var item in animationFrames)
                //{
                //    animationFrames.Remove(item);
                //}

                //foreach (string path in ImagePaths)
                //{
                //    Image img = Image.FromFile(path);
                //    Bitmap frame = new Bitmap(img);
                //    animationFrames.Add(frame);
                //}

                return true;
            }
            return false;
        }
    }
}