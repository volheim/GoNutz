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
        private float scaleFactor;
        private float scaleFactorWidth = 0.2f;
        
        public HomeTree(Vector2 position, string imagePath, float scaleFactor, Player player) : base(position,imagePath,scaleFactor)
        {
            this.scaleFactor = scaleFactor;
        }
    #region Collision;
        public override RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width*scaleFactorWidth , sprite.Height*scaleFactor);
            }
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
    #endregion;
}
