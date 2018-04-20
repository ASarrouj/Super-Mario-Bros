using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerPlatformCollisionHandler
    {
        public PlayerPlatformCollisionHandler()
        {
            
        }

        public void HandlePlatformPrePass(IPlayer player, Platform platform)
        {
            player.Position = new Vector2(player.Position.X + platform.Delta.X, player.Position.Y + platform.Delta.Y);
        }

        public void HandleCollision(IPlayer player, Platform platform, ICollision collision)
        {
            if (collision is LeftCollision)
            {
                player.Location = new Point(player.Location.X + collision.GetIntersectDistance(), player.Location.Y);
                player.Velocity = new Vector2(0.0f, player.Velocity.Y);
            }
            else if (collision is RightCollision)
            {
                player.Location = new Point(player.Location.X - collision.GetIntersectDistance(), player.Location.Y);
                player.Velocity = new Vector2(0.0f, player.Velocity.Y);
            }
            else if (collision is TopCollision)
            {

            }
            else if (collision is BottomCollision)
            {
                if (player.Velocity.Y >= 0)
                {
                    player.Location = new Point(player.Location.X, player.Location.Y - collision.GetIntersectDistance());
                    player.Velocity = new Vector2(player.Velocity.X, 0.0f);
                    player.Jumping = false;
                    player.Land();
                }
            }
        }
    }
}