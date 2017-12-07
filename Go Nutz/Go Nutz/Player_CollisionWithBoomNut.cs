using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Go_Nutz;

namespace Go_Nutz
{
    partial class Player
    {
        public void HandleBoomNut(BoomNut boomNut)
        {
            if (true)
            {

            }
            if (boomNut.InMotion == true)
            {
                boomNut.MovementVector = new Vector2(0, 0);
                boomNut.InMotion = false;
            }

            Kick(boomNut);
        }
    }
}
