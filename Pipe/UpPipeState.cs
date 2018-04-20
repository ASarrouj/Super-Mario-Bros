using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class UpPipeState : PipeState, IPipeState
    {
        protected StaticSprite sprite;

        public UpPipeState(Pipe pipe) : base(pipe, new Point(0x20, 0x10))
        {
            sprite = PipeSpriteFactory.Instance.CreateUpPipeSprite();
        }

        public void Update(GameTime gameTime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, pipe.Position);
        }
    }
}
