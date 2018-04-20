using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerPlatformCollisionDetector
    {
        private Rectangle PlayerRectangle, PlatformRectangle, IntersectRectangle;

        public ICollision collisionSide;
        private PlayerPlatformCollisionHandler collisionHandler;

        public PlayerPlatformCollisionDetector()
        {
            collisionHandler = new PlayerPlatformCollisionHandler();
        }

        public void DetectPlatformPrepass(IPlayer player, Platform platform)
        {
            PlayerRectangle = new Rectangle(player.CollisionRectangle.X,
                player.CollisionRectangle.Y,
                player.CollisionRectangle.Width,
                player.CollisionRectangle.Height + 1);
            PlatformRectangle = platform.CollisionRectangle;

            if (PlayerRectangle.Intersects(PlatformRectangle))
            {
                IntersectRectangle = Rectangle.Intersect(PlayerRectangle, PlatformRectangle);

                if (IntersectRectangle.Height > 0)
                {
                    collisionHandler.HandlePlatformPrePass(player, platform);
                }

            }
        }

        public void DetectCollision(IPlayer player, Platform platform)
        {
            PlayerRectangle = player.CollisionRectangle;
            PlatformRectangle = platform.CollisionRectangle;

            if (PlayerRectangle.Intersects(PlatformRectangle))
            {
                IntersectRectangle = Rectangle.Intersect(PlayerRectangle, PlatformRectangle);

                if (IntersectRectangle.Height - IntersectRectangle.Width > 2)
                {
                    if (PlayerRectangle.X > PlatformRectangle.X) collisionSide = new LeftCollision(IntersectRectangle);
                    else collisionSide = new RightCollision(IntersectRectangle);
                }
                else
                {
                    if (PlayerRectangle.Y > PlatformRectangle.Y) collisionSide = new TopCollision(IntersectRectangle);
                    else collisionSide = new BottomCollision(IntersectRectangle);
                }

                collisionHandler.HandleCollision(player, platform, collisionSide);
            }
        }

        public void Update(IPlayer player, Platform platform)
        {
            DetectCollision(player, platform);
        }
    }
}