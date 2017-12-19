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

        #region generate properties
        private static int playerNumber;
        private static int homeNumber;
        private static Player Player1;
        private static Player Player2;
        private static HomeTree Hometree1;
        private static HomeTree2 Hometree2;
        private static MapLoader ML;
        #endregion

        public void SetupWorld()
        {

            #region Lists
<<<<<<< HEAD

=======
            // Creates the lists needed for the game to run
>>>>>>> Mikkel
            objects = new List<GameObject>();
            add_Objects = new List<GameObject>();
            remove_Objects = new List<GameObject>();
            explosions_List = new List<Explosion>();
            remove_Explosions_List = new List<Explosion>();
            add_Explosions_List = new List<Explosion>();
            hometrees = new List<HomeTree>();
            #endregion

            ML = new MapLoader();
            ML.GenerateLevelBitmap(0);

            #region Create Objects;

            #region Players

            //Player1 = new Player(new Vector2(500f, 250f), @"Images\ChipmunkWalk\ChipmunkWalk01.png;Images\ChipmunkWalk\ChipmunkWalk02.png;Images\ChipmunkWalk\ChipmunkWalk03.png;Images\ChipmunkWalk\ChipmunkWalk04.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E });
            //Player2 = new Player(new Vector2(600.0f, 250.0f), @"Images\Squirrelanimation\SquiwwelWalk01.png;Images\Squirrelanimation\SquiwwelWalk02.png;Images\Squirrelanimation\SquiwwelWalk03.png;Images\Squirrelanimation\SquiwwelWalk04.png;Images\Squirrelanimation\SquiwwelWalk05.png;Images\Squirrelanimation\SquiwwelWalk06.png;Images\Squirrelanimation\SquiwwelWalk07.png;Images\Squirrelanimation\SquiwwelWalk08.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O });
            //objects.Add(new Player(new Vector2(500f, 250f), @"Images\ChipmunkWalk\ChipmunkWalk01.png;Images\ChipmunkWalk\ChipmunkWalk02.png;Images\ChipmunkWalk\ChipmunkWalk03.png;Images\ChipmunkWalk\ChipmunkWalk04.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E }));
            //objects.Add(new Player(new Vector2(600.0f, 250.0f), @"Images\Squirrelanimation\SquiwwelWalk01.png;Images\Squirrelanimation\SquiwwelWalk02.png;Images\Squirrelanimation\SquiwwelWalk03.png;Images\Squirrelanimation\SquiwwelWalk04.png;Images\Squirrelanimation\SquiwwelWalk05.png;Images\Squirrelanimation\SquiwwelWalk06.png;Images\Squirrelanimation\SquiwwelWalk07.png;Images\Squirrelanimation\SquiwwelWalk08.png", 10, 10, 10, 0.1f, new Keys[6] { Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O }));
            #endregion

            #region HomeTrees
            //HomeTree Hometree1 = (new HomeTree(new Vector2(100f, 250f), @"Images\stumpHome.png", 0.1f,Player1,true));
            //HomeTree Hometree2 = (new HomeTree(new Vector2(1000f, 250f), @"Images\stumpHome.png", 0.1f,Player2,false));

            #region Nuts
            Nut Nut1 = (new Nut(new Vector2(210f, 250f), @"Images\acornDrawn.png", 0.04f));
 
            #endregion



            #endregion;
            #region Adds To Lists;


<<<<<<< HEAD
     

            
            
=======
            objects.Add(Hometree1);
            objects.Add(Hometree2);
            hometrees.Add(Hometree1);
            hometrees.Add(Hometree2);
>>>>>>> Mikkel
            objects.Add(Nut1);

            #region NutGenerator

            #endregion
            #endregion;
            #endregion


        }

        public static void GenerateBlock(int x, int y)
        {
            objects.Add(new Wall(new Vector2(x, y), @"Images\Rock.png", 0.6f));
        }
        public static void GenerateHomeTree(int x, int y)
        {
            if(homeNumber == 0)
            {
                HomeTree Hometree1 = (new HomeTree(new Vector2(x, y), @"Images\stumpHome.png", 1.2f, Player1, true));
                objects.Add(Hometree1);
                homeNumber++;
            }
            else if(homeNumber == 1)
            {
                HomeTree Hometree2 = (new HomeTree(new Vector2(x, y), @"Images\stumpHome.png", 1.2f, Player2, true));
                objects.Add(Hometree2);
                homeNumber++;
            }


        }
        public static void PlacePlayer(int x, int y)
        {
            if (playerNumber == 0)
            {
                Player1 = new Player(new Vector2(x, y), @"Images\ChipmunkWalk\ChipmunkWalk01.png;Images\ChipmunkWalk\ChipmunkWalk02.png;Images\ChipmunkWalk\ChipmunkWalk03.png;Images\ChipmunkWalk\ChipmunkWalk04.png", 10, 10, 10, 0.55f, new Keys[6] { Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E });
                objects.Add(Player1);
                playerNumber++;
            }
            else if (playerNumber == 1)
            {
                Player2 = new Player(new Vector2(x, y), @"Images\Squirrelanimation\SquiwwelWalk01.png;Images\Squirrelanimation\SquiwwelWalk02.png;Images\Squirrelanimation\SquiwwelWalk03.png;Images\Squirrelanimation\SquiwwelWalk04.png;Images\Squirrelanimation\SquiwwelWalk05.png;Images\Squirrelanimation\SquiwwelWalk06.png;Images\Squirrelanimation\SquiwwelWalk07.png;Images\Squirrelanimation\SquiwwelWalk08.png", 10, 10, 10, 0.55f, new Keys[6] { Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O });
                objects.Add(Player2);
                playerNumber++;
            }

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
