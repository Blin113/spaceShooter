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
    class Player
    {
        Texture2D ship;
        Vector2 shipPos = new Vector2(100, 100);

        Texture2D laser;

        public Player(Texture2D ship, Vector2 shipPos, Texture2D laser)
        {
            this.ship = ship;
            this.laser = laser;
            this.shipPos = shipPos;
        }

        public void Update()
        {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                shipPos.Y -= 3;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                shipPos.X -= 3;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                shipPos.Y += 3;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                shipPos.X += 3;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Shoot();
            }
        }

        public void Shoot()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ship, new Rectangle((int)shipPos.X, (int)shipPos.Y, 50, 50), Color.White);
        }
    }
}
