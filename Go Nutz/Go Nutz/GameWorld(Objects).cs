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
        public void SetupWorld()
        {
            objects = new List<GameObject>();
            GameObject player = new Player(new Vector2(1.0f, 5.0f), "Piperlok.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E });
            GameObject player2 = new Player(new Vector2(800.0f, 5.0f), @"Images\Squiwwel.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O });
            objects.Add(player);
            objects.Add(player2);
        }

    }
}
