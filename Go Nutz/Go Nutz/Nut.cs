using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace Go_Nutz
{
    class Nut : GameObject
    {


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
