using System;
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
            GameWorld.Add_Objects.Add(new BoomNut(Constants.boomNutAnimation, new Vector2(position.X + (Sprite.Width)*scaleFactor, position.Y + (Sprite.Height)*scaleFactor), 0.13f,this, this.nutCount));
        }
    }
}
