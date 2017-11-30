using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Go_Nutz
{
    class BoomNut : Nut
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
        #endregion

        public BoomNut(Vector2 position, string imagePath) : base(position, imagePath)
        {
            phaseAble = true;
            inMotion = false;
        }

        public void Explode()
        {

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
        public virtual void OnCollision(GameObject other)
        {

        }
        public virtual bool IsIntersectingWith(GameObject other)
        {

            return CollisionBox.IntersectsWith(other.CollisionBox);
        }
    }
}
