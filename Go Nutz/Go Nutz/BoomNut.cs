using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Go_Nutz
{
    class BoomNut : GameObject
    {
        #region Feilds
        //when a player places a bomp allow him/her to Phase through it
        private bool phaseAble;
        //Tells other objects that the Boomnut is moveing also usefull for ativator for collision
        private bool inMotion;
        #endregion

        #region Properties
        public bool InMotion
        {
            get { return inMotion; }
            set { inMotion = value; }
        }
        public bool PhaseAble
        {
            get { return phaseAble; }
            set { phaseAble = value; }
        }
        #endregion

        public BoomNut(Vector2 position, string imagePath, float scaleFactor) : base(position, imagePath, scaleFactor)
        {
            phaseAble = true;
            inMotion = false;
        }

        public void Explode()
        {
            GameWorld.Objects.Add(new Explosion(new Vector2(position.X, position.X), "", 1, 1));
            GameWorld.Objects.Remove(this);
        }
        public override void CheckCollision()
        {
            /// <summary>
            /// Check if a GameObject Collides with anohter
            /// </summary>
            foreach (GameObject gameObject in GameWorld.Objects)
            {
                if (gameObject != this)
                {
                    if (this.IsIntersectingWith(gameObject))
                    {
                        OnCollision(gameObject);
                    }
                }
            }
        }
        public void Update()
        {
            //if the Boomnut is moving check collision else don't shuold increase performance
            if (inMotion = true)
            {
                CheckCollision();
            }
        }
        public virtual void OnCollision(GameObject other)
        {
            // if the bomb hits a wall, a NutObejct or a Player stop the bomb and stops the motion of the bomb, then set the bomb at intial collision point
            if (other is Wall || other is NutObject || other is Player)
            {
                //Checks top collision
                if (position.Y + sprite.Height > other.CollisionBox.Top && position.Y + sprite.Height < other.CollisionBox.Top + 10)
                {
                    //the movement of the bomb is set to zero
                    movementVector = new Vector2(0, 0);
                    //the bomb is no longer moving
                    inMotion = false;
                    //sets the bombs position a the egde of the ohter object
                    position.Y = other.CollisionBox.Top - collisionbox.Height;
                }
                //Checks bottom collision
                else if (position.Y > other.CollisionBox.Bottom && position.Y < other.CollisionBox.Bottom - 10)
                {
                    movementVector = new Vector2(0, 0);
                    inMotion = false;
                    position.Y = other.CollisionBox.Bottom;
                }
                //Checks right collision
                else if (collisionbox.Right >= other.CollisionBox.Left && collisionbox.Right <= other.CollisionBox.Left + 20)
                {
                    movementVector = new Vector2(0, 0);
                    inMotion = false;
                    position.X = other.CollisionBox.Left - collisionbox.Width;
                }
                //Checks left collision
                else if (collisionbox.Left >= other.CollisionBox.Right - 20 && collisionbox.Left <= other.CollisionBox.Right)
                {
                    movementVector = new Vector2(0, 0);
                    inMotion = false;
                    position.X = other.CollisionBox.Right;
                }

            }
        }
        public bool IsIntersectingWith(GameObject other)
        {
            return CollisionBox.IntersectsWith(other.CollisionBox);
        }
    }
}
