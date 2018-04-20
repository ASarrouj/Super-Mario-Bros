using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerBridgeCollisionDetector
    {
        private Rectangle playerRectangle, bridgeRectangle, axeRectangle, intersectRectangle;
        public ICollision collision;
        private PlayerBridgeCollisionHandler collisionHandler;

        public PlayerBridgeCollisionDetector()
        {
            collisionHandler = new PlayerBridgeCollisionHandler();
        }

        private void DetectCollision(IPlayer player, Bridge bridge)
        {
            playerRectangle = player.CollisionRectangle;
            bridgeRectangle = bridge.CollisionRectangle;
            axeRectangle = bridge.Axe.CollisionRectangle;

            if (playerRectangle.Intersects(axeRectangle))
            {          
                bridge.Break();
                player.TouchAxe();
                player.Location = new Point(bridge.Axe.CollisionRectangle.X, player.Location.Y);
            } else if (playerRectangle.Intersects(bridgeRectangle))
            {               
                intersectRectangle = Rectangle.Intersect(playerRectangle, bridgeRectangle);

                if (intersectRectangle.Height >= intersectRectangle.Width)
                {
                    if (player.Location.X > bridge.Position.X)
                    {
                        collision = new LeftCollision(intersectRectangle);
                    }
                    else
                    {
                        collision = new RightCollision(intersectRectangle);
                    }
                }
                else if (intersectRectangle.Width > intersectRectangle.Height)
                {
                    if (player.Location.Y > bridge.Position.Y)
                    {
                        collision = new TopCollision(intersectRectangle);
                    }
                    else
                    {
                        collision = new BottomCollision(intersectRectangle);
                    }
                }
                collisionHandler.HandleCollision(player, bridge, collision);

            }
        }

        public void Update(IPlayer player, Bridge bridge)
        {
            DetectCollision(player, bridge);
        }
    }
}
