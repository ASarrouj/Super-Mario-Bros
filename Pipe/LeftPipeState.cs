using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftPipeState : PipeState, IPipeState
    {
        protected StaticSprite sprite;

        public LeftPipeState(Pipe pipe) : base(pipe, new Point(0x10, 0x20))
        {
            sprite = PipeSpriteFactory.Instance.CreateLeftPipeSprite();
        }
        public void Update(GameTime gameTime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, pipe.Position);
        }
    }
}
