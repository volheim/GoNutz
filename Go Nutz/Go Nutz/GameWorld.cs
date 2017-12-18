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
        private static List<Explosion> explosions_List;
        private static List<Explosion> add_Explosions_List;
        private static List<Explosion> remove_Explosions_List;
        private static Stack<GameObject> Nuts;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;

        private static List<HomeTree> hometrees;

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
        public static List<Explosion> Explosions_List
        {
            get { return explosions_List; }
            set { explosions_List = value; }
        }
        public static List<Explosion> Add_Explosions_List
        {
            get { return add_Explosions_List; }
            set { add_Explosions_List = value; }
        }
        public static List<Explosion> Remove_Explosions_List
        {
            get { return remove_Explosions_List; }
            set { remove_Explosions_List = value; }
        }
        public static List<HomeTree> Hometrees
        {
            get { return hometrees; }
            set { hometrees = value; }
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
            foreach (Explosion ex in explosions_List)
            {
                ex.Update(currentFps);
            }
            explosions_List.AddRange(add_Explosions_List);
            foreach (Explosion ex in remove_Explosions_List)
            {
                explosions_List.Remove(ex);
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
            ///<summary>
            ///Clear all the add and remove lists
            /// </summary>
            add_Objects.Clear();
            remove_Objects.Clear();
            add_Explosions_List.Clear();
            remove_Explosions_List.Clear();
        }
        public void Draw()
        {
            dc.Clear(Color.Cornsilk);
            Font f = new Font("Arial", 16);
            int pCounter = 0;
            foreach (GameObject go in objects)
            {
                go.Draw(dc);

                if (go is Player)
                {
                    DrawUiPlayer(go as Player, pCounter);
                    pCounter++;
                }
#if DEBUG //This code will only be run in   debug mode
                dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 550, 0);
#endif

            }
            foreach (Explosion ex in explosions_List)
            {
                ex.Draw(dc);
            }
            //Renders the content of the buffered graphics context to the real context(Swap buffers)
            backBuffer.Render();
        }
        public void DrawUiPlayer(Player player, int pCounter)
        {
            Font f = new Font("Arial", 16);
            if (pCounter == 0)
            {
                dc.DrawString(string.Format("P1 Score: {0}", player.PlayerPoints), f, Brushes.Black, 0, 600);
 
                dc.DrawString(string.Format("P1 Eaten Nuts: {0}", player.NutCount), f, Brushes.Black, 220, 0);
                pCounter++;
            }
            else if (pCounter == 1)
            {
                dc.DrawString(string.Format("P2 Eaten Nuts: {0}", player.NutCount), f, Brushes.Black, 800, 0);
                dc.DrawString(string.Format("P2 Score: {0}", player.PlayerPoints), f, Brushes.Black, 1055, 600);
                pCounter++;
            }
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
                //GameObject player = new Player(new Vector2(x, y), "Piperlok.png", 100, 100, 10, Keys.A, Keys.S, Keys.D, Keys.W, Keys.Q, Keys.E);
                playerNumber++;
            }
            else if (playerNumber == 1)
            {
               // GameObject player2 = new Player(new Vector2(1.0f, 5.0f), "Piperlok.png", 100, 100, 10, Keys.J, Keys.K, Keys.L, Keys.I, Keys.U, Keys.O);
                /* make new player objecct
                 * set sprite as chipmunk image
                 * set position as x,y
                 * include control keys
                 */
            }

        }
    }
}
