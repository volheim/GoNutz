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
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public Explosion(Vector2 position, string imagePath, int power, float scaleFactor) : base(position, imagePath, scaleFactor)
        {
            this.power = power;
        }
        public void Expand()
        {

        }
        public void BlowPower()
        {

        }
    }
}
