using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Player : BaseClass
    {
        List<Vector2> beam;

        KeyboardState oldKState;

        public Player(Texture2D texture, Vector2 texturePos, List<Vector2> beams) : base(texture, texturePos)
        {
            beam = beams;
        }

        public override void Update()
        {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                texturePos.Y -= 4;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                texturePos.X -= 4;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                texturePos.Y += 4;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                texturePos.X += 4;
            }

            if (texturePos.X <= 0)
            {
                texturePos.X = 0;
            }
            if (texturePos.X >= 700)
            {
                texturePos.X = 700;
            }
            if (texturePos.Y <= 0)
            {
                texturePos.Y = 0;
            }
            if (texturePos.Y >= 380)
            {
                texturePos.Y = 380;
            }


            if (kstate.IsKeyDown(Keys.Space) && oldKState.IsKeyUp(Keys.Space))
            {
                Shoot();
            }

            oldKState = kstate;
        }

        public void Shoot()
        {
            beam.Add(texturePos + new Vector2(30, 0));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)texturePos.X, (int)texturePos.Y, 100, 100), Color.White);
        }
    }
}
