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
    abstract class GameComponent
    {
        public Texture2D theTexture;
        public Vector2 thePosition;
        public Rectangle rect;
        
        public GameComponent(Texture2D theTexture, Vector2 thePosition, int width ,int height )
        {
            this.theTexture = theTexture;
            this.thePosition = thePosition;
            rect = new Rectangle((int)thePosition.X,(int)thePosition.Y, width, height);

        }
        public int GetWidth()
        {
            return rect.Width;
        }

        public int GetHeight()
        {
            return rect.Height;
        }
        public Vector2 PositionOn()
        {
            return this.thePosition;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(theTexture, rect , Color.White);
            spriteBatch.End();
        }
    }
}