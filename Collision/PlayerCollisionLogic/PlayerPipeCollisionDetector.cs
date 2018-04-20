using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerPipeCollisionDetector
    {
        private Rectangle PlayerRectangle, PipeRectangle, IntersectRectangle;

        public ICollision collisionSide;
        private PlayerPipeCollisionHandler collisionHandler;

        public PlayerPipeCollisionDetector()
        {
            collisionHandler = new PlayerPipeCollisionHandler();
        }

        public void DetectCollision(IPlayer player, Pipe pipe)
        {
            PlayerRectangle = player.CollisionRectangle;
            PipeRectangle = pipe.CollisionRectangle;

            if (PlayerRectangle.Intersects(PipeRectangle))
            {
                IntersectRectangle = Rectangle.Intersect(PlayerRectangle, PipeRectangle);

                if (IntersectRectangle.Height >= IntersectRectangle.Width)
                {
                    if (player.Location.X > pipe.Position.X)
                    {
                        collisionSide = new LeftCollision(IntersectRectangle);
                    }
                    else
                    {
                        collisionSide = new RightCollision(IntersectRectangle);
                    }
                }
                else if (IntersectRectangle.Width > IntersectRectangle.Height)
                {
                    if (player.Location.Y > pipe.Position.Y)
                    {
                        collisionSide = new TopCollision(IntersectRectangle);
                    }
                    else
                    {
                        collisionSide = new BottomCollision(IntersectRectangle);
                    }
                }
                else
                {
                    collisionSide = new NoCollision();
                }

                collisionHandler.HandleCollision(player, pipe, collisionSide);
            }
        }

        public void Update(IPlayer player, Pipe pipe)
        {
            DetectCollision(player, pipe);
        }
    }
}