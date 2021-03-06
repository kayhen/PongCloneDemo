using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongCloneDemo
{
    public abstract class Sprite
    {
        protected Texture2D texture;
        public Vector2 Location;
        protected Rectangle gameBoundaries;

        public int Width
        {
            get { return texture.Width; }
        }

        public int Height
        {
            get { return texture.Height; }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
            }
        }

        public Vector2 Velocity { get; protected set; }

        public Sprite(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
        {
            this.texture = texture;
            Location = location;
            this.gameBoundaries = gameBoundaries;
            Velocity = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Location = Location + Velocity;

            checkBounds();
        }

        protected abstract void checkBounds();
    }
}