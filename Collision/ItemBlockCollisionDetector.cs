using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class ItemBlockCollisionDetector
    {
        private Rectangle ItemRectangle, BlockRectangle, IntersectRectangle;

        public ICollision collisionSide;
        private ItemBlockCollisionHandler collisionHandler;

        public ItemBlockCollisionDetector()
        {
            collisionHandler = new ItemBlockCollisionHandler();
        }

        public void DetectCollision(Item item, Block block)
        {
            if (!item.Boxed) {

                ItemRectangle = item.CollisionRectangle;
                BlockRectangle = block.CollisionRectangle;

                if (ItemRectangle.Intersects(BlockRectangle))
                {
                    IntersectRectangle = Rectangle.Intersect(ItemRectangle, BlockRectangle);

                    if (IntersectRectangle.Height > IntersectRectangle.Width)
                    {
                        if (ItemRectangle.X > BlockRectangle.X) collisionSide = new LeftCollision(IntersectRectangle);
                        else collisionSide = new RightCollision(IntersectRectangle);
                    }
                    else
                    {
                        if (ItemRectangle.Y > BlockRectangle.Y) collisionSide = new TopCollision(IntersectRectangle);
                        else collisionSide = new BottomCollision(IntersectRectangle);
                    }

                    collisionHandler.HandleCollision(item, block, collisionSide);
                }

            }
        }

        public void Update(Item item, Block block)
        {
            DetectCollision(item, block);
        }
    }
}