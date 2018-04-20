using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class ItemPipeCollisionDetector
    {
        private Rectangle ItemRectangle, PipeRectangle, IntersectRectangle;

        public ICollision collisionSide;
        private ItemPipeCollisionHandler collisionHandler;

        public ItemPipeCollisionDetector()
        {
            collisionHandler = new ItemPipeCollisionHandler();
        }

        public void DetectCollision(Item item, Pipe pipe)
        {
            ItemRectangle = item.CollisionRectangle;
            PipeRectangle = pipe.CollisionRectangle;

            if (ItemRectangle.Intersects(PipeRectangle))
            {
                IntersectRectangle = Rectangle.Intersect(ItemRectangle, PipeRectangle);

                if (IntersectRectangle.Height > IntersectRectangle.Width)
                {
                    if (ItemRectangle.X > PipeRectangle.X) collisionSide = new LeftCollision(IntersectRectangle);
                    else collisionSide = new RightCollision(IntersectRectangle);
                }
                else
                {
                    if (ItemRectangle.Y > PipeRectangle.Y) collisionSide = new TopCollision(IntersectRectangle);
                    else collisionSide = new BottomCollision(IntersectRectangle);
                }

                collisionHandler.HandleCollision(item, pipe, collisionSide);
            }
        }

        public void Update(Item item, Pipe pipe)
        {
            DetectCollision(item, pipe);
        }
    }
}