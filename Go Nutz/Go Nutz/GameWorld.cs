using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    class GameWorld
    {
        #region Fields
        private Graphics dc;
<<<<<<< HEAD
        private static List<Player> players;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;


=======
        private static List<GameObject> objects;
        private static List<GameObject> add_Objects;
        private static List<GameObject> remove_Objects;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;
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
>>>>>>> Mikkel-Dev
        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            //create's (Allocates) a buffer in memory with the size of the display
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            //sets the graphics context to the graphics in the buffer
            this.dc = backBuffer.Graphics;
            players = new List<Player>();
        }

        public void SetupWorld()
        {
<<<<<<< HEAD
            players.Add (new Player(new Vector2(0, 0), @"51zeHiyhNOL._SY445_.jpg", 1, 5, 1));
=======
            objects = new List<GameObject>();
            GameObject player = new Player(new Vector2(1.0f, 5.0f),"Piperlok.png", 100, 100, 10);
            objects.Add(player);
>>>>>>> Mikkel-Dev
        }

        public void Update(float fps)
        {
            foreach (var item in players)
            {
                item.Update();

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
                */
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
    }
}
