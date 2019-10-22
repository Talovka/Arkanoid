using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AlternativeArkanoid.Enums;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace AlternativeArkanoid
{
    class CreateMaps
    {
        private int mapWidth;
        private int mapHeight;

        public int[,] WorldMap { get; set; }

        Vector2 brickPosition;

        Texture2D brickTexture1;
        Texture2D brickTexture2;
        Texture2D brickTexture3;
        Texture2D brickTexture4;
        Texture2D brickTexture5;

        
        List<GameComponent> gamecomp;

        ContentManager Content;
        
        public CreateMaps( ref Vector2 brickPosition, string path, ref List<GameComponent> gamecomp, ContentManager Content)
        {

            
            this.brickPosition = brickPosition;
            this.gamecomp = gamecomp;
            this.Content = Content;
            LoadContent();
        }
        
        public  void  LoadContent()
        {

            brickTexture1 = Content.Load<Texture2D>("brick1");
            brickTexture2 = Content.Load<Texture2D>("brick2");
            brickTexture3 = Content.Load<Texture2D>("brick3");
            brickTexture4 = Content.Load<Texture2D>("brick4");
            brickTexture5 = Content.Load<Texture2D>("brick5");

        }

        

        private int[,] ReadMap(StreamReader reader)
        {
            int[,] mapTemp;
            mapWidth = int.Parse(reader.ReadLine());
            mapHeight = int.Parse(reader.ReadLine());
            mapTemp = new int[mapHeight, mapWidth];
            string[] tempArray = new string[mapHeight];
            for (int i = 0; i < tempArray.GetLength(0); i++)
            {
                tempArray[i] = reader.ReadLine();
            }

            for (int i = 0; i < tempArray.Length; i++)
            {
                int j = 0;
                var stringOfMap = tempArray[i].Split(',').Select(n => int.Parse(n));
                foreach (var num in stringOfMap)
                {
                    mapTemp[i, j++] = num;
                }
            }
            return mapTemp;
        }
        public void Creatik()
        { 
            for (int i = 0; i < WorldMap.GetLength(0); i++)
            {
                
                for (int j = 0; j < WorldMap.GetLength(1); j++)
                {
                    
                        switch ((ColorBrick)WorldMap[i, j])
                        {
                            case ColorBrick.Red:
                                Brick brick1 = new Brick(brickTexture1, brickPosition, true, Constant.brickwidth, Constant.brickhigth, Constant.brickdY, Constant.brickdX, ColorBrick.Red);
                                gamecomp.Add(brick1);
                                brickPosition.X += brick1.rect.Width;
                                break;
                            case ColorBrick.Blue:
                                Brick brick2 = new Brick(brickTexture5, brickPosition, true, Constant.brickwidth, Constant.brickhigth, Constant.brickdY, Constant.brickdX, ColorBrick.Blue);
                                gamecomp.Add(brick2);
                                brickPosition.X += brick2.rect.Width;
                                break;
                            case ColorBrick.Purple:
                                Brick brick3 = new Brick(brickTexture4, brickPosition, true, Constant.brickwidth, Constant.brickhigth, Constant.brickdY, Constant.brickdX, ColorBrick.Purple);
                                gamecomp.Add(brick3);
                                brickPosition.X += brick3.rect.Width;
                                break;
                            case ColorBrick.Azure:
                                Brick brick4 = new Brick(brickTexture3, brickPosition, true, Constant.brickwidth, Constant.brickhigth, Constant.brickdY, Constant.brickdX, ColorBrick.Azure);
                                gamecomp.Add(brick4);
                                brickPosition.X += brick4.rect.Width;
                                break;
                            case ColorBrick.Green:
                                Brick brick5 = new Brick(brickTexture2, brickPosition, true, Constant.brickwidth, Constant.brickhigth, Constant.brickdY, Constant.brickdX, ColorBrick.Green);
                                gamecomp.Add(brick5);
                                brickPosition.X += brick5.rect.Width;
                                break;

                        }
                    }
                }

            }
        }
    }
    
  
