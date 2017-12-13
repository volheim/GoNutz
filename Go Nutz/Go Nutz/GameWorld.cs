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
        private static List<GameObject> add_Objects;
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
        public  static List<GameObject> Add_Objects
        {
            get { return add_Objects; }
            set { add_Objects = value; }
        }
        #endregion


        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {


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
            //adds the added objects to the loop
            Objects.AddRange(add_Objects);
            foreach (GameObject gameobject in remove_Objects)
            {
                Objects.Remove(gameobject);
            }
            UpdateAnimation(fps);
            ClearLoopLists();
        }
        public void ClearLoopLists()
        {
            add_Objects.Clear();
            remove_Objects.Clear();
        }
        public void Draw()
        {
            dc.Clear(Color.Red);
            Font f = new Font("Arial", 16);
            foreach (GameObject go in objects)
            {
                go.Draw(dc);

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

        
    }
}
