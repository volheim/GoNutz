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
        private static HomeTree Hometree2;
        private static MapLoader ML;
        #endregion

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



            
            #region Create Objects;
            
            #region Nuts
            Nut Nut1 = (new Nut(new Vector2(210f, 250f), @"Images\acornDrawn.png", 0.04f));
            #endregion;

            #region Adds To Lists;
            hometrees.Add(Hometree1);
            hometrees.Add(Hometree2);
            objects.Add(Nut1);
            #endregion

            #region LevelGen

            ML = new MapLoader();
            ML.GenerateLevelBitmap(0);
            #endregion;

            #endregion;
        }

        public static void GenerateBlock(int x, int y)
        {
            objects.Add(new Wall(new Vector2(x, y), @"Images\Rock.png", 0.6f));
        }
        public static void GenerateHomeTree(int x, int y)
        {
            if(homeNumber == 0)
            {
                HomeTree Hometree1 = (new HomeTree(new Vector2(x, y), @"Images\stumpHome.png", 1.2f, Player1, false));
                objects.Add(Hometree1);
                Hometrees.Add(Hometree1);
                homeNumber++;
            }
            else if(homeNumber == 1)
            {
                HomeTree Hometree2 = (new HomeTree(new Vector2(x, y), @"Images\stumpHome.png", 1.2f, Player2, false));
                objects.Add(Hometree2);
                Hometrees.Add(Hometree2);
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
