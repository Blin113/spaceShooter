using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D space;
        

        Player player;
        Texture2D ship;
        Vector2 shipPos = new Vector2(350, 320);
        Texture2D laser;

        List<Vector2> beams = new List<Vector2>();

        Enemy enemy;
        Texture2D eShip;
        Vector2 eShipPos;
        Rectangle enemyRectangle;
        List<Enemy> enemies = new List<Enemy>();
        Random rnd = new Random();

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            space = Content.Load<Texture2D>("space");
            ship = Content.Load<Texture2D>("ship");
            eShip = Content.Load<Texture2D>("enemy ship");
            laser = Content.Load<Texture2D>("Laser");

            player = new Player(ship, shipPos, beams);
            enemy = new Enemy(eShip, eShipPos, enemyRectangle);
            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            player.Update();
            enemy.Update();

            for (int i = 0; i < beams.Count; i++)
            {
                beams[i] = beams[i] - new Vector2(0, 7);

                if (beams[i].Y < -50)
                {
                    beams.Remove(beams[i]);
                    i--;
                }
            }

            if(rnd.Next(100) < 1)
            {
                eShipPos.X = rnd.Next(0, 700);
                enemyRectangle = new Rectangle((int)eShipPos.X, (int)eShipPos.Y, 100, 100);
                enemies.Add(new Enemy(eShip, eShipPos, enemyRectangle));
            }
            
            for (int i = 0; i < enemies.Count; i++)
            {
                if(enemyRectangle.Location.Y < 480)
                {
                    enemyRectangle.Location.Y = eShipPos.ToPoint();
                }

                if (eShipPos.Y > 480)
                {
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here.

            spriteBatch.Begin();

            spriteBatch.Draw(space, new Rectangle(0, 0, 800, 480), Color.White);

            player.Draw(spriteBatch);

            foreach (var item in enemies)
            {
                item.Draw(spriteBatch);
            }

            foreach(Vector2 beams in beams)
            {
                Rectangle rec = new Rectangle();
                rec.Location = beams.ToPoint();
                rec.Size = new Point(40, 40);
                spriteBatch.Draw(laser, rec, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}