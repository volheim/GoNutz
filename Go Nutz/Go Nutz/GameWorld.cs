﻿using System;
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
        //makes a shorter list to iterate faster
        private static List<HomeTree> hometrees;
        private static List<Player> playerList;
        private int endTimer;
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


        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {

            
            //create's (Allocates) a buffer in memory with the size of the display
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);

            //sets the graphics context to the graphics in the buffer
            this.dc = backBuffer.Graphics;

            this.endTimer = 150;
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
            foreach (GameObject go in objects)
            {
                go.Draw(dc);

#if DEBUG //This code will only be run in   debug mode
                dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 550, 0);
#endif

            }
            foreach (Explosion ex in explosions_List)
            {
                ex.Draw(dc);
            }
            foreach (Player player in playerList)
            {
                DrawUiPlayer(player);

            }
            //Renders the content of the buffered graphics context to the real context(Swap buffers)
            backBuffer.Render();
        }
        public void DrawUiPlayer(Player player)
        {
            Font f = new Font("Arial", 16);
            if (player == Player1)
            {
                dc.DrawString(string.Format("P1 Score: {0}", player.PlayerPoints), f, Brushes.Black, 0, 600);
 
                dc.DrawString(string.Format("P1 Eaten Nuts: {0}", player.NutCount), f, Brushes.Black, 220, 0);
            }
            else if (player == Player2)
            {
                dc.DrawString(string.Format("P2 Eaten Nuts: {0}", player.NutCount), f, Brushes.Black, 800, 0);
                dc.DrawString(string.Format("P2 Score: {0}", player.PlayerPoints), f, Brushes.Black, 1055, 600);
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
        public void EndGame()
        {
            if (endTimer <= 0)
            {
                int currentHighestScore = 0;
                Player winner = null;
                foreach (Player player in playerList)
                {
                    if (player.PlayerPoints > currentHighestScore)
                    {
                        currentHighestScore = player.PlayerPoints;
                        winner = player;
                    }
                }
                string winnerString = string.Format("Winner is {0} with {1}", winner, currentHighestScore);
                MessageBox.Show(winnerString);
            }
            else
            {
                endTimer--;
            }
        }
        
    }
}
