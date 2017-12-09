using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Go_Nutz
{
    class PlayerScore
    {
        
        int points_p1 = 0;
        int points_p2 = 0;

        

        public int Points_p2 { get => points_p2; set => points_p2 += value; }
        public int Points_p1 { get => points_p1; set => points_p1 += value; }


        

        
    }
}
