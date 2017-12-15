using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Nutz.Interfaces
{
    interface DynamicObject
    {
        void CheckCollision();
        void IntersectWith(GameObject other);
        void OnCollision(GameObject other);
    }
}
