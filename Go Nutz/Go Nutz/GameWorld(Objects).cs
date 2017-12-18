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
            #region Lists
            // Creates the lists needed for the game to run
            objects = new List<GameObject>();
            add_Objects = new List<GameObject>();
            remove_Objects = new List<GameObject>();
            explosions_List = new List<Explosion>();
            remove_Explosions_List = new List<Explosion>();
            add_Explosions_List = new List<Explosion>();
            hometrees = new List<HomeTree>();
            #endregion

            #region Create Objects
            #region Players

            Player Player1 = new Player(new Vector2(500f, 250f), @"Images\ChipmunkWalk\ChipmunkWalk01.png;Images\ChipmunkWalk\ChipmunkWalk02.png;Images\ChipmunkWalk\ChipmunkWalk03.png;Images\ChipmunkWalk\ChipmunkWalk04.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E });
            Player Player2 = new Player(new Vector2(600.0f, 250.0f), @"Images\Squirrelanimation\SquiwwelWalk01.png;Images\Squirrelanimation\SquiwwelWalk02.png;Images\Squirrelanimation\SquiwwelWalk03.png;Images\Squirrelanimation\SquiwwelWalk04.png;Images\Squirrelanimation\SquiwwelWalk05.png;Images\Squirrelanimation\SquiwwelWalk06.png;Images\Squirrelanimation\SquiwwelWalk07.png;Images\Squirrelanimation\SquiwwelWalk08.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O });
            //objects.Add(new Player(new Vector2(500f, 250f), @"Images\ChipmunkWalk\ChipmunkWalk01.png;Images\ChipmunkWalk\ChipmunkWalk02.png;Images\ChipmunkWalk\ChipmunkWalk03.png;Images\ChipmunkWalk\ChipmunkWalk04.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E }));
            //objects.Add(new Player(new Vector2(600.0f, 250.0f), @"Images\Squirrelanimation\SquiwwelWalk01.png;Images\Squirrelanimation\SquiwwelWalk02.png;Images\Squirrelanimation\SquiwwelWalk03.png;Images\Squirrelanimation\SquiwwelWalk04.png;Images\Squirrelanimation\SquiwwelWalk05.png;Images\Squirrelanimation\SquiwwelWalk06.png;Images\Squirrelanimation\SquiwwelWalk07.png;Images\Squirrelanimation\SquiwwelWalk08.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O }));
            #endregion

            #region HomeTrees
            HomeTree Hometree1 = (new HomeTree(new Vector2(100f, 250f), @"Images\stumpHome.png", 0.1f,Player1,true));
            HomeTree Hometree2 = (new HomeTree(new Vector2(1000f, 250f), @"Images\stumpHome.png", 0.1f,Player2,false));

            #region Nuts
            Nut Nut1 = (new Nut(new Vector2(210f, 250f), @"Images\acornDrawn.png", 0.04f));
 
            #endregion



            #endregion;
            #region Adds To Lists;

            objects.Add(Player1);
            objects.Add(Player2);

            objects.Add(Hometree1);
            objects.Add(Hometree2);
            hometrees.Add(Hometree1);
            hometrees.Add(Hometree2);
            objects.Add(Nut1);

            #region NutGenerator

            #endregion
            #region LevelGen
            MapLoader ML = new MapLoader();
            ML.GenerateLevelBitmap(0);
            #endregion
            #endregion;
            #endregion
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
