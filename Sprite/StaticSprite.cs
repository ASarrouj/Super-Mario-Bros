using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class StaticSprite
    {
        protected Texture2D texture;

        protected Rectangle source;

        protected SpriteEffects effects;

        protected Point offset;

        public StaticSprite(Texture2D texture, Rectangle source, SpriteEffects effects = SpriteEffects.None)
            : this(texture, source, Point.Zero, effects) { }

        public StaticSprite(Texture2D texture, Rectangle source, Point offset, SpriteEffects effects = SpriteEffects.None)
        {
            this.texture = texture;
            this.source = source;
            this.offset = offset;
            this.effects = effects;
        }

        public void Draw(SpriteBatch batch, Point position)
        {
            this.Draw(batch, position, Color.White);
        }

        public void Draw(SpriteBatch batch, Point position, Color color)
        {
            batch.Draw(texture, new Rectangle(position + offset, source.Size), source, color, 0.0f, Vector2.Zero, effects, 0);
        }
    }
}
