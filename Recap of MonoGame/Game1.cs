using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Recap_of_MonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator;

        List<Texture2D> shipTextures;

        Rectangle window;
        Texture2D backgroundTexture;

        Texture2D shipTexture;
        Rectangle shipRect;

        SpriteFont titleFont;

        float angle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "Content Scaling and Text";
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            generator = new Random();
            shipTextures = new List<Texture2D>();

            angle = 1.5f;

            shipRect = new Rectangle(generator.Next(window.Width-75), generator.Next(window.Height-100), 75, 100);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            backgroundTexture = Content.Load<Texture2D>("Images/space_background");
            for (int i = 1; i <= 5; i++)
                shipTextures.Add(shipTexture = Content.Load<Texture2D>("Images/enterprise_" + i));

            shipTexture = shipTextures[generator.Next(shipTextures.Count)];

            titleFont = Content.Load<SpriteFont>("Fonts/Titlefont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, window, Color.White);
            _spriteBatch.DrawString(titleFont, "Space", new Vector2(300, 10), Color.HotPink);
            _spriteBatch.Draw(shipTexture, shipRect, null,  Color.White * 0.5f, angle, new Vector2(shipTexture.Width());

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
