using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    struct Explosion
    {
        private int power;
        private int timeLeft;
        private Image sprite;
        public Explosion(Vector2 position, string imagePath, int power, float scaleFactor)
        {
            this.power = power;      
            timeLeft = 16;
            sprite = Image.FromFile(imagePath);
        }
        
        public void Update(float fps)
        {
            if (timeLeft <= 0)
            {
                GameWorld.Removed_Objects.Add(this);
            }
            timeLeft--;
        }
        
    }
}
