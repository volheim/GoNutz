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
        #region Fields
        private Graphics dc;
        private static List<GameObject> objects;
        private static List<GameObject> remove_Objects;
        private static Stack<GameObject> Nuts;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;
        
        #endregion
        #region Properties

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
        #region generate properties
        private static int playerNumber;
        private static int homeNumber;
        MapLoader ML;
        #endregion

        public GameWorld(Graphics dc, Rectangle displayRectangle)

        {
            ML = new MapLoader();
            ML.GenerateLevelBitmap(0);

            //create's (Allocates) a buffer in memory with the size of the display
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            //sets the graphics context to the graphics in the buffer
            this.dc = backBuffer.Graphics;

        }
        
        public void Update(float fps)
        {
            foreach (GameObject go in objects)
            {
                go.Update(currentFps);
            }
            UpdateAnimation(fps);
        }

        public void Draw()
        {
            dc.Clear(Color.Red);
            Font f = new Font("Arial", 16);
            foreach (GameObject go in objects)
            {
                go.Draw(dc);
                dc.DrawString(string.Format("Eaten Nuts: {0}", currentFps), f, Brushes.Black, 220, 0);
                dc.DrawString(string.Format("Eaten Nuts: {0}", currentFps), f, Brushes.Black, 800, 0);
                dc.DrawString(string.Format("P1 Score: {0}", currentFps), f, Brushes.Black, 0, 600);
                dc.DrawString(string.Format("P2 Score: {0}", currentFps), f, Brushes.Black, 1055, 600);
#if DEBUG //This code will only be run in   debug mode
                dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 550, 0);
#endif
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

        public static void GenerateBlock(int x, int y)
        {

        }
        public static void GenerateHomeTree(int x, int y)
        {

        }
        public static void PlacePlayer(int x, int y)
        {
            if (playerNumber == 0)
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

        }
    }
}
