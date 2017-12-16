using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    class Explosion
    {
        private Vector2 position;
        private int power;
        private int timeLeft = 10;
        private Image sprite;
        float scaleFactor;
        public Explosion(Vector2 position, string imagePath, int power, float scaleFactor)
        {
            this.power = power;      
            this.timeLeft = 16;
            sprite = Image.FromFile(imagePath);
            this.position = position;
            this.scaleFactor = scaleFactor;
        }
        
        public void Update(float fps)
        {
            timeLeft--;
            if (timeLeft <= 0)
            {
                GameWorld.Remove_Explosions_List.Add(this);
            }

        }
        public void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
        }
        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
        }
        
    }
}
