using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Go_Nutz
{
    partial class BoomNut : GameObject
    {
        #region Feilds
        //when a player places a bomp allow him/her to Phase through it
        private bool phaseAble;
        //Tells other objects that the Boomnut is moveing also usefull for ativator for collision
        private bool inMotion;
        int timeLeft;
        Player player;
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
            phaseAble = false;
            inMotion = false;
            this.player = player;
            timeLeft = 0;
        }
        public override void Update(float fps)
        {
            if (timeLeft > 24*5)
            {
                Explode();
            }
            timeLeft++;
            if (inMotion)
            {
                //
                position += movementVector;
                //if the Boomnut is moving check collision else don't. :: should increase performance
                if (inMotion)
                {
                    CheckCollision();
                }
            }
            base.Update(fps);
        }
        public void Explode()
        {
            CalculateExplosionRadius(2);
            //GameWorld.Objects.Add(new Explosion(new Vector2(position.X, position.X), "", 1, 1));
            GameWorld.Removed_Objects.Add(this);
        }
        public void CheckCollision()
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

        public void OnCollision(GameObject other)
        {
            // if the bomb hits a wall, a NutObejct or a Player stop the bomb and stops the motion of the bomb, then set the bomb at intial collision point
            if (other is Wall || other is NutObject || other is HomeTree)
            {
                /*
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
                */
                if (CollisionBox.Bottom > other.CollisionBox.Top && CollisionBox.Bottom < other.CollisionBox.Top + 30)
                {
                    InMotion = false;
                    movementVector = new Vector2(0, 0);
                    position.Y = other.CollisionBox.Top - CollisionBox.Height;
                }
                //Checks bottom collision
                else if (CollisionBox.Top > other.CollisionBox.Bottom - 30 && CollisionBox.Top < other.CollisionBox.Bottom)
                {
                    InMotion = false;
                    movementVector = new Vector2(0, 0);
                    position.Y = other.CollisionBox.Bottom;
                }
                //Checks right collision
                else if (CollisionBox.Right >= other.CollisionBox.Left && CollisionBox.Right <= other.CollisionBox.Left + 20)
                {
                    InMotion = false;
                    movementVector = new Vector2(0, 0);
                    position.X = other.CollisionBox.Left - CollisionBox.Width;
                }
                //Checks left collision
                else if (CollisionBox.Left >= other.CollisionBox.Right - 20 && CollisionBox.Left <= other.CollisionBox.Right)
                {
                    InMotion = false;
                    movementVector = new Vector2(0, 0);
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
