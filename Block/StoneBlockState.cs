using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StoneBlockState : BlockState, IBlockState
    {
        protected StaticSprite sprite;

        public StoneBlockState(Block block) : base(block)
        {
            this.sprite = BlockSpriteFactory.Instance.CreateStoneBlock();
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
