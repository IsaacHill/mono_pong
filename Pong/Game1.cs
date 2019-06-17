using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private Sprite _ball1;
        private Sprite _ball2;
        Vector2 ballSpeed;
        float ballMultiplier;
      

        Texture2D pingTexture;
        Vector2 pingPosition;
        float pingSpeed;

        Texture2D pongTexture;
        Vector2 pongPosition;
        float pongSpeed;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Color background;
        Rectangle playSpace;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            background = Color.Beige;
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
            playSpace = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); //offset dont understand why.
            _ball1 = new Sprite(new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2), playSpace, Color.White,0f,Vector2.One, new Vector2(100f, 0f), 1.5f);
            _ball2 = new Sprite(new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight / 2), playSpace, Color.White, 0f, Vector2.One, new Vector2(-100f, 0f), 1.5f);
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

            // TODO: use this.Content to load your game content here
            _ball1.LoadContent(Content.Load<Texture2D>("ball"));
            _ball2.LoadContent(Content.Load<Texture2D>("ball"));
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

            if (_ball1.Update(gameTime,_ball2) || _ball2.Update(gameTime, _ball1))
            {
                background = Color.Red;
            } else
            {
                background = Color.Beige;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(background);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            _ball1.Draw(spriteBatch);
            _ball2.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
