using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted {
    class BouncingSprite : Sprite {
        public BouncingSprite(Game game_, Texture2D texture_)
            : base(game_, texture_) {

        }

        int currentSourceX = 0;
        int elapsedMS = 0;
        Vector2 velocity = Vector2.One * 50;
        List<Vector2> previousPositions = new List<Vector2>();

        /// <summary>
        /// Updates this sprite.
        /// </summary>
        /// <param name="gameTime_">Elapsed game time.</param>
        public override void Update(GameTime gameTime_) {
            // TO DO: Place update code here.
            source.X = currentSourceX * 40;

            if (elapsedMS > 25) {
                currentSourceX = (currentSourceX < 2) ? currentSourceX + 1 : 0;
                elapsedMS = gameTime_.ElapsedGameTime.Milliseconds;

                previousPositions.Add(position);
                if (previousPositions.Count > 100) {
                    previousPositions.RemoveAt(0);
                }

                position += velocity;

                Viewport vp = game.GraphicsDevice.Viewport;
                if (position.X <= 0 || position.X + source.Width >= vp.Width) {
                    velocity.X *= -1;
                }
                if (position.Y <= 0 || position.Y + source.Height >= vp.Height) {
                    velocity.Y *= -1;
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
