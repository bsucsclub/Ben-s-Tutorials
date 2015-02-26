using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted {
    public class PlayerControlledSprite : Sprite {
        public PlayerControlledSprite(Game game_, Texture2D texture_)
            : base(game_, texture_) {

        }

        int currentSourceX = 0;
        int elapsedMS = 0;
        Vector2 velocity = Vector2.One * 2;
        List<Vector2> previousPositions = new List<Vector2>();

        bool left = true;
        bool down = true;
        bool horizontal = true;

        /// <summary>
        /// Updates this sprite.
        /// </summary>
        /// <param name="gameTime_">Elapsed game time.</param>
        public override void Update(GameTime gameTime_) {
            // TO DO: Place update code here.
            source.X = currentSourceX * 40;

            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.A)) {
                left = true;
                horizontal = true;
            }
            else if (kState.IsKeyDown(Keys.D)) {
                left = false;
                horizontal = true;
            }

            else if (kState.IsKeyDown(Keys.W)) {
                down = false;
                horizontal = false;
            }
            else if (kState.IsKeyDown(Keys.S)) {
                down = true;
                horizontal = false;
            }

            if (elapsedMS > 25) {
                currentSourceX = (currentSourceX < 2) ? currentSourceX + 1 : 0;
                elapsedMS = gameTime_.ElapsedGameTime.Milliseconds;

                previousPositions.Add(position);
                if (previousPositions.Count > 10) {
                    previousPositions.RemoveAt(0);
                }

                if (horizontal) {
                    position.X += (left) ? -velocity.X : velocity.X;
                }
                else {
                    position.Y += (down) ? velocity.Y : -velocity.Y;
                }

                Viewport vp = game.GraphicsDevice.Viewport;
                if (position.X <= 0 || position.X + source.Width >= vp.Width) {
                    
                }
                if (position.Y <= 0 || position.Y + source.Height >= vp.Height) {
                    
                }
            }
            else {
                elapsedMS += gameTime_.ElapsedGameTime.Milliseconds;
            }
        }
        /// <summary>
        /// Draws this sprite.
        /// </summary>
        /// <param name="spriteBatch_">The SpriteBatch to draw with.</param>
        public override void Draw(SpriteBatch spriteBatch_) {
            // TO DO: Place draw code here.
            spriteBatch_.Draw(Texture, Position, Source, Color);

            for (int i = 0; i < previousPositions.Count; i++) {
                Color color = new Color(1f, 1f, 1f, (float)i / previousPositions.Count);
                spriteBatch_.Draw(Texture, previousPositions[i], Source, color);
            }
        }
    }
}
