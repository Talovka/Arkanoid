using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlternativeArkanoid
{
    class Ball:GameComponent
    {
        Boolean active { get; set; }
        public float dX { get; set; }
        public float dY { get; set; }
        
        public Ball(Texture2D theTexture, Vector2 thePosition, int width, int height,float dX, float dY): base(theTexture, thePosition, width, height)
        {
            this.active = true;
            this.dX = dX;
            this.dY = dY;
            this.rect.Width = width;
            this.rect.Height = height;

        }

        public void Update(GameTime gametime)
        {
            thePosition.X += dX;
            rect.X += (int)dX;
            thePosition.Y += dY;
            rect.Y += (int)dY;
            
        }
        
        public void setInactive()
        {
            this.active = false;
        }

        public Boolean isActive()
        {
            return this.active;
        }
      
        public Rectangle BallRectL
        {
            get
            {
                return new Rectangle(rect.X, rect.Y, Constant.singlesize, rect.Height-Constant.singlesize);
            }
        }
        public Rectangle BallRectR
        {
            get
            {
                return new Rectangle(rect.X + rect.Width - Constant.singlesize, rect.Y, Constant.singlesize, rect.Height - Constant.singlesize);
            }
        }
        public Rectangle BallRectB
        {
            get
            {
                return new Rectangle(rect.X, rect.Y-Constant.singlesize+rect.Height, rect.Width, Constant.singlesize);
            }
        }
        public Rectangle BallRectT
        {
            get
            {
                return new Rectangle(rect.X, rect.Y, rect.Width , Constant.singlesize);
            }
        }
    }
}
