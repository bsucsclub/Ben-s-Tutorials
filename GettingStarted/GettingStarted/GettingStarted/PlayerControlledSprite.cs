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

        public int CurrentSize {
            get {
                return currentSize;
            }
            set {
                currentSize = value;
            }
        }
        public Vector2 Velocity {
            get {
                return velocity;
            }
            set {
                velocity = value;
            }
        }

        int currentSize = 25;
        int currentSourceX = 0;
        int elapsedMS = 0;
        Vector2 velocity = Vector2.One * 2;
        List<Vector2> previousPositions = new List<Vector2>();

        bool left = true;
        bool down = true;
        bool horizontal = true;
        bool isGameOver = false;

        public void CheckCollisions() {
            for (int i = 0; i < previousPositions.Count - 25; i++) {
                var pos = previousPositions[i];
                if (Contains(pos.X, pos.Y) || Contains(pos.X + source.Width, pos.Y) || Contains(pos.X, pos.Y + source.Height) ||
                    Contains(pos.X + source.Width, pos.Y + source.Height)) {
                    ((Demonstration)game).GameOver();
                    isGameOver = true;
                }
                var t = Position;
            }
        }

        /// <summary>
        /// Updates this sprite.
        /// </summary>
        /// <param name="gameTime_">Elapsed game time.</param>
        public override void Update(GameTime gameTime_) {
            if (isGameOver) {
                return;
            }

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
                if (previousPositions.Count > currentSize) {
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
                    ((Demonstration)game).GameOver();
                    isGameOver = true;
                }
                if (position.Y <= 0 || position.Y + source.Height >= vp.Height) {
                    ((Demonstration)game).GameOver();
                    isGameOver = true;
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
            if (isGameOver) {
                return;
            }
            // TO DO: Place draw code here.
            spriteBatch_.Draw(Texture, Position, Source, Color);

            for (int i = 0; i < previousPositions.Count; i++) {
                Color color = new Color(1f, 1f, 1f, (float)i / previousPositions.Count);
                spriteBatch_.Draw(Texture, previousPositions[i], Source, color);
            }
        }
    }
}
