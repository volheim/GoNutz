using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    partial class GameWorld
    {
        public static void PlaceWallNut(int x, int y)
        {
            objects.Add(new Wall(new Vector2(x * 60, y * 60), @"Images/wallNUT.png", 0.6f));
        } 
        
    }
}
