using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace Go_Nutz
{
    class BorderWall : GameObject
    {
        /*public RectangleF colisionBoxTop
        {
            set { new RectangleF(0, 0, 1275, -10); }
        }
        public RectangleF colisionBoxBot
        {
            set { new RectangleF(0, 760, 1275, 10); }
        }
        public RectangleF colisionBoxLeft
        {
            set { new RectangleF(0, 0, -10, 760); }
        }
        public RectangleF colisionBoxRight
        {
            set { new RectangleF(1275, 0, 10, 760); }
        }*/

        public BorderWall(Vector2 position, string imagePath, float scaleFactor) : base(position, imagePath, scaleFactor)
        {
            
        }
    }
}
