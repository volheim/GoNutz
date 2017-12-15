using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    class Explosion : GameObject
    {
        private int power;
        private Image sprite;
        private int timeLeft;
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public Explosion(Vector2 position, string imagePath, int power, float scaleFactor) : base(position, imagePath, scaleFactor)
        {
            this.power = power;
            timeLeft = 16;
        }
        public override void Update(float fps)
        {
            if (timeLeft <= 0)
            {
                GameWorld.Removed_Objects.Add(this);
            }
            timeLeft--;
        }
    }
}
