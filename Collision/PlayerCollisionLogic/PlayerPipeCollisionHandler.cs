using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerPipeCollisionHandler
    {
        public PlayerPipeCollisionHandler()
        {
            
        }

        public void HandleCollision(IPlayer player, Pipe pipe, ICollision collision)
        {
            if (collision is LeftCollision)
            {
                player.Location = new Point(player.Location.X + collision.GetIntersectDistance(), player.Location.Y);
                player.Velocity = new Vector2(0.0f, player.Velocity.Y);
            }
            else if (collision is RightCollision)
            {
                if (!player.Jumping & pipe.HasDestination & pipe.State is LeftPipeState)
                {
                    player.Game.state = new PipeTransitionState(player.Game, pipe.DestinationLevel, pipe.DestinationPoint);
                    player.Velocity = new Vector2(1.0f, 0.0f);
                }
                else
                {
                    player.Location = new Point(player.Location.X - collision.GetIntersectDistance(), player.Location.Y);
                    player.Velocity = new Vector2(0.0f, player.Velocity.Y);
                }
            }
            else if (collision is TopCollision)
            {
                player.Location = new Point(player.Location.X, player.Location.Y + collision.GetIntersectDistance());
                player.Velocity = new Vector2(player.Velocity.X, 0.0f);
            }
            else if (collision is BottomCollision)
            {
                if (player.Velocity.Y >= 0)
                {
                    player.Location = new Point(player.Location.X, player.Location.Y - collision.GetIntersectDistance());
                    player.Velocity = new Vector2(player.Velocity.X, 0.0f);
                    player.Jumping = false;
                    player.Land();

                    if (player.Crouching & pipe.HasDestination & pipe.State is UpPipeState & IsPlayerBetweenPipe(player, pipe))
                    {
                        player.Game.state = new PipeTransitionState(player.Game, pipe.DestinationLevel, pipe.DestinationPoint);
                        player.Velocity = new Vector2(0.0f, 1.0f);
                    }
                }
            }
        }

        private bool IsPlayerBetweenPipe(IPlayer player, Pipe pipe)
        {
            return ((player.CollisionRectangle.Left > pipe.CollisionRectangle.Left) &
                (player.CollisionRectangle.Right < pipe.CollisionRectangle.Right));
        }
    }
}