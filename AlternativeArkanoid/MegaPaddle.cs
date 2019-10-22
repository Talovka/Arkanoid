using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeArkanoid
{
    class MegaPaddle : Paddle
    {
        public MegaPaddle(Texture2D theTexture, Vector2 thePosition, int width, int height) : base(theTexture, thePosition, width, height)
        {

        }

        public override Rectangle PaddleRectT1
        {
            get
            {
                return new Rectangle(rect.X, rect.Y, rect.Width / 10, rect.Height);
            }
        }

        public override Rectangle PaddleRectT2
        {
            get
            {
                return new Rectangle(rect.X + rect.Width / 10, rect.Y + 2*rect.Height/3, rect.Width / 5, rect.Height/3);
            }

        }

        public override Rectangle  PaddleRectT3
        {
            get
            {
                return new Rectangle(rect.X + (3 * (rect.Width / 10)), rect.Y + 2 * rect.Height / 3, 2*rect.Width / 5, Constant.singlesize);
            }

        }

        public override Rectangle PaddleRectT4
        {
            get
            {
                return new Rectangle(rect.X + (7 * (rect.Width / 10)), rect.Y + 2 * rect.Height / 3, rect.Width / 5, Constant.singlesize);
            }

        }

        public override Rectangle PaddleRectT5
        {
            get
            {
                return new Rectangle(rect.X + (9 * (rect.Width / 10)), rect.Y, rect.Width / 10, rect.Height);
            }

        }

        public override Rectangle PaddleRectL
        {
            get
            {
                return new Rectangle(rect.X, rect.Y, Constant.singlesize*10, rect.Height);
            }

        }

        public override Rectangle PaddleRectR
        {
            get
            {
                return new Rectangle(rect.X + rect.Width - Constant.singlesize*10, rect.Y, Constant.singlesize*10, rect.Height);
            }
        }
    }
}
