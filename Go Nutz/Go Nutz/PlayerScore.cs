using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Nutz
{
    class PlayerScore
    {

        int points;
        
        public PlayerScore() { }
            
        public int GetPoints()
        {
            return points;
        }
        public int SetPoints(int val)
        {
            points += val;
            return points;
        }
    }
}
