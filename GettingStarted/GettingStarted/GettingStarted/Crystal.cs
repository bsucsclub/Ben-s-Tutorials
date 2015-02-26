using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted {
    public class Crystal : Sprite {
        public Crystal(Game game_, Texture2D texture_)
            : base(game_, texture_) {

        }
        int currentSourceX = 0;
        int elapsedMS = 0;
        /// <summary>
        /// Updates this sprite.
        /// </summary>
        /// <param name="gameTime_">Elapsed game time.</param>
        public override void Update(GameTime gameTime_) {
            // TO DO: Place update code here.
            source.X = currentSourceX * 32;

            if (elapsedMS > 50) {
                currentSourceX = (currentSourceX < 9) ? currentSourceX + 1 : 0;
                elapsedMS = gameTime_.ElapsedGameTime.Milliseconds;
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
        }
    }
}
