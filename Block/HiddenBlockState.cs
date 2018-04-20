using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    class HiddenBlockState : BlockState, IBlockState
    {
        private Queue<Item> items;

        public HiddenBlockState(Block block, Queue<Item> items) : base(block) {
            this.items = items;
        }

        public void BeHit(IPlayer player)
        {
            if (items.Count > 0) items.Dequeue().Unbox(player);
            if (items.Count == 0) block.State = new UsedBlockState(block);
        }

        public void BeBumped(IPlayer player) { }

        public void Update(GameTime gameTime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
    }
}
