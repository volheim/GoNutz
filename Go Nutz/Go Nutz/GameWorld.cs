﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Go_Nutz
{
    public class GameWorld
    {

        GameObject go;
        Player player;


        private Graphics dc;
        private static List<GameObject> objects;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;

        private static List<GameObject> objects1;

        internal static List<GameObject> Objects { get => objects1; set => objects1 = value; }

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            //create's (Allocates) a buffer in memory with the size of the display
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            //sets the graphics context to the graphics in the buffer
            this.dc = backBuffer.Graphics;

        }

        public void SetupWorld()
        {
            objects = new List<GameObject>();
            GameObject player = new Player(new Vector2(1.0f, 5.0f),"Piperlok.png", 100, 100, 10);
            objects.Add(player);
        }

        public virtual void Update(float fps)
        {
            /*foreach (var item in objects)
            {
                item.Update(fps);

            }*/
        }

        public virtual void Draw()
        {
            dc.Clear(Color.Red);

            foreach (GameObject go in objects)
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
