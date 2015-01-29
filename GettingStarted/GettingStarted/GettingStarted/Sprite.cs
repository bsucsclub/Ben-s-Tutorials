using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GettingStarted {
    /// <summary>
    /// A basic 2D sprite that can be updated and drawn.
    /// </summary>
    public class Sprite {
        /// <summary>
        ///  Creates a sprite instance.
        /// </summary>
        /// <param name="texture_"></param>
        public Sprite(Texture2D texture_) {
            texture = texture_;
        }

        #region Members
        protected Texture2D texture;
        protected Vector2 position = Vector2.Zero;
        protected Rectangle source = Rectangle.Empty;
        protected Color color = Color.White;
        protected float angle = 0.0f;
        protected Vector2 origin = Vector2.Zero;
        protected Vector2 scale = Vector2.One;
        protected SpriteEffects effects = SpriteEffects.None;
        protected float drawDepth = 0.0f;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the texture that represents this sprite.
        /// </summary>
        public Texture2D Texture {
            get {
                return texture;
            }
            set {
                texture = value;
            }
        }
        /// <summary>
        /// Gets or sets the position of this sprite.
        /// </summary>
        public Vector2 Position {
            get {
                return position;
            }
            set {
                position = value;
            }
        }
        /// <summary>
        /// Gets or sets the horizontal position of this sprite.
        /// </summary>
        public float X {
            get {
                return position.X;
            }
            set {
                position.X = value;
            }
        }
        /// <summary>
        /// Gets or sets the vertical position of this sprite.
        /// </summary>
        public float Y {
            get {
                return position.Y;
            }
            set {
                position.Y = value;
            }
        }
        /// <summary>
        /// Gets or sets the source rectangle of this sprite.
        /// </summary>
        public Rectangle Source {
            get {
                return source;
            }
            set {
                source = value;
            }
        }
        /// <summary>
        /// Gets or sets the color to tint this sprite when drawn.
        /// </summary>
        public Color Color {
            get {
                return color;
            }
            set {
                color = value;
            }
        }
        /// <summary>
        /// Gets or sets the angle to rotate this sprite in radians.
        /// </summary>
        public float Angle {
            get {
                return angle;
            }
            set {
                angle = value;
            }
        }
        /// <summary>
        /// Gets or sets the origin of rotation for this sprite.
        /// </summary>
        public Vector2 Origin {
            get {
                return origin;
            }
            set {
                origin = value;
            }
        }
        /// <summary>
        /// Gets or sets the scale factor to use when drawing this sprite.
        /// </summary>
        public Vector2 Scale {
            get {
                return scale;
            }
            set {
                scale = value;
            }
        }
        /// <summary>
        /// Gets or sets any sprite effects to be used while drawing this sprite.
        /// </summary>
        public SpriteEffects Effects {
            get {
                return effects;
            }
            set {
                effects = value;
            }
        }
        /// <summary>
        /// Gets or sets the distance from the screen to use when drawing this sprite. 
        /// Range: [0, 1] where 0 is closest to the screen and 1 is furthest from the screen.
        /// </summary>
        public float DrawDepth {
            get {
                return drawDepth;
            }
            set {
                drawDepth = value;
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Centers the origin of rotation within the texture for this sprite.
        /// </summary>
        public void CenterOrigin() {
            if (source == null) {
                origin = new Vector2(source.Value.Width / 2.0f, source.Value.Height / 2.0f);
            }
            else {
                origin = new Vector2(texture.Width / 2.0f, texture.Height / 2.0f);
            }
        }
        /// <summary>
        /// Checks to see if the coordinate lies within this sprite's bounds.
        /// </summary>
        /// <param name="x_">The horizontal coordinate.</param>
        /// <param name="y_">The vertical coordinate.</param>
        /// <returns>true if the coordinate lies with the bounds; otherwise false.</returns>
        public virtual bool Contains(float x_, float y_) {
            Vector2 lowerRight = position;
            if (source == null) {
                lowerRight += (scale.Equals(Vector2.One)) ? new Vector2(texture.Width, texture.Height) : scale * new Vector2(texture.Width, texture.Height);
            }
            else {
                lowerRight += (scale.Equals(Vector2.One)) ? new Vector2(source.Value.Width, source.Value.Height) : scale * new Vector2(source.Value.Width, source.Value.Height);
            }

            return (x_ >= position.X && x_ <= lowerRight.X) && (y_ >= position.Y && y_ <= lowerRight.Y);    
        }
        /// <summary>
        /// Checks to see if the coordinate lies within this sprite's bounds.
        /// </summary>
        /// <param name="location_">The coordiante.</param>
        /// <returns>true if the coordinate lies within the bounds; otherwise false.</returns>
        public virtual bool Contains(Vector2 location_) {
            return Contains(location_.X, location_.Y);
        }
        #endregion


        int currentSourceX = 0;
        int currentSourceY = 0;
        /// <summary>
        /// Updates this sprite.
        /// </summary>
        /// <param name="gameTime_">Elapsed game time.</param>
        public virtual void Update(GameTime gameTime_) {
            // TO DO: Place update code here.
            source.X = currentSourceX * 40;
        }
        /// <summary>
        /// Draws this sprite.
        /// </summary>
        /// <param name="spriteBatch_">The SpriteBatch to draw with.</param>
        public virtual void Draw(SpriteBatch spriteBatch_) {
            // TO DO: Place draw code here.
            spriteBatch_.Draw(Texture, Position, Source, Color);
        }
    }
}
