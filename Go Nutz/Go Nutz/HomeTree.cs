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
    class HomeTree : GameObject
    {
        private Player player;
        private float scaleFactor;
        private float scaleFactorWidth = 0.2f;
        private bool direction;
        public HomeTree(Vector2 position, string imagePath, float scaleFactor, Player player, bool direction) : base(position,imagePath,scaleFactor)
        {
            this.scaleFactor = scaleFactor;
            this.player = player;
            this.direction = direction;
        }

        public override RectangleF CollisionBox
        {
            get
            {
                if (direction)
                {
                    return new RectangleF(position.X, position.Y, sprite.Width * scaleFactorWidth, sprite.Height * scaleFactor);
                }
                else
                {
                    return new RectangleF(position.X-104, position.Y, sprite.Width * scaleFactorWidth, sprite.Height * scaleFactor);
                }
            }
        }
    }
}
