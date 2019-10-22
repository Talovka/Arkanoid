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
    class Paddle:GameComponent
    {
        
        public Paddle(Texture2D theTexture, Vector2 thePosition,int width, int height) : base(theTexture, thePosition, width, height)
        {
            
        }
        
        public virtual Rectangle PaddleRectT1
        {
            get
            {
                return new Rectangle(rect.X, rect.Y, rect.Width / 5, Constant.singlesize);
            }
        }

        public virtual Rectangle PaddleRectT2
        {
            get
            {
                return new Rectangle(rect.X+ rect.Width / 5, rect.Y, rect.Width / 5, Constant.singlesize);
            }

        }

        public virtual Rectangle PaddleRectT3
        {
            get
            {
                return new Rectangle(rect.X+ (2 * (rect.Width / 5)), rect.Y, rect.Width / 5, Constant.singlesize);
            }

        }

        public virtual Rectangle PaddleRectT4
        {
            get
            {
                return new Rectangle(rect.X+(3 * (rect.Width / 5)), rect.Y, rect.Width / 5, Constant.singlesize);
            }

        }

        public virtual Rectangle PaddleRectT5
        {
            get
            {
                return new Rectangle(rect.X + (4 * (rect.Width / 5)), rect.Y, rect.Width / 5, Constant.singlesize);
            }

        }

        public virtual Rectangle PaddleRectL
        {
            get
            {
                return new Rectangle(rect.X, rect.Y, Constant.singlesize, rect.Height);
            }

        }

        public virtual Rectangle PaddleRectR
        {
            get
            {
                return new Rectangle(rect.X + rect.Width - Constant.singlesize, rect.Y, Constant.singlesize, rect.Height);
            }
        }
             public Rectangle PaddleRect
         {
            get
            {
                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            }
        }

    }
}
