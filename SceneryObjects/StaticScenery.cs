using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    abstract class StaticScenery
    {
        protected Scenery scenery;

        protected StaticSprite sprite;

        protected StaticScenery(Scenery scenery, StaticSprite sprite)
        {
            this.scenery = scenery;
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, scenery.Position);
        }
    }
}
