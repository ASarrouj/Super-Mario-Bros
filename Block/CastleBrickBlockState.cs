using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    class CastleBrickBlockState : BlockState, IBlockState
    {
        protected StaticSprite sprite;

        public CastleBrickBlockState(Block block) : base(block)
        {
            this.sprite = BlockSpriteFactory.Instance.CreateCastleBrickBlock();
            block.bumped = false;
        }

        public void BeHit(IPlayer player) { }

        public void BeBumped(IPlayer player) { }

        public void Update(GameTime gameTime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, block.Position);
        }
    }
}
