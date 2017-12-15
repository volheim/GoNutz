using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    partial class BoomNut
    {
        Image explsionSprite = Image.FromFile(@"Images\blood\Splat01.png");
        public void CalculateExplosionRadius(int power)
        {
            CalculateLeft(power);
            CalculateRight(power);
            CalculateUp(power);
            CaculateDown(power);
        }
        #region Calc Right
        void CalculateRight(int power)
        {
            float baseX = Position.X;
            float baseY = Position.Y;
            for (int i = 0; i < power; i++)
            {
                RectangleF currentsquare = new RectangleF(baseX + explsionSprite.Width, baseY, explsionSprite.Width, explsionSprite.Height);
                ;
                // the explosion hit another Object(wall or Nutobject)
                if (Checkspace(currentsquare))
                {
                    continue;
                }
                else
                {
                    GameWorld.Add_Explosions_List.Add(new Explosion(new Vector2(baseX, baseY), @"Images\blood\Splat01.png", power, 1f));
                    //add Tile to explosion
                }
                baseX = currentsquare.X;
            }
        }
        #endregion
        #region Calc Left
        void CalculateLeft(int power)
        {
            float baseX = position.X;
            float baseY = position.Y;
            
            for (int i = 0; i < power; i++)
            {
        
                RectangleF currentsquare = new RectangleF(baseX - explsionSprite.Width, baseY, explsionSprite.Width, explsionSprite.Height);
                // the explosion hit another Object(wall or Nutobject)
                if (Checkspace(currentsquare))
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Explosions_List.Add(new Explosion(new Vector2(baseX, baseY), @"Images\blood\Splat01.png", power, 1f));
                    //add Tile to explosion
                }
                baseX = currentsquare.X;
            }
        }
        #endregion
        #region Calc Up
        void CalculateUp(int power)
        {
            float baseX = position.X;
            float baseY = position.Y;
            for (int i = 0; i < power; i++)
            {
                RectangleF currentsquare = new RectangleF(baseX, baseY - explsionSprite.Height, explsionSprite.Width, explsionSprite.Height);
               
                // the explosion hit another Object(wall or Nutobject)
                if (Checkspace(currentsquare))
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Explosions_List.Add(new Explosion(new Vector2(baseX, baseY), @"Images\blood\Splat01.png", power, 1f));
                    //add Tile to explosion
                }
                baseY = currentsquare.Y;
            }
        }
        #endregion
        #region CalcDown
        void CaculateDown(int power)
        {
            float baseX = position.X;
            float baseY = position.Y;
            for (int i = 0; i < power; i++)
            {
                bool objectHit = false;
                RectangleF currentsquare = new RectangleF(baseX, baseY + explsionSprite.Height, explsionSprite.Width, explsionSprite.Height);

                
                // the explosion hit another Object(wall or Nutobject)
                if (Checkspace(currentsquare))
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Explosions_List.Add(new Explosion(new Vector2(baseX, baseY), @"Images\blood\Splat01.png", power, 1f));
                    //add Tile to explosion
                }
                baseY = currentsquare.Y;
            }
        }
        #endregion
        public void ExplosionVsPlayer(Player player)
        {
            player.LoseHealth();
        }
        public void ExplosionVsBoomNut(BoomNut boomNut)
        {
            boomNut.Explode();
        }
        public bool IsIntersectingWith(RectangleF sqaure, GameObject other)
        {
            return sqaure.IntersectsWith(other.CollisionBox);
        }
        public bool Checkspace(RectangleF currentsquare)
        {
            ///<summary>
            ///check if the space where the explosion could appear is free of walls
            ///plus it calls ohter objects to do something if they are hit
            /// </summary>
            bool objectHit = false;
            foreach (GameObject Object in GameWorld.Objects)
            {
                if (Object != this)
                {
                    if (IsIntersectingWith(currentsquare, Object))
                    {
                        if (Object is Wall || Object is HomeTree)
                        {
                            objectHit = true;
                            break;
                        }
                        else if (Object is Player)
                        {
                            // calls player to lose health
                            ExplosionVsPlayer(Object as Player);
                            break;

                        }
                        else if (Object is BoomNut)
                        {
                            ExplosionVsBoomNut(Object as BoomNut);
                            break;
                            //calls the boomnut to explode
                        }
                        else if (Object is NutObject)
                        {
                            objectHit = true;
                            break;
                        }
                    }
                }
            }
            return objectHit;
        }
    }
}
