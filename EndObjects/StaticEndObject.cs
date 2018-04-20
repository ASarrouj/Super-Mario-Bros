using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class StaticEndObject
    {
        protected EndObject endObject;

        protected StaticSprite sprite;

        protected StaticEndObject(EndObject endObject, StaticSprite sprite)
        {
            this.endObject = endObject;
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, endObject.Position);
        }
    }
}
