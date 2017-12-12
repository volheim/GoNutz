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
    class Nut : GameObject
    {
        static int p1Nuts = 6;
        static int p2Nuts = 6;

       // public static int P1Nuts { get => p1Nuts; set => p1Nuts = value; }
       // public static int P2Nuts { get => p2Nuts; set => p2Nuts = value; }
        public static int P1Nuts
        {
            get { return p1Nuts; }
            set { p1Nuts = value; }
        }
        public static int P2Nuts
        {
            get { return p2Nuts; }
            set { p2Nuts = value; }
        }

        public Nut(Vector2 position, string imagePath, float scaleFactor) : base(position, imagePath, scaleFactor)
        {
           
        }

        public void OnCollision(GameObject other)
        {

        }

        public void CheckCollision()
        {

        }
        Font f = new Font("Arial", 16);
        public override void Draw(Graphics dc)
        {

            //SpawnRandom();

            dc.DrawString(string.Format("P1 Eaten Nuts: {0}", P1Nuts), f, Brushes.Black, 220, 0);
            dc.DrawString(string.Format("P2 Eaten Nuts: {0}", P2Nuts), f, Brushes.Black, 800, 0);

        }

        public override void Update(float fps)
        {
            //SpawnRandom();
            
        }

        public void SpawnRandom()
        {
            Random random = new Random();
            
            this.position.Y += Convert.ToInt32(random.Next(1, 450));
            this.position.X += Convert.ToInt32(random.Next(1, 300));
        }
    }
}
