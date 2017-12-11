using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Nutz
{
    partial class Player
    {
        static int points_p1 = 0;
        static int points_p2 = 0;


        public static int Points_p2 { get => points_p2; set => points_p2 += value; }
        public static int Points_p1 { get => points_p1; set => points_p1 += value; }
        

        public void PlayerSpeed()
        {
            if(Nut.P1Nuts == 0)
            {
                this.Speed = 5;
            }

            else if (Nut.P1Nuts == 1)
            {
                this.Speed = 7;
            }

            else if (Nut.P1Nuts == 2)
            {
                this.Speed = 9;
            }

            else if (Nut.P1Nuts == 3)
            {
                this.Speed = 11;
            }

            else if (Nut.P1Nuts == 4)
            {
                this.Speed = 13;
            }

            else if (Nut.P1Nuts == 5)
            {
                this.Speed = 15;
            }
        }



    }
}
