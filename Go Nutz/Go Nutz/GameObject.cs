using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Go_Nutz
{
    abstract class GameObject
    {
        private Rectangle collisionbox;
        private Image sprite;
        private Vector2D position;

        public void Draw()
        {

        }

        public virtual void Update()
        {

        }
    }
}
