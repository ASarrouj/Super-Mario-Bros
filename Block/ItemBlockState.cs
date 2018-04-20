using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    class ItemBlockState : BlockState, IBlockState
    {
        protected AnimatedSprite sprite;

        private Queue<Item> items;

        public ItemBlockState(Block block, Queue<Item> items) : base(block)
        {
            this.sprite = BlockSpriteFactory.Instance.CreateItemBlock();
            this.items = items;
        }

        public void BeHit(IPlayer player)
        {
            if (items.Count > 0) items.Dequeue().Unbox(player);
            if (items.Count == 0) block.State = new UsedBlockState(block); 
        }

        public void BeBumped(IPlayer player) { }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, block.Position);
        }
    }
}
