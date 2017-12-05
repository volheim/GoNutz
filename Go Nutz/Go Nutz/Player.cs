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
        Keys keyLeft;
        Keys keyDown;
        Keys keyRight;
        Keys keyUp;
        Keys keyPlaceBomb;
        Keys keyDepositeNut;
        #endregion


        public Player(Vector2 position, string imagePath, int health, float speed, int maxNuts, Keys keyLeft, Keys keyDown, Keys keyRight, Keys keyUp, Keys keyPlaceBomb, Keys keyDepositeNut) : base(position, imagePath)
        {
            this.position = position;
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

        public override void CheckCollision()
        {

        }

        public override void Update(float fps)
        {
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
            if (Keyboard.IsKeyDown(keyLeft))
            {
                position.X -= speed;
            }

            if (Keyboard.IsKeyDown(keyDown))
            {
                position.Y += speed;
            }

            if (Keyboard.IsKeyDown(keyRight))
            {
                position.X += speed;
            }

            if (Keyboard.IsKeyDown(keyUp))
            {
                position.Y -= speed;
            }
        }
    }
}
