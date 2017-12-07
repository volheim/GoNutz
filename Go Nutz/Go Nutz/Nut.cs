using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Go_Nutz
{
    class Nut : GameObject
    {
        public Nut(Vector2 position, string imagePath, float scaleFactor) : base(position, imagePath, scaleFactor)
        {
        }

        private void OnCollision(GameObject other)
        {

        }

        private void CheckCollision()
        {

        }
    }
}
