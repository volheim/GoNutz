﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Go_Nutz
{
    partial class Player
    {
        public void PlaceBomb()
        {
            GameWorld.Add_Objects.Add(new BoomNut(Constants.boomNutAnimation, new Vector2(position.X + (sprite.Width/3)*scaleFactor, position.Y + (sprite.Height/8)*scaleFactor), 0.2f,this));
        }
    }
}
