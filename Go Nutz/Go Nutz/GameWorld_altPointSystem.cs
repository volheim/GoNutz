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
    partial class GameWorld
    {
        public void DrawUiPlayer(Player player, int pCounter)
        {
            Font f = new Font("Arial", 16);
            if (pCounter == 0)
            {
                dc.DrawString(string.Format("P1 Score: {0}", player.PlayerPoints), f, Brushes.Black, 0, 600);

                dc.DrawString(string.Format("P1 Eaten Nuts: {0}", player.NutCount), f, Brushes.Black, 220, 0);
                pCounter++;
            }
            else if (pCounter == 1)
            {
                dc.DrawString(string.Format("P2 Eaten Nuts: {0}", player.NutCount), f, Brushes.Black, 800, 0);
                dc.DrawString(string.Format("P2 Score: {0}", player.PlayerPoints), f, Brushes.Black, 1055, 600);
                pCounter++;
            }
        }
    }
}
