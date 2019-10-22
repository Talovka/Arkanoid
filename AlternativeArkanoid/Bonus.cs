using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AlternativeArkanoid.Enums;

namespace AlternativeArkanoid
{

    class Bonus:GameComponent
    {
        
        public float dY { get; set; }
        public NameBonus kindbonus { get; set; }
        public bool typebonus;

        public Bonus(Texture2D theTexture, Vector2 thePosition, int width, int height, float dY,NameBonus kindbonus, bool typebonus): base(theTexture, thePosition, width, height)
        {
            this.kindbonus = kindbonus;
            this.typebonus = typebonus;
            this.dY = dY; 
            
        }

        public void Update(GameTime gametime)
        {
            rect.Y = rect.Y + (int)dY;
            dY = dY;
        }
        public void ItPositive()
        {
            this.typebonus = true;
        }
        public void ItNegative()
        {
            this.typebonus = false;
        }
        public bool Condition()
        {
            return this.typebonus;
        }   
    }
}
