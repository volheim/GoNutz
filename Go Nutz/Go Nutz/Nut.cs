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
        int p1Nuts = 0;
        int p2Nuts = 0;

        public int P1Nuts { get => p1Nuts; set => p1Nuts = value; }
        public int P2Nuts { get => p2Nuts; set => p2Nuts = value; }

        public Nut(Vector2 position, string imagePath, float scaleFactor) : base(position, imagePath, scaleFactor)
        {
           
        }

        public void OnCollision(GameObject other)
        {

        }

        public void CheckCollision()
        {

        }

        public override void Draw(Graphics dc)
        {
            
            //SpawnRandom();
            
            

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
