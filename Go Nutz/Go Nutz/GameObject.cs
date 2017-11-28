using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace Go_Nutz
{
    abstract class GameObject
    {
        Graphics dc;

        public Vector2 position;
        public Vector2 movementVector;

        private Rectangle collisionbox;
        private Image sprite;

        public virtual void Draw(Graphics dc)
        {

        }

        public virtual void Update(float fps)
        {
            Draw(dc);
        }
    }
}
