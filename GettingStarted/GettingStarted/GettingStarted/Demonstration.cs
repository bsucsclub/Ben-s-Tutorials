using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GettingStarted {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Demonstration : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        List<Sprite> sprites = new List<Sprite>();

        Texture2D casperTexture;

        int score = 0;

        public void IncrementScore() {

        }
        public void GameOver() {
            Sprite bouncer = new BouncingSprite(this, casperTexture);
            bouncer.Source = new Rectangle(0, 0, 40, 52);
        }

        public Demonstration() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TO DO: Load content here.
            font = Content.Load<SpriteFont>("font");
            casperTexture = Content.Load<Texture2D>("Ghost");
            Sprite casper = new PlayerControlledSprite(this, casperTexture);
            casper.Source = new Rectangle(0, 0, 40, 52);
            sprites.Add(casper);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                this.Exit();
            }

            // TO DO: Update here
            for (int i = 0; i < sprites.Count; i++) {
                sprites[i].Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TO DO: Draw here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);

            for (int i = 0; i < sprites.Count; i++) {
                sprites[i].Draw(spriteBatch);
            }
            spriteBatch.End();

            // Print Score
            spriteBatch.Begin();
            spriteBatch.DrawString(
                font, 
                string.Format("Score: {0}", score), 
                Vector2.Zero, 
                Color.Black
            );
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
