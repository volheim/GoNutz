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


        public void CreateGameObject()
        {
            int xPos = xPixel*60;
            int yPos = yPixel*60;

            if(pixelColor.ToArgb() == Color.White.ToArgb())
            {
                GameWorld_Allan.GenerateBlock(xPos, yPos);
            }
            if (pixelColor.ToArgb() == Color.Blue.ToArgb())
            {
                GameWorld_Allan.GenerateHomeTree(xPos, yPos);
            }
            if (pixelColor.ToArgb() == Color.Green.ToArgb())
            {
                GameWorld_Allan.PlacePlayer(xPos, yPos);
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
            for(int xPixel = 0; xPixel < 21;)
            {
                for(int yPixel = 0; yPixel < 12;)
                {
                    int xPos = xPixel * 60;
                    int yPos = yPixel * 60;
                    if (levelIndex[xPixel,yPixel] != 0)
                    {
                        
                    }
                    else if(levelIndex[xPixel, yPixel] == 1)
                    {
                        GameWorld_Allan.GenerateBlock(xPos, yPos);
                    }
                    else if(levelIndex[xPixel, yPixel] == 2)
                    {
                        GameWorld_Allan.GenerateHomeTree(xPos, yPos);
                    }
                    else if (levelIndex[xPixel, yPixel] == 3)
                    {
                        GameWorld_Allan.PlacePlayer(xPos, yPos);
                    }
                    yPixel++;
                }
                xPixel++;
            }
        }
    }
}
