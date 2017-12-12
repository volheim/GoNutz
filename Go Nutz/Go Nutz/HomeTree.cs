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
        private RectangleF deliverZone;
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
        
        public RectangleF DeliverZone
        {
            get {
                if (direction)
                {
                    return new RectangleF(position.X, position.Y, sprite.Width * scaleFactorWidth, sprite.Height * scaleFactor);
                }
                else
                {
                    return new RectangleF(position.X - 104, position.Y, sprite.Width * scaleFactorWidth, sprite.Height * scaleFactor);
                }
            }
        }
        public override void Draw(Graphics dc)
        {
            dc.DrawRectangle(new Pen(Brushes.Blue), deliverZone.X, deliverZone.Y, deliverZone.Width, deliverZone.Height);
            base.Draw(dc);
        }
        public bool IsIntersectingWith(GameObject other)
        {
            return CollisionBox.IntersectsWith(other.CollisionBox);
        }
        public override void CheckCollision()
        {
            /// <summary>
            /// Check if a GameObject Collides with anohter
            /// </summary>
            foreach (GameObject gameObject in GameWorld.Objects)
            {
                if (gameObject == this)
                {
                    //if (this.IsIntersectingWith(Player))
                    //{
                    //    OnCollision(gameObject);
                    //}
                }
            }
        }
    }
}
