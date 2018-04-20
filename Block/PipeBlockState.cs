using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftVerticalPipeBlockState : BlockState, IBlockState
    {
        protected StaticSprite sprite;

        public LeftVerticalPipeBlockState(Block block) : base(block)
        {
            this.sprite = PipeSpriteFactory.Instance.CreateLeftVerticalPipeSprite();
        }

        public void BeHit(IPlayer player) { }
        public void BeBumped(IPlayer player) { }
        public void Update(GameTime gameTime) { }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, block.Position);
        }
    }

    class RightVerticalPipeBlockState : BlockState, IBlockState
    {
        protected StaticSprite sprite;

        public RightVerticalPipeBlockState(Block block) : base(block)
        {
            this.sprite = PipeSpriteFactory.Instance.CreateRightVerticalPipeSprite();
        }

        public void BeHit(IPlayer player) { }
        public void BeBumped(IPlayer player) { }
        public void Update(GameTime gameTime) { }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, block.Position);
        }
    }

    class TopHorizontalPipeBlockState : BlockState, IBlockState
    {
        protected StaticSprite sprite;

        public TopHorizontalPipeBlockState(Block block) : base(block)
        {
            this.sprite = PipeSpriteFactory.Instance.CreateTopHorizontalPipeSprite();
        }

        public void BeHit(IPlayer player) { }
        public void BeBumped(IPlayer player) { }
        public void Update(GameTime gameTime) { }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, block.Position);
        }
    }

    class BottomHorizontalPipeBlockState : BlockState, IBlockState
    {
        protected StaticSprite sprite;

        public BottomHorizontalPipeBlockState(Block block) : base(block)
        {
            this.sprite = PipeSpriteFactory.Instance.CreateBottomHorizontalPipeSprite();
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
