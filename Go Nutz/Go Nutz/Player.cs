using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    class Player
    {
        int health;
        float speed;
        int nutCount;
        int maxNuts;

        Image sprite;
        Vector2 position;

        int kickForce;
        Vector2 kickVector;




        PlayerScore pointKeeper = new PlayerScore();

        public Player(Vector2 position, Image sprite, int health, float speed, int maxNuts)
        {
            this.position = position;
            this.sprite = sprite;
            this.health = health;
            this.speed = speed;
            this.maxNuts = maxNuts;
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

        public void CheckCollision()
        {

        }

        public void Update()
        {

        }

        public void Kick(GameObject other)
        {
            kickVector = new Vector2((other.position.X - position.X) * kickForce, (other.position.Y - position.Y) * kickForce); 
            other.movementVector = kickVector;
        }

        public void DepositNuts()
        {
            pointKeeper.SetPoints(1);
            nutCount--;
        }
    }
}
