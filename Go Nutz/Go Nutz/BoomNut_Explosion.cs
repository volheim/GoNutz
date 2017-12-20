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
        private Image explsionSprite = Image.FromFile(@"Images\ExplosionSprites\Ex3.png");
        public Image ExplosionSprite
        {
            get { return explsionSprite; }
            set { explsionSprite = value; }
        }
        public void CalculateExplosionRadius(int power)
        {
            float factor = 0.15f;
            CalculateLeft(power, factor);
            CalculateRight(power, factor);
            CalculateUp(power, factor);
            CaculateDown(power, factor);
        }
        #region Calc Right
        void CalculateRight(int power, float scaleFactor2)
        {
            float baseX = Position.X;
            float baseY = Position.Y;
            for (int i = 0; i < power; i++)
            {
                RectangleF currentsquare = new RectangleF(baseX + explsionSprite.Width * scaleFactor2, baseY, (explsionSprite.Width * scaleFactor2)/2, explsionSprite.Height * scaleFactor2);
                // the explosion hit another Object(wall or Nutobject)

                if (Checkspace(currentsquare))
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Explosions_List.Add(new Explosion(new Vector2(baseX, baseY), @"Images\ExplosionSprites\Ex0.png", power, scaleFactor2));
                    //add Tile to explosion
                }
                baseX = currentsquare.X;
            }
        }
        #endregion
        #region Calc Left
        void CalculateLeft(int power, float scaleFactor2)
        {
            float baseX = position.X;
            float baseY = position.Y;

            for (int i = 0; i < power; i++)
            {

                RectangleF currentsquare = new RectangleF(baseX - explsionSprite.Width * scaleFactor2, baseY, explsionSprite.Width * scaleFactor2, explsionSprite.Height * scaleFactor2);
                if (i == 0)
                {
                    currentsquare = new RectangleF(baseX - (explsionSprite.Width + explsionSprite.Width) * scaleFactor2, baseY, explsionSprite.Width * scaleFactor2, explsionSprite.Height * scaleFactor2);
                    continue;
                }
                baseX = currentsquare.X;
                // the explosion hit another Object(wall or Nutobject)
                if (Checkspace(currentsquare))
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Explosions_List.Add(new Explosion(new Vector2(baseX, baseY), @"Images\ExplosionSprites\Ex1.png", power, scaleFactor2));
                    //add Tile to explosion
                }

            }
        }
        #endregion
        #region Calc Up
        void CalculateUp(int power, float scaleFactor2)
        {
            float baseX = position.X;
            float baseY = position.Y;
            for (int i = 0; i < power; i++)
            {
                RectangleF currentsquare = new RectangleF(baseX, baseY - explsionSprite.Height * scaleFactor2, explsionSprite.Width * scaleFactor2, explsionSprite.Height * scaleFactor2);
                if (i == 0)
                {
                    currentsquare = new RectangleF(baseX, baseY - (explsionSprite.Height + explsionSprite.Height) * scaleFactor2, explsionSprite.Width * scaleFactor2, explsionSprite.Height * scaleFactor2);

                    continue;
                }
                baseY = currentsquare.Y;
                // the explosion hit another Object(wall or Nutobject)
                if (Checkspace(currentsquare))
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Explosions_List.Add(new Explosion(new Vector2(baseX, baseY), @"Images\ExplosionSprites\Ex2.png", power, scaleFactor2));
                    //add Tile to explosion
                }
            }
        }
        #endregion
        #region CalcDown
        void CaculateDown(int power, float scaleFactor2)
        {
            float baseX = position.X;
            float baseY = position.Y;
            for (int i = 0; i < power; i++)
            {
                RectangleF currentsquare = new RectangleF(baseX, baseY + explsionSprite.Height * scaleFactor2, explsionSprite.Width * scaleFactor2, explsionSprite.Height * scaleFactor2);
                if (i == 0)
                {
                    currentsquare = new RectangleF(baseX, baseY + (explsionSprite.Height + explsionSprite.Height) * scaleFactor2, explsionSprite.Width * scaleFactor2, explsionSprite.Height * scaleFactor2);
                    continue;
                }
                baseY = currentsquare.Y;
                // the explosion hit another Object(wall or Nutobject)
                if (Checkspace(currentsquare))
                {
                    break;
                }
                else
                {
                    GameWorld.Add_Explosions_List.Add(new Explosion(new Vector2(baseX, baseY), @"Images\ExplosionSprites\Ex3.png", power, scaleFactor2));
                    //add Tile to explosion
                }
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
        public void ExplosionVsNutObject(NutObject nut)
        {
            nut.BreakApart();
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
                        if (Object is Wall || Object is HomeTree || Object is BorderWall)
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
                        else if (Object is NutObject)
                        {
                            ExplosionVsNutObject(Object as NutObject);
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
