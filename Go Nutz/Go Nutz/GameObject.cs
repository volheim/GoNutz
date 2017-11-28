using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using System.Numerics;
=======
using System.Drawing;
>>>>>>> Lars

namespace Go_Nutz
{
    abstract class GameObject
    {
<<<<<<< HEAD
        public Vector2 position;
        public Vector2 movementVector;
        
=======
        private Rectangle collisionbox;
        private Image sprite;
        private Vector2D position;

        public void Draw()
        {

        }

        public virtual void Update()
        {

        }
>>>>>>> Lars
    }
}
