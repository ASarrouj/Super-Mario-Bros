using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    abstract class BlockState
    {
        protected Block block;

        public Point Size {  get { return ConstantValues.BLOCK_SIZE; } }

        public Rectangle CollisionRectangle { get { return new Rectangle(block.Position, Size); } }

        protected BlockState(Block block)
        {
            this.block = block;
        }
    }
}