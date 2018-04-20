using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    class UndergroundBrickBlockState : BlockState, IBlockState
    {
        protected StaticSprite sprite;

        private Queue<Item> items;

        public UndergroundBrickBlockState(Block block, Queue<Item> items) : base(block)
        {
            this.sprite = BlockSpriteFactory.Instance.CreateUndergroundBrickBlock();
            this.items = items;
            block.bumped = false;
        }

        public void BeHit(IPlayer player)
        {
            BeBumped(player);
            if (items.Count == 0)
            {
                block.State = new BrokenBlockState(block);
                SoundFactory.Instance.CreateBreakBlockSound().Play();
            }
        }

        public void BeBumped(IPlayer player) {
            if (items.Count > 0) items.Dequeue().Unbox(player);
            block.bumped = true;
            block.Position = new Point(block.Position.X, block.Position.Y - 4);
            SoundFactory.Instance.CreateBumpSound().Play();
        }

        public void Update(GameTime gameTime) {
            if(block.bumped)
            {
                block.bumped = false;
                block.Position = new Point(block.Position.X, block.Position.Y + 4);
            }
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, block.Position);
        }
    }
}
