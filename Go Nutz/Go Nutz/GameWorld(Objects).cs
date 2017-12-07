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
    partial class GameWorld
    {
        public void SetupWorld()
        {
            #region Lists;
            objects = new List<GameObject>();
            #endregion

            #region Create Objects;

            objects.Add(new Player(new Vector2(1.0f, 5.0f), @"Images\ChipmunkWalk\ChipmunkWalk01.png;Images\ChipmunkWalk\ChipmunkWalk02.png;Images\ChipmunkWalk\ChipmunkWalk03.png;Images\ChipmunkWalk\ChipmunkWalk04.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E }));
            objects.Add(new Player(new Vector2(800.0f, 5.0f), @"Images\Squirrelanimation\SquiwwelWalk01.png;Images\Squirrelanimation\SquiwwelWalk02.png;Images\Squirrelanimation\SquiwwelWalk03.png;Images\Squirrelanimation\SquiwwelWalk04.png;Images\Squirrelanimation\SquiwwelWalk05.png;Images\Squirrelanimation\SquiwwelWalk06.png;Images\Squirrelanimation\SquiwwelWalk07.png;Images\Squirrelanimation\SquiwwelWalk08.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O }));





            #endregion;
            #region Adds To Lists;
            
            






            #endregion;
            
        }


        void UpdateAnimation(float fps)
        {
            foreach (GameObject obj in Objects)
            {
                obj.UpdateAnimations(fps);
            }
        }
    }
}
