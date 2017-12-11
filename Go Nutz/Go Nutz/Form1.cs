using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Go_Nutz
{
    public partial class Form1 : Form
    {
        Graphics dc;
        Rectangle rect = new Rectangle(0,0,1920,1080);

        GameWorld world;
        float fps;

        public Form1()
        {
            InitializeComponent();
            GameLoop.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(dc == null)
            {
                dc = CreateGraphics();
            }

            world = new GameWorld(CreateGraphics(), rect);
            world.SetupWorld();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            world.GameLoop();
        }

        private void ButtomCooldown_Tick(object sender, EventArgs e)
        {
            Player.DepositNuts();
        }
    }
}
