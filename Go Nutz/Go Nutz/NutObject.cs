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

        public NutObject(Vector2 position, string imagePath) : base(position, imagePath)
        {
        }

        public void BreakApart()
        {

        }
    }
}
