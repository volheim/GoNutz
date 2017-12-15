using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Go_Nutz
{
    partial class BoomNut
    {
        public void CalculateExplosionRadius(int power)
        {
            float baseX = position.X;
            float baseY = position.Y;
            for (int i = 0; i < power; i++)
            {
                bool objectHit = false;
                RectangleF currentsqaure = new RectangleF(baseX + sprite.Width, baseY, sprite.Width, sprite.Height);
                baseX = currentsqaure.X;
                foreach (GameObject Object in GameWorld.Objects)
                {
                    if (Object != this || Object is Player || Object is BoomNut)
                    {
                        if (IsIntersectingWith(currentsqaure, Object))
                        {
                            objectHit = true;
                            break;
                        }
                    }
                    else if (Object is Player)
                    {
                        // calls player to lose health
                    }
                    else if (Object is BoomNut)
                    {
                        //calls the boomnut to explode
                    }
                }
                // the explosion hit another Object(wall or Nutobject)
                if (objectHit)
                {
                    break;
                }
                else
                {
                    //add Tile to explosion
                }

            }
        }
        public bool IsIntersectingWith(RectangleF sqaure, GameObject other)
        {
            return sqaure.IntersectsWith(other.CollisionBox);
        }
    }
}
