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
    class HomeTree
    {
        Vector2 position;
        Image sprite;
        int playerIdentifier;
        float scaleFactor;

        public RectangleF treeCollsisionBox;

        public HomeTree(Vector2 position, Image sprite, int playerIdent, float collisionWidth, float collisionHeight)
        {
            this.position = position;
            this.sprite = sprite;
            this.playerIdentifier = playerIdent;
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
