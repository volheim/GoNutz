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
    class GameWorld_Allan
    {
        /*
        #region Fields
        private Graphics dc;
        private static List<Player> players;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;

        private static List<GameObject> objects1;

        private static List<GameObject> objects;
        private static List<GameObject> add_Objects;
        private static List<GameObject> remove_Objects;
        #endregion

        #region Properties
        public static List<GameObject> Add_Objects
        {
            get { return add_Objects; }
            set { add_Objects = value; }
        }
        public static List<GameObject> Removed_Objects
        {
            get { return remove_Objects; }
            set { remove_Objects = value; }
        }
        public static List<GameObject> Objects
        {
            get { return objects; }
            set { objects = value; }
        }
        #endregion
        */
        #region generate properties
        private static int playerNumber;
        private static int homeNumber;
        #endregion
        /*
        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            //create's (Allocates) a buffer in memory with the size of the display
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            //sets the graphics context to the graphics in the buffer
            this.dc = backBuffer.Graphics;
            players = new List<Player>();
        }
        */
        public void SetupWorld()
        {
            MapLoader ML = new MapLoader();
            ML.GenerateLevelBitmap(0);
            /*
            objects = new List<GameObject>();
            GameObject player = new Player(new Vector2(1.0f, 5.0f),"Piperlok.png", 100, 100, 10, Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E);
            GameObject player2 = new Player(new Vector2(1.0f, 5.0f), "Piperlok.png", 100, 100, 10, Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O);
            objects.Add(player);
            objects.Add(player2);
            */
        }
        /*
        public virtual void Update(float fps)
        {
            foreach (GameObject go in objects)
            {
                go.Update(currentFps);
            }
        }

        public virtual void Draw()
        {
            dc.Clear(Color.Red);

            foreach (Player go in players)
            {
                go.Draw(dc);
#if DEBUG //This code will only be run in   debug mode
                Font f = new Font("Arial", 16);
                dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 520, 0);
#endif
                /*
                Font t = new Font("Arial", 16);
                dc.DrawString(string.Format("Health:" + "" + ss.Health), t, Brushes.Black, 0, 0);
                
            }
            //Renders the content of the buffered graphics context to the real context(Swap buffers)
            backBuffer.Render();
        }

        public void GameLoop()
        {

            //log start time
            DateTime startTime = DateTime.Now;

            //time it took since last loop
            TimeSpan deltaTime = startTime - endTime;

            //get milliseconds since last gameloop from the deltatime
            int millSeconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;

            //Calculates current fps
            currentFps = 1000 / millSeconds;

            //log end time
            endTime = DateTime.Now;

            Update(currentFps);
            Draw();
        }
        */
        public static void GenerateBlock(int x, int y)
        {

        }
        public static void GenerateHomeTree(int x, int y)
        {

        }
        public static void PlacePlayer(int x, int y)
        {
            if(playerNumber == 0)
            {
                GameObject player = new Player(new Vector2(x, y), "Piperlok.png", 100, 100, 10, Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E);
                playerNumber++;
            }
            else if (playerNumber == 1)
            {
                GameObject player2 = new Player(new Vector2(1.0f, 5.0f), "Piperlok.png", 100, 100, 10, Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O);
                /* make new player objecct
                 * set sprite as chipmunk image
                 * set position as x,y
                 * include control keys
                 */
            }
            /*if(playerNumber == 3)
            {
                /* make new player objecct
                 * set sprite as other animal image
                 * set position as x,y
                 * include control keys
                 
            }*/
        }
    }
}
