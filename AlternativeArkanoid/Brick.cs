using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlternativeArkanoid.Enums;

namespace AlternativeArkanoid
{
    class Brick:GameComponent
    {
        Boolean visible { get; set; }

        Boolean hit { get; set; }

        bool movingbrick { get; set; }

        public float dY { get; set; }

        public float dX { get; set; }

        public ColorBrick kindbrick { get; set; }

        public int brickvalue;

        public Brick(Texture2D theTexture, Vector2 thePosition, bool movingbrick , int width, int height, float dY,float dX,ColorBrick kindbrick) : base(theTexture, thePosition, width, height)
        {
            this.movingbrick = movingbrick;
            this.visible = true;
            this.hit = false;
            this.dY = dY;
            this.dX = dX;
            this.kindbrick = kindbrick;
        }
        
        public void brickHit()
        {
            this.visible = false;
        }
        
        public bool isMoving()
        {
            return this.movingbrick;
        }
        public void brickWasHit()
        {
            this.hit = true;
        }
        public Boolean isVisible()
        {
            return this.visible;
        }

        public Boolean isHit()
        {
            return this.hit;
        }

        public void UpdatedX(GameTime gametime)
        {
            rect.X = rect.X + (int)dX;
            dX = dX;
            thePosition.X += dX;
        }
        public void UpdatedY(GameTime gametime)

        {
            rect.Y = rect.Y + (int)dY;
            dY = dY;

        }
        public int ScorePlusValue()
        {
            if (kindbrick == ColorBrick.Red)
            {
                brickvalue = 10;
                
            }
            if (kindbrick == ColorBrick.Blue)
            {
                 brickvalue = 20;
            }
            if (kindbrick == ColorBrick.Azure)
            {
                 brickvalue = 30;
            }
            if (kindbrick == ColorBrick.Purple)
            {
                brickvalue = 40;
            }
            if (kindbrick == ColorBrick.Green)
            {
                brickvalue = 50;
            }
            return brickvalue;
        }
        public Rectangle BrickRectL
        {
            get
            {
                return new Rectangle(rect.X, rect.Y, Constant.singlesize, rect.Height-Constant.singlesize);
            }
        }
        public Rectangle BrickRectR
        {
            get
            {
                return new Rectangle(rect.X + rect.Width - Constant.singlesize, rect.Y, Constant.singlesize, rect.Height-Constant.singlesize);
            }
        }
        public Rectangle BrickRectT
        {
            get
            {
                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            }
        }
        public Rectangle BrickRectB
        {
            get
            {
                return new Rectangle(rect.X, rect.Y - Constant.singlesize + rect.Height, rect.Width, Constant.singlesize);
            }
        }
    }
}
