using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class CrackedBlockState : BlockState, IBlockState
    {
        protected StaticSprite sprite;

        public CrackedBlockState(Block block) : base(block)
        {
            this.sprite = BlockSpriteFactory.Instance.CreateCrackedBlock();
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
