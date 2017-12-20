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
        protected List<Bitmap> animationFrames;

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
        public virtual RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
        }
        public Image Sprite
        {
            get { return sprite; }
        }
        #endregion

        public GameObject(Vector2 position, string imagePath, float scaleFactor)
        {
            this.position = position;
            this.scaleFactor = scaleFactor;
            string[] Imagepaths = imagePath.Split(';');

            this.animationFrames = new List<Bitmap>();

            foreach (string path in Imagepaths)
            {
                Image img = Image.FromFile(path);
                Bitmap frame = new Bitmap(img);
                animationFrames.Add(frame);
            }

            this.sprite = this.animationFrames[0];
        }

        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width*scaleFactor, sprite.Height*scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Green), CollisionBox.X, CollisionBox.Y, CollisionBox.Width, CollisionBox.Height);
            

        }

        public virtual void Update(float fps)
        {
          
        }
    }
}
