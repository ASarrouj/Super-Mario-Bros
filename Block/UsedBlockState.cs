using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class UsedBlockState : BlockState, IBlockState
    {
        protected StaticSprite sprite;

        public UsedBlockState(Block block) : base(block)
        {
            this.sprite = BlockSpriteFactory.Instance.CreateUsedBlock();
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
