using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    class Wall : GameObject
    {
        #region Fields
        float scaleFactor;
        #endregion

        public Wall(Vector2 position, string imagePath, float scaleFactor) : base(position, imagePath, scaleFactor)
        {
             
        }

        
    }
}
