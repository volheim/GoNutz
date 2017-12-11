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
            #region Players
            Player P1 = (new Player(new Vector2(500f, 250f), @"Images\ChipmunkWalk\ChipmunkWalk01.png;Images\ChipmunkWalk\ChipmunkWalk02.png;Images\ChipmunkWalk\ChipmunkWalk03.png;Images\ChipmunkWalk\ChipmunkWalk04.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E }));
            Player P2 = (new Player(new Vector2(600.0f, 250.0f), @"Images\Squirrelanimation\SquiwwelWalk01.png;Images\Squirrelanimation\SquiwwelWalk02.png;Images\Squirrelanimation\SquiwwelWalk03.png;Images\Squirrelanimation\SquiwwelWalk04.png;Images\Squirrelanimation\SquiwwelWalk05.png;Images\Squirrelanimation\SquiwwelWalk06.png;Images\Squirrelanimation\SquiwwelWalk07.png;Images\Squirrelanimation\SquiwwelWalk08.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O }));
            #endregion

            #region HomeTrees
            HomeTree Hometree1 = (new HomeTree(new Vector2(100f, 250f), @"Images\stumpHome.png", 0.1f, P1));
            HomeTree2 Hometree2 = (new HomeTree2(new Vector2(1000f, 250f), @"Images\stumpHome.png", 0.1f, P2));
            #endregion HomeTrees
            #region Nuts
            Nut Nut1 = (new Nut(new Vector2(210f, 250f), @"Images\acornDrawn.png", 0.04f));

            #endregion



            #endregion;
            #region Adds To Lists;
            objects.Add(P1);
            objects.Add(P2);
            objects.Add(Hometree1);
            objects.Add(Hometree2);
            objects.Add(Nut1);
            



            #region NutGenerator
            
            #endregion

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
