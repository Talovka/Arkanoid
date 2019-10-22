using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using AlternativeArkanoid.Enums;
using System.Threading;


namespace AlternativeArkanoid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        Texture2D backgroundTexture;

        Texture2D theBall;

        Texture2D brickTexture1;
        Texture2D brickTexture2;
        Texture2D brickTexture3;
        Texture2D brickTexture4;
        Texture2D brickTexture5;

        Texture2D bonusTexture1;
        Texture2D bonusTexture2;
        Texture2D bonusTexture3;
        Texture2D bonusTexture4;
        Texture2D bonusTexture5;
        Texture2D bonusTexture6;
        Texture2D bonusTexture7;
        Texture2D bonusTexture8;
        

        Texture2D thePaddle;
        Texture2D megapaddle;

        Vector2 brickPosition;
        Vector2 theBallPosition;
        Vector2 thePaddlePosition;

        Song song1;

        SoundEffect beep;
       
        SpriteFont score;
        SpriteFont live;

        int currentlive = 3;
        int currentscore = 0;
        

        List<GameComponent> Gamecomp;

        Random gener;

        
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        protected override void Initialize()
        {
            base.Initialize();
            gener = new Random();
            Gamecomp = new List<GameComponent>();
            
            theBallPosition = new Vector2();
            theBallPosition.X = GraphicsDevice.Viewport.Width / 2 - theBall.Width / 2;
            theBallPosition.Y = ((GraphicsDevice.Viewport.Height - theBall.Height) / 2) + 45;

            thePaddlePosition = new Vector2();
            thePaddlePosition.X = GraphicsDevice.Viewport.Width / 2 - (Constant.originalpaddlewidth / 2);
            thePaddlePosition.Y = GraphicsDevice.Viewport.Height - 35 - Constant.originalpaddleheigth;
            
            Paddle paddle = new Paddle(thePaddle, thePaddlePosition, Constant.originalpaddlewidth, Constant.originalpaddleheigth);
            Gamecomp.Add(paddle);

            Ball firstBall = new Ball(theBall, theBallPosition, Constant.originalballsize, Constant.originalballsize, 
            Constant.balldX, Constant.originalballdY);

            Gamecomp.Add(firstBall);

            brickPosition.X = (((GraphicsDevice.Viewport.Width - (20 * Constant.brickwidth)) / 2)); 
            brickPosition.Y = 25;

            Map();
           
           

        }
        public void Map()
        {

            for (int row = 0; row< 3; row++)
            {
                for (int col1 = 0; col1< 20; col1++)
                {
                    Brick newBrick = new Brick(brickTexture1, brickPosition, false, Constant.brickwidth, Constant.brickhigth,
                     Constant.brickdY, Constant.brickdX, ColorBrick.Red);
                
                    Gamecomp.Add(newBrick);

                    brickPosition.X += newBrick.rect.Width;
                }

                brickPosition.X = (((GraphicsDevice.Viewport.Width - (20 * Constant.brickwidth)) / 2));
                brickPosition.Y += Constant.brickhigth + Constant.singlesize;

                for (int col2 = 0; col2< 1; col2++)
                {
                    Brick newBrick = new Brick(brickTexture2, brickPosition, true, Constant.brickwidth, Constant.brickhigth,
                     Constant.brickdY, Constant.brickdX,ColorBrick.Green);

                    Gamecomp.Add(newBrick);

                    brickPosition.X += newBrick.rect.Width;
                }

                brickPosition.X = (((GraphicsDevice.Viewport.Width - (20 * Constant.brickwidth)) / 2));
                brickPosition.Y += Constant.brickhigth + Constant.singlesize;

                for (int col3 = 0; col3< 20; col3++)
                {
                    Brick newBrick = new Brick(brickTexture3, brickPosition, false, Constant.brickwidth, Constant.brickhigth,
                    Constant.brickdY, Constant.brickdX,ColorBrick.Azure);

                   Gamecomp.Add(newBrick);

                    brickPosition.X += newBrick.rect.Width;
                }

                brickPosition.X = (((GraphicsDevice.Viewport.Width - (20 * Constant.brickwidth)) / 2));
                brickPosition.Y += Constant.brickhigth + Constant.singlesize;

                for (int col4 = 0; col4< 1; col4++)
                {
                    Brick newBrick = new Brick(brickTexture4, brickPosition, true, Constant.brickwidth, Constant.brickhigth,
                     Constant.brickdY, Constant.brickdX,ColorBrick.Purple);

                    Gamecomp.Add(newBrick);

                    brickPosition.X += newBrick.rect.Width;
                }

                brickPosition.X = (((GraphicsDevice.Viewport.Width - (20 * Constant.brickwidth)) / 2));
                brickPosition.Y += Constant.brickhigth + Constant.singlesize;

                for (int col5 = 0; col5< 1; col5++)
                {
                    Brick newBrick = new Brick(brickTexture5, brickPosition, true, Constant.brickwidth, Constant.brickhigth,
                     Constant.brickdY, Constant.brickdX, ColorBrick.Blue);

                    Gamecomp.Add(newBrick);

                    brickPosition.X += newBrick.rect.Width;
                }

                brickPosition.X = (((GraphicsDevice.Viewport.Width - (20 * Constant.brickwidth)) / 2));
                brickPosition.Y += Constant.brickhigth + Constant.singlesize;
            }
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            theBall = Content.Load<Texture2D>("ball");


            brickTexture1 = Content.Load<Texture2D>("brick1");
            brickTexture2 = Content.Load<Texture2D>("brick2");
            brickTexture3 = Content.Load<Texture2D>("brick3");
            brickTexture4 = Content.Load<Texture2D>("brick4");
            brickTexture5 = Content.Load<Texture2D>("brick5");

            bonusTexture1 = Content.Load<Texture2D>("Positive2");
            bonusTexture2 = Content.Load<Texture2D>("Negative");
            bonusTexture3 = Content.Load<Texture2D>("Liveminus2");
            bonusTexture4 = Content.Load<Texture2D>(@"hearts-8");
            bonusTexture6 = Content.Load<Texture2D>(@"plusballsize");
            bonusTexture5 = Content.Load<Texture2D>(@"minusballsize");
            bonusTexture7 = Content.Load<Texture2D>(@"Paddleplus");
            bonusTexture8 = Content.Load<Texture2D>(@"Paddleminus");

            thePaddle = Content.Load<Texture2D>("paddle");
            megapaddle = Content.Load<Texture2D>("megapaddle3");

            backgroundTexture = Content.Load<Texture2D>("space");

            score = Content.Load<SpriteFont>(@"Font\Score");

            live = Content.Load<SpriteFont>(@"Font\Live");

            beep = Content.Load<SoundEffect>(@"beep");

            song1 = Content.Load<Song>("song");
            MediaPlayer.Play(song1);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

        }
        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Volume -= 0.1f;
        }
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))     
             this.Exit();

            KeyboardState currentKeyboardState = Keyboard.GetState();
            foreach (var item in Gamecomp.OfType<Paddle>())
            {
                if (currentKeyboardState.IsKeyDown(Keys.Left))
                {
                    item.rect.X -= Constant.paddledX;
                    item.thePosition.X -= Constant.paddledX;
                }
                if (currentKeyboardState.IsKeyDown(Keys.Right))
                {
                    item.rect.X += Constant.paddledX;
                    item.thePosition.X += Constant.paddledX;

                }
                item.rect.X = MathHelper.Clamp(item.rect.X, 0, GraphicsDevice.Viewport.Width - item.rect.Width);

            }
            
            BallandWindow(gameTime);

            BrickandWindow(gameTime);

            Brickrun(gameTime);

            Brickhit(gameTime);

            Bonusrun(gameTime);

            Bonusdelete(gameTime);

            Balldelete(gameTime);

            UpdateBall(gameTime);

            UpdateBrick(gameTime);

            Updatebonus(gameTime);

            Exiting(gameTime);
            
            base.Update(gameTime);
        }
        private new void Exiting(GameTime gameTime)
        {

            if (currentlive == 0)
            {


                Exit();

            }

            if (Gamecomp.OfType<Ball>().Count() == 0 || Gamecomp.OfType<Brick>().Count() == 0)
            {
                if (currentlive > 1)
                {
                    currentlive--;
                    Ball newBall = new Ball(theBall, theBallPosition, Constant.originalballsize, 
                    Constant.originalballsize, Constant.balldX, Constant.originalballdY);
                    Gamecomp.Add(newBall);
                }
                else
                {
                    Exit();
                }
            }

        }

        private void Brickrun(GameTime gametime)
        {
            foreach (var item in Gamecomp.OfType<Brick>())
            {
                if (!item.isHit() && item.isVisible() && item.isMoving())
                {
                    item.UpdatedX(gametime);

                }
                if (item.isHit() && item.isVisible())
                {
                    item.UpdatedY(gametime);
                }
            }
        }

        private void Bonusrun(GameTime gametime)
        {
            foreach (var item in Gamecomp.OfType<Bonus>())
            {
                item.Update(gametime);
            }
        }

        private void Brickhit(GameTime gametime)
        {
            for (int i = 0; i < Gamecomp.Count; i++) 
            {

                Brick temp = Gamecomp[i] as Brick;
                if (temp != null)
                {
                    if (temp.isHit() && temp.isVisible())
                    {
                        if (temp.rect.Y > GraphicsDevice.Viewport.Height)
                        {
                            temp.brickHit();
                            Gamecomp.Remove(temp);
                        }
                    }
                }
            }
        }

        private void Bonusdelete(GameTime gametime)
        {
            for (int i = 0; i < Gamecomp.Count; i++)
            {
                Bonus temp = Gamecomp[i] as Bonus;
                if (temp != null)
                {
                    if (temp.rect.Y > GraphicsDevice.Viewport.Height)
                    {
                        Gamecomp.Remove(temp);
                    }
                }
            }
        }
        private void Balldelete(GameTime gametime)
        {
            for (int i = 0; i < Gamecomp.Count; i++)// Update all the balls
            {
                Ball temp = Gamecomp[i] as Ball;
                if (temp != null)
                {
                    if (temp.rect.Y + temp.rect.Height > GraphicsDevice.Viewport.Height) //Ball hits bottom of screen
                    {
                        if (temp.isActive())
                        {
                            temp.setInactive();
                            Gamecomp.Remove(temp);
                        }
                    }
                }
            }
        }
        private void BrickandWindow(GameTime gametime)
        {
            for (int i = 0; i < Gamecomp.Count; i++)
            {
                Brick temp = Gamecomp[i] as Brick;
                if (temp != null)
                {
                    if ((temp.rect.X + temp.rect.Width > GraphicsDevice.Viewport.Width) || temp.rect.X < 0)
                    {
                        temp.dX = -temp.dX;
                    }
                }
            }
        }
        private void BallandWindow(GameTime gametime)
        {
            for (int i = 0; i < Gamecomp.Count; i++)
            {
                Ball ball = Gamecomp[i] as Ball;
                if (ball != null)
                {
                    if ((ball.rect.X + ball.rect.Width > GraphicsDevice.Viewport.Width) || ball.rect.X < 0)
                    {
                        ball.dX = -ball.dX;
                    }

                    if (ball.rect.Y < 0)
                    {
                        ball.dY = -ball.dY;
                    }

                    ball.Update(gametime);
                }
            }
        }
        private void UpdateBrick(GameTime gametime)
        {
            for (int i = 0; i < Gamecomp.Count; i++)
            {
                Ball ball = Gamecomp[i] as Ball;
                if (ball != null)
                {
                    if (ball.isActive())
                    {
                        for (int j = 0; j < Gamecomp.Count; j++)
                        {
                            Brick brick = Gamecomp[j] as Brick;
                            
                            if (brick != null)
                            {
                                if (brick.isVisible() && !brick.isHit()) 
                                {
                                    if (ball.BallRectL.Intersects(brick.BrickRectR) || ball.BallRectR.Intersects(brick.BrickRectL))
                                    {
                                        ball.dX = -ball.dX;
                                        brick.brickWasHit();
                                        Randombonus(gener, brick.thePosition);
                                        currentscore += brick.ScorePlusValue(); 
                                        beep.Play();
                                        break;
                                    }
                                    if (ball.BallRectT.Intersects(brick.BrickRectB) || ball.BallRectB.Intersects(brick.BrickRectT))
                                    {
                                        ball.dY = -ball.dY;
                                        brick.brickWasHit();
                                        Randombonus(gener, brick.thePosition);
                                        beep.Play();
                                        currentscore += brick.ScorePlusValue();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void UpdateBall(GameTime gametime)
        {
            for (int i = 0; i < Gamecomp.Count; i++)
            {
                Ball ball = Gamecomp[i] as Ball;
                if (ball != null)
                {
                    if (ball.isActive())
                {
                 for (int k = 0; k < Gamecomp.Count; k++)
                   {
                    Paddle paddle = Gamecomp[k] as Paddle;
                    if (paddle != null)
                  {
                    {
                        if (ball.dX > 0)
                   {

                       if (ball.BallRectR.Intersects(paddle.PaddleRectT5) || ball.BallRectR.Intersects(paddle.PaddleRectT1))
                       {
                           ball.dX = -4;
                           ball.dY = -2;
                           beep.Play();
                           break;
                       }
                   }
                   if (ball.dX < 0)
                   {
                       if (ball.BallRectL.Intersects(paddle.PaddleRectT1) || ball.BallRectL.Intersects(paddle.PaddleRectT5))
                       {
                           ball.dX = 4;
                           ball.dY = -2;
                           beep.Play();
                           break;
                       }
                   }

                   if (ball.BallRectB.Intersects(paddle.PaddleRectT1))
                   {
                       ball.dX = -1;
                       ball.dY = -4;
                       beep.Play();
                       break;
                   }
                   if (ball.BallRectB.Intersects(paddle.PaddleRectT2))
                   {
                       ball.dX = -1;
                       ball.dY = -3;
                       beep.Play();
                       break;
                   }
                   if (ball.BallRectB.Intersects(paddle.PaddleRectT3))
                   {
                       ball.dX = 0.5f;
                       ball.dY = -3;
                       beep.Play();
                       break;
                   }
                   if (ball.BallRectB.Intersects(paddle.PaddleRectT4))
                   {
                       ball.dX = 1;
                       ball.dY = -3;
                       beep.Play();
                       break;
                   }
                   if (ball.BallRectB.Intersects(paddle.PaddleRectT5))
                   {
                       ball.dX = 1;
                       ball.dY = -4;
                       beep.Play();
                       break;
                     }
                    }
                  }
                }
              }
            }
          }
        }

        private void Updatebonus(GameTime gametime)
        {
            for (int j = 0; j < Gamecomp.Count; j++)
            {
             Ball ball = Gamecomp[j] as Ball;
              if (ball != null)
            {
            for (int i = 0; i < Gamecomp.Count; i++)
            {
                Paddle paddle = Gamecomp[i] as Paddle;
                if (paddle != null)
            {
              for (int k = 0; k < Gamecomp.Count; k++)
            {
               Bonus bonus = Gamecomp[k] as Bonus;
              if (bonus != null)
            {
               if (bonus.rect.Intersects(paddle.rect))
                {
             if (bonus.kindbonus == NameBonus.Plusscore)
            {
                Gamecomp.Remove(bonus);
                currentscore += Constant.bonusscore;
                break;
            }
            if (bonus.kindbonus == NameBonus.Minusscore)
            {
                Gamecomp.Remove(bonus);
                currentscore -= Constant.bonusscore;
                break;
            }
            if (bonus.kindbonus == NameBonus.Pluslife)
            {
                Gamecomp.Remove(bonus);
                currentlive -= Constant.singlelife;
                break;
            }
            if (bonus.kindbonus == NameBonus.Minuslife)
            {
                Gamecomp.Remove(bonus);
                currentlive += Constant.singlelife;
                break;
            }
            if (bonus.kindbonus == NameBonus.Megapaddle)
            {
                Gamecomp.Remove(bonus);
                Paddle mega = new MegaPaddle(megapaddle, paddle.thePosition, Constant.originalpaddlewidth, Constant.originalpaddleheigth * 4);
                Gamecomp.Add(mega);
                Gamecomp.Remove(paddle);
                break;
            }
            if (bonus.kindbonus == NameBonus.Paddleplussize)
            {
                Gamecomp.Remove(bonus);
                Paddle newpaddle = new Paddle(thePaddle, paddle.thePosition, Constant.originalpaddlewidth * 2, Constant.originalpaddleheigth);
                Gamecomp.Add(newpaddle);
                Gamecomp.Remove(paddle);
                break;
            }
            if (bonus.kindbonus == NameBonus.Paddleplussize)
            {
                Gamecomp.Remove(bonus);
                Paddle newpaddle = new Paddle(thePaddle, paddle.thePosition, Constant.originalpaddlewidth * 2, Constant.originalpaddleheigth);
                Gamecomp.Add(newpaddle);
                Gamecomp.Remove(paddle);
                break;
            }
            if (bonus.kindbonus == NameBonus.Paddleminussize)
            {
                Gamecomp.Remove(bonus);
                Paddle newpaddle = new Paddle(thePaddle, paddle.thePosition, Constant.originalpaddlewidth, Constant.originalpaddleheigth);
                Gamecomp.Add(newpaddle);
                Gamecomp.Remove(paddle);
                break;
            }
            if (bonus.kindbonus == NameBonus.AddBall)
            {
                Gamecomp.Remove(bonus);
                Ball newBall = new Ball(theBall, theBallPosition, Constant.originalballsize, Constant.originalballsize,
                Constant.balldX, Constant.originalballdY);

                Gamecomp.Add(newBall);
                break;

                }
               }
              }
             }
            }
           }
          }
         }
        }
        private void Randombonus(Random gener, Vector2 position)
        {
            int number;
            number = gener.Next(7);
            if (number==1)
            {
                KindBonus(gener,position);
            }
        }
       
        private void KindBonus(Random gener,Vector2 position)
        {
            int kind = gener.Next(1,9);
            switch (kind)
            {
                case 1:
                    Bonus bon1 = new Bonus(bonusTexture1, position, Constant.bonuswidth, Constant.bonusheigth, 
                     Constant.bonusdY, NameBonus.Plusscore, true);

                    Gamecomp.Add(bon1);
                    break;
                case 2:
                    Bonus bon2 = new Bonus(bonusTexture2, position, Constant.bonuswidth, Constant.bonusheigth,
                     Constant.bonusdY, NameBonus.Minusscore, false);

                    Gamecomp.Add(bon2);
                    break;
                case 3:
                    Bonus bon3 = new Bonus(bonusTexture3, position, Constant.bonuswidth, Constant.bonusheigth,
                    Constant.bonusdY, NameBonus.Pluslife, true);

                    Gamecomp.Add(bon3);
                    break;
                case 4:
                    Bonus bon4 = new Bonus(bonusTexture4, position, Constant.bonuswidth, Constant.bonusheigth,
                    Constant.bonusdY, NameBonus.Minuslife, false);

                    Gamecomp.Add(bon4);
                    break;
                case 5:
                    Bonus bon5 = new Bonus(bonusTexture5, position, Constant.bonuswidth, Constant.bonusheigth,
                    Constant.bonusdY, NameBonus.AddBall,true);

                    Gamecomp.Add(bon5);
                    break;
                case 6:
                    Bonus bon6 = new Bonus(bonusTexture6, position, Constant.bonuswidth, Constant.bonusheigth,
                    Constant.bonusdY, NameBonus.Megapaddle, true);

                    Gamecomp.Add(bon6);
                    break;
                case 7:
                    Bonus bon7 = new Bonus(bonusTexture7, position, Constant.bonuswidth, Constant.bonusheigth,
                     Constant.bonusdY, NameBonus.Paddleplussize, true);

                    Gamecomp.Add(bon7);
                    break;
                case 8:
                    Bonus bon8 = new Bonus(bonusTexture8, position, Constant.bonuswidth, Constant.bonusheigth,
                     Constant.bonusdY, NameBonus.Paddleminussize, false);

                    Gamecomp.Add(bon8);
                    break;

            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);
            
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), null,
            Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);

            spriteBatch.DrawString(score, "Score: " + currentscore, new Vector2(10, 5), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.DrawString(live, "Live:" + currentlive, new Vector2(700, 5), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            spriteBatch.End();
            foreach (var item in Gamecomp)
            {
              item.Draw(spriteBatch);
            }
           
            
            base.Draw(gameTime);
        }
    }
}
