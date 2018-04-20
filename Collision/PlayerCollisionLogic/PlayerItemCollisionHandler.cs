using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerItemCollisionHandler
    {
        public PlayerItemCollisionHandler() { }

        public void HandleCollision(IPlayer player, Item item, ICollision collision)
        {
                if (collision is BottomCollision)
                {
                    player.Location = new Point(player.Location.X, player.Location.Y - collision.GetIntersectDistance());
                }
                else if (collision is TopCollision)
                {
                    player.Location = new Point(player.Location.X, player.Location.Y + collision.GetIntersectDistance());
                }
                else if (collision is LeftCollision)
                {
                    player.Location = new Point(player.Location.X + collision.GetIntersectDistance(), player.Location.Y);
                }
                else if (collision is RightCollision)
                {
                    player.Location = new Point(player.Location.X - collision.GetIntersectDistance(), player.Location.Y);
                }

                item.BeConsumed(player);
        }
    }
}