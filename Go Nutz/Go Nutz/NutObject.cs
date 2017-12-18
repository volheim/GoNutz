using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Go_Nutz
{
    class NutObject : Nut
    {
        private bool isAlive;

        public NutObject(Vector2 position, string imagePath, float scaleFactor) : base(position, imagePath, scaleFactor)
        {
        }

        public void BreakApart()
        {
            GameWorld.Removed_Objects.Add(this);
            GameWorld.Add_Objects.Add(new Nut(this.position, @"Images/acornDrawn.png", 0.45f));
        }
    }
}
