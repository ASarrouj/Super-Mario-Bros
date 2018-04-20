using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerItemCollisionDetector
    {
        private Rectangle playerRectangle, itemRectangle, intersectRectangle;
        private PlayerItemCollisionHandler collisionHandler;
        public ICollision collision;

        public PlayerItemCollisionDetector()
        {
            collisionHandler = new PlayerItemCollisionHandler();
        }

        private void DetectCollision(IPlayer player, Item item)
        {
            playerRectangle = player.CollisionRectangle;
            itemRectangle = item.CollisionRectangle;

            if (playerRectangle.Intersects(itemRectangle))
            {
                intersectRectangle = Rectangle.Intersect(playerRectangle, itemRectangle);

                if (intersectRectangle.Height >= intersectRectangle.Width)
                {
                    if (playerRectangle.X > itemRectangle.X) collision = new LeftCollision(intersectRectangle);
                    else collision = new RightCollision(intersectRectangle);
                }
                else
                {
                    if (playerRectangle.Y > itemRectangle.Y) collision = new TopCollision(intersectRectangle);
                    else collision = new BottomCollision(intersectRectangle);
                }

                collisionHandler.HandleCollision(player, item, collision);
            }
        }

        public void Update(IPlayer player, Item item)
        {
            DetectCollision(player, item);
        }

    }
}
