using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    class Wall : GameObject
    {

        float scaleFactor;
        Image sprite;
        Vector2 position;

        public Wall(Vector2 position, string imagePath, float scaleFactor) : base(position, imagePath)
        {


            this.position = position;

            this.scaleFactor = scaleFactor;
        }

        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
            set { CollisionBox = value; }
        }
    }
}
