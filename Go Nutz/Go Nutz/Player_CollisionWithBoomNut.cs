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
            // if the boomNut is just placed the charather has no interaction with it before he step out of the BoomNuts Collision radius:
            if (!boomNut.PhaseAble)
            {
                //if the BoomNut is moving the player will block it with his/her body and thereby stop the movement of the boomNut.
                if (boomNut.InMotion)
                {
                    //set the movement of the bomb to zero
                    boomNut.MovementVector = new Vector2(0, 0);
                    boomNut.InMotion = false;
                }
                else // if the BoomNut is not moving the player will kick the BoomNut
                {
                    //calls kick Method
                    Kick(boomNut);
                }
            }
        }
    }
}
