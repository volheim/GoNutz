﻿using System;
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
        private Player player;
        private float scaleFactor;
        private float scaleFactorWidth = 0.2f;
        private bool direction;
        public HomeTree(Vector2 position, string imagePath, float scaleFactor, Player player, bool direction) : base(position,imagePath,scaleFactor)
        {
            this.scaleFactor = scaleFactor;
            this.player = player;
            this.direction = direction;
        }
        public override RectangleF CollisionBox
        {
            get
            {
               return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
        }
        
        public RectangleF DeliverZone
        {
            ///<summary>
            ///creates a zone where the player can deliver his/her nuts
            /// </summary>
            get {
                if (direction)
                {
                    return new RectangleF(position.X, position.Y, sprite.Width * scaleFactorWidth, sprite.Height * scaleFactor);
                }
                else
                {
                    return new RectangleF(position.X - 100, position.Y, sprite.Width * scaleFactorWidth, sprite.Height * scaleFactor);
                }
            }
        }
#if DEBUG
        public override void Draw(Graphics dc)
        {
            dc.DrawRectangle(new Pen(Brushes.Blue), DeliverZone.X, DeliverZone.Y, DeliverZone.Width, DeliverZone.Height);
            base.Draw(dc);
        }
#endif

        public bool ValidatePlayer(Player Caller)
        {
            if (Caller == player)
            {
                return true;
            }
            return false;
        }
    }
}
