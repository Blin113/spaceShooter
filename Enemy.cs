using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Enemy : BaseClass
    {
        private Rectangle enemyRectangle;

        public Enemy(Texture2D texture, Vector2 texturePos) :base(texture, texturePos)
        {

        }

        public override void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, enemyRectangle, Color.White);
        }
    }
}
