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
        private Vector2 position;
        private int power;
        private int timeLeft;
        private Image sprite;
        float scaleFactor;
        public Explosion(Vector2 position, string imagePath, int power, float scaleFactor)
        {
            this.power = power;      
            timeLeft = 16;
            sprite = Image.FromFile(imagePath);
            this.position = position;
            this.scaleFactor = scaleFactor;
        }
        
        public void Update(float fps)
        {
            if (timeLeft <= 0)
            {
                GameWorld.Remove_Explosions_List.Add(this);
            }
            timeLeft--;
        }
        public void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
        }
        
    }
}
