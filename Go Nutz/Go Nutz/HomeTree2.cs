using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace Go_Nutz
{
    class HomeTree2 : GameObject
    {
        //Jeg var nød til at lave en HomeTree2 for at lave Collision til den
        private float scaleFactor;
        private float scaleFactorWidth = 0.2f;

        public HomeTree2(Vector2 position, string imagePath, float scaleFactor, Player player) : base(position, imagePath, scaleFactor)
        {
            this.scaleFactor = scaleFactor;
        }

        public override RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X-104, position.Y, sprite.Width * scaleFactorWidth, sprite.Height * scaleFactor);
            }
        }
    }
}
