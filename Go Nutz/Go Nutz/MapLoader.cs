using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Go_Nutz
{
    class MapLoader
    {
        Image level0 = Image.FromFile("classic_bitmap.bmp");
        
        // for future levels
        Image level1;
        Image level2;
        Image level3;
        Image level4;
        

        Bitmap curentLevel;

        Color pixelColor;

        int[,] levelLayout = new int[21,12];

        int xPixel;
        int yPixel;

        Random r = new Random();

        public void CreateGameObject()
        {
            int xPos = xPixel*60;
            int yPos = yPixel*60;

            if(pixelColor.ToArgb() == Color.Black.ToArgb())
            {
                levelLayout[xPixel, yPixel] = 4;
            }
            if(pixelColor.ToArgb() == Color.White.ToArgb())
            {
                levelLayout[xPixel, yPixel] = 1;
                GameWorld.GenerateBlock(xPos, yPos);
            }
            if (pixelColor.ToArgb() == Color.Blue.ToArgb())
            {
                levelLayout[xPixel, yPixel] = 2;
                GameWorld.GenerateHomeTree(xPos, yPos);
            }
            if (pixelColor.ToArgb() == Color.Green.ToArgb())
            {
                levelLayout[xPixel, yPixel] = 3;
                GameWorld.PlacePlayer(xPos, yPos);
            }

        }

        public void PlaceWallNuts(int count)
        {
            int x;
            int y;
            for(int i = 0; i < count;)
            {
                x = r.Next(0, 21);
                y = r.Next(0, 12);
                if (levelLayout[x, y] == 4)
                {
                    GameWorld.PlaceWallNut(x, y);
                    i++;
                }
            }
        }


        public void GenerateLevelBitmap(int levelIndex)
        {
            if(levelIndex == 0)
            {
                curentLevel = new Bitmap(level0);
            }
            else if (levelIndex == 1)
            {
                curentLevel = new Bitmap(level1);
            }
            else if (levelIndex == 2)
            {
                curentLevel = new Bitmap(level2);
            }
            else if (levelIndex == 3)
            {
                curentLevel = new Bitmap(level3);
            }
            else if (levelIndex == 4)
            {
                curentLevel = new Bitmap(level4);
            }

            for (xPixel = 0; xPixel < curentLevel.Width;)
            {
                for (yPixel = 0; yPixel < curentLevel.Height;)
                {
                    pixelColor = curentLevel.GetPixel(xPixel, yPixel);
                    if(pixelColor.ToArgb() != Color.FromArgb(100,100,100).ToArgb())
                    {
                        CreateGameObject();
                    }
                    yPixel++;
                }
                xPixel++;
            }
            GameWorld.Add_Objects.Add(new BorderWall(new System.Numerics.Vector2(0, -1260), "empty.png", 1260));
            GameWorld.Add_Objects.Add(new BorderWall(new System.Numerics.Vector2(0, 720), "empty.png", 1260));
            GameWorld.Add_Objects.Add(new BorderWall(new System.Numerics.Vector2(-720, 0), "empty.png", 720));
            GameWorld.Add_Objects.Add(new BorderWall(new System.Numerics.Vector2(1260, 0), "empty.png", 720));
            PlaceWallNuts(75);
        }

        public void GenerateLevelIntArray(int[,] levelIndex)
        {
            for(int xPixel = 0; xPixel < 21;)
            {
                for(int yPixel = 0; yPixel < 12;)
                {
                    int xPos = xPixel * 60;
                    int yPos = yPixel * 60;
                    if (levelIndex[xPixel,yPixel] == 0)
                    {
                        
                    }
                    else if(levelIndex[xPixel, yPixel] == 1)
                    {
                        GameWorld.GenerateBlock(xPos, yPos);
                    }
                    else if(levelIndex[xPixel, yPixel] == 2)
                    {
                        GameWorld.GenerateHomeTree(xPos, yPos);
                    }
                    else if (levelIndex[xPixel, yPixel] == 3)
                    {
                        GameWorld.PlacePlayer(xPos, yPos);
                    }
                    yPixel++;
                }
                xPixel++;
            }
            PlaceWallNuts(75);
        }
    }
}
