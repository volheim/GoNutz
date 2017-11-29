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

        public override void CheckCollision()
        {

        }

        public void Update()
        {
            Keys[] movementKeys = new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.E, Keys.Q };
            if (Keyboard.IsKeyDown(movementKeys[0]))
            {

            }
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
    }
}
