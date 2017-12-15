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
            Image explsionSprite = Image.FromFile(@"Images\blood\Splat01.png");
            for (int i = 0; i < power; i++)
            {
                bool objectHit = false;
                RectangleF currentsqaure = new RectangleF(baseX + explsionSprite.Width, baseY, explsionSprite.Width, explsionSprite.Height);

                foreach (GameObject Object in GameWorld.Objects)
                {
                    if (Object != this)
                    {
                        if (IsIntersectingWith(currentsqaure, Object))
                        {
                            if (Object is Wall || Object is NutObject || Object is HomeTree)
                            {
                                objectHit = true;
                                break;
                            }
                            else if (Object is Player)
                            {
                                // calls player to lose health
                                ExplosionVsPlayer(Object as Player);

                            }
                            else if (Object is BoomNut)
                            {
                                ExplosionVsBoomNut(Object as BoomNut);
                                //calls the boomnut to explode
                            }
                        }
                    }

                }
                // the explosion hit another Object(wall or Nutobject)
                if (objectHit)
                {
                    continue;
                }
                else
                {
                    GameWorld.Add_Objects.Add(new Explosion(new Vector2(baseX, baseY), @"Images\blood\Splat01.png", power, 1f));
                    //add Tile to explosion
                }
                baseX = currentsqaure.X;
            }
        }
        #endregion
        #region Calc Left
        void CalculateLeft(int power)
        {
            float baseX = position.X;
            float baseY = position.Y;
            Image explsionSprite = Image.FromFile(@"Images\blood\Splat01.png");
            for (int i = 0; i < power; i++)
            {
                bool objectHit = false;
                RectangleF currentsqaure = new RectangleF(baseX - explsionSprite.Width, baseY, explsionSprite.Width, explsionSprite.Height);

                foreach (GameObject Object in GameWorld.Objects)
                {
                    if (Object != this)
                    {
                        if (IsIntersectingWith(currentsqaure, Object))
                        {
                            if (Object is Wall || Object is NutObject || Object is HomeTree)
                            {
                                objectHit = true;
                                continue;
                            }
                            else if (Object is Player)
                            {
                                // calls player to lose health
                                ExplosionVsPlayer(Object as Player);

                            }
                            else if (Object is BoomNut)
                            {
                                ExplosionVsBoomNut(Object as BoomNut);
                                //calls the boomnut to explode
                            }
                        }
                    }

                }
                // the explosion hit another Object(wall or Nutobject)
                if (objectHit)
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Objects.Add(new Explosion(new Vector2(baseX, baseY), @"Images\blood\Splat01.png", power, 1f));
                    //add Tile to explosion
                }
                baseX = currentsqaure.X;
            }
        }
        #endregion
        #region Calc Up
        void CalculateUp(int power)
        {
            float baseX = position.X;
            float baseY = position.Y;
            Image explsionSprite = Image.FromFile(@"Images\blood\Splat01.png");
            for (int i = 0; i < power; i++)
            {
                bool objectHit = false;
                RectangleF currentsqaure = new RectangleF(baseX, baseY - explsionSprite.Height, explsionSprite.Width, explsionSprite.Height);

                foreach (GameObject Object in GameWorld.Objects)
                {
                    if (Object != this)
                    {
                        if (IsIntersectingWith(currentsqaure, Object))
                        {
                            if (Object is Wall || Object is NutObject || Object is HomeTree)
                            {
                                objectHit = true;
                                break;
                            }
                            else if (Object is Player)
                            {
                                // calls player to lose health
                                ExplosionVsPlayer(Object as Player);

                            }
                            else if (Object is BoomNut)
                            {
                                ExplosionVsBoomNut(Object as BoomNut);
                                //calls the boomnut to explode
                            }
                        }
                    }

                }
                // the explosion hit another Object(wall or Nutobject)
                if (objectHit)
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Objects.Add(new Explosion(new Vector2(baseX, baseY), @"Images\blood\Splat01.png", power, 1f));
                    //add Tile to explosion
                }
                baseY = currentsqaure.Y;
            }
        }
        #endregion
        #region CalcDown
        void CaculateDown(int power)
        {
            float baseX = position.X;
            float baseY = position.Y;
            Image explsionSprite = Image.FromFile(@"Images\blood\Splat01.png");
            for (int i = 0; i < power; i++)
            {
                bool objectHit = false;
                RectangleF currentsqaure = new RectangleF(baseX, baseY + explsionSprite.Height, explsionSprite.Width, explsionSprite.Height);

                foreach (GameObject Object in GameWorld.Objects)
                {
                    if (Object != this)
                    {
                        if (IsIntersectingWith(currentsqaure, Object))
                        {
                            if (Object is Wall || Object is NutObject || Object is HomeTree)
                            {
                                objectHit = true;
                                break;
                            }
                            else if (Object is Player)
                            {
                                // calls player to lose health
                                ExplosionVsPlayer(Object as Player);

                            }
                            else if (Object is BoomNut)
                            {
                                ExplosionVsBoomNut(Object as BoomNut);
                                //calls the boomnut to explode
                            }
                        }
                    }

                }
                // the explosion hit another Object(wall or Nutobject)
                if (objectHit)
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Objects.Add(new Explosion(new Vector2(baseX, baseY), @"Images\blood\Splat01.png", power, 1f));
                    //add Tile to explosion
                }
                baseY = currentsqaure.Y;
            }
        }
        #endregion
        public void ExplosionVsPlayer(Player player)
        {
            player.LoseHealth();
        }
        public void ExplosionVsBoomNut(BoomNut boomNut)
        {
            //boomNut.Explode();
        }
        public bool IsIntersectingWith(RectangleF sqaure, GameObject other)
        {
            return sqaure.IntersectsWith(other.CollisionBox);
        }
    }
}
