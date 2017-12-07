using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace Go_Nutz
{
    abstract partial class GameObject
    {
        #region Fields
        protected Vector2 position;
        protected Vector2 movementVector;
        protected RectangleF collisionbox;
        protected Image sprite;
        #endregion

        #region Properterties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 MovementVector
        {
            get { return movementVector; }
            set { movementVector = value; }
        }
        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width, sprite.Height);
            }
            set { CollisionBox = value; }
        }
        #endregion

        public GameObject(Vector2 position, string imagePath, float scaleFactor)
        {
            this.position = position;
            sprite = Image.FromFile(imagePath);
            this.scaleFactor = scaleFactor;
        }

        public GameObject()
        {
        }

        public void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width*scaleFactor, sprite.Height*scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Green), CollisionBox.X, CollisionBox.Y, CollisionBox.Width * scaleFactor, CollisionBox.Height * scaleFactor);
        }
        public virtual void Update(float fps)
        {

        }
        public virtual void CheckCollision()
        {
            foreach (GameObject gameObject in GameWorld.Objects)
            {

            }
        }
    }
}
