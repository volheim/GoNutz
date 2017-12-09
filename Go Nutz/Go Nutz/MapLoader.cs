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
        Bitmap level0;
        Bitmap level1;
        Bitmap level2;
        Bitmap level3;
        Bitmap level4;

        Bitmap curentLevel;

        Color pixelColor;

        int[,] levelLayout = new int[21,12];

        int xPixel;
        int yPixel;


        public void CreateGameObject()
        {
            int xPos = xPixel*90;
            int yPos = yPixel*90;

            if(pixelColor == Color.White)
            {
                GameWorld_Allan.GenerateBlock(xPos, yPos);
            }
            if (pixelColor == Color.Blue)
            {
                GameWorld_Allan.GenerateHomeTree(xPos, yPos);
            }
            if (pixelColor == Color.Green)
            {
                GameWorld_Allan.PlacePlayer(xPos, yPos);
            }
        }

        public void GenerateLevelBitmap(int levelIndex)
        {
            if(levelIndex == 0)
            {
                curentLevel = level0;
            }
            else if (levelIndex == 1)
            {
                curentLevel = level1;
            }
            else if (levelIndex == 2)
            {
                curentLevel = level2;
            }
            else if (levelIndex == 3)
            {
                curentLevel = level3;
            }
            else if (levelIndex == 4)
            {
                curentLevel = level4;
            }

            for (xPixel = 0; xPixel < curentLevel.Width;)
            {
                for (yPixel = 0; yPixel < curentLevel.Height;)
                {
                    pixelColor = curentLevel.GetPixel(xPixel, yPixel);
                    if(pixelColor != Color.Black)
                    {
                        CreateGameObject();
                    }
                    yPixel++;
                }
                xPixel++;
            }
        }

        public void GenerateLevelIntArray(int[,] levelIndex)
        {
            for(int x = 0; x < 21;)
            {
                for(int y = 0; y < 12;)
                {
                    if(levelIndex[x,y] != 0)
                    {
                        
                    }
                    else if(levelIndex[x,y] == 1)
                    {
                        GameWorld_Allan.GenerateBlock(x, y);
                    }
                    else if(levelIndex[x,y] == 2)
                    {
                        GameWorld_Allan.GenerateHomeTree(x, y);
                    }
                    else if (levelIndex[x, y] == 3)
                    {
                        GameWorld_Allan.PlacePlayer(x, y);
                    }
                } 
            }
        }
    }
}
