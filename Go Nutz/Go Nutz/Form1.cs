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
        Rectangle rect;

        GameWorld world;
        float fps;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            world = new GameWorld(dc, rect);
            world.SetupWorld();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            world.Update(fps);

        }
    }
}
