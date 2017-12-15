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
            GameWorld.Add_Objects.Add(new BoomNut(new Vector2(position.X + (sprite.Width/3)*scaleFactor, position.Y + (sprite.Height/8)*scaleFactor), @"Images\BoomNut\BoomNutF_001.png;Images\BoomNut\BoomNutF_002.png;Images\BoomNut\BoomNutF_003.png;Images\BoomNut\BoomNutF_004.png;Images\BoomNut\BoomNutF_005.png", 0.2f));
        }
    }
}
