using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerBlockCollisionHandler
    {
        private Block block;
        private ICollision collision;

        public PlayerBlockCollisionHandler()
        {
            collision = new NoCollision();
        }

        public void HandleCollision(IPlayer player, List<Block> blockArray, List<ICollision> collisions)
        {
            for (int i = 0; i < collisions.Count; i++)
            {
                if (collisions[i].GetIntersectArea() > collision.GetIntersectArea())
                {
                    collision = collisions[i];
                    block = blockArray[i];
                }
            }

            if (collision is LeftCollision)
            {
                if (!player.Auto) {
                player.Location = new Point(player.Location.X + collision.GetIntersectDistance(), player.Location.Y);
                player.Velocity = new Vector2(0.0f, player.Velocity.Y);
                }
            }
            else if (collision is RightCollision)
            {
                if (!player.Auto) {
                player.Location = new Point(player.Location.X - collision.GetIntersectDistance(), player.Location.Y);
                player.Velocity = new Vector2(0.0f, player.Velocity.Y);
                }
            }
            else if (collision is TopCollision)
            {
                if (player.Velocity.Y <= 0)
                {
                    player.Location = new Point(player.Location.X, player.Location.Y + collision.GetIntersectDistance());
                    player.Velocity = new Vector2(player.Velocity.X, 0.0f);
                    if (!(player.State is ISmallMarioState))
                        block.BeHit(player);
                    else if ((player.State is ISmallMarioState & !(block.State is BrickBlockState)))
                        block.BeHit(player);
                    else if ((player.State is ISmallMarioState) & (block.State is BrickBlockState))
                        block.BeBumped(player);
                    else
                        block.BeHit(player);
                }
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
            collision = new NoCollision();
        }
    }
}