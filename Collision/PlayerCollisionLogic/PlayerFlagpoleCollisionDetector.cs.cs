using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerFlagpoleCollisionDetector
    {
        private Rectangle playerRectangle, flagRectangle, intersectRectangle;
        private PlayerFlagpoleCollisionHandler collisionHandler;
        public ICollision collision;

        public PlayerFlagpoleCollisionDetector()
        {
            collisionHandler = new PlayerFlagpoleCollisionHandler();
            collision = new NoCollision();
        }

        private void DetectCollision(IPlayer player, Flagpole flagpole)
        {
            playerRectangle = player.CollisionRectangle;
            flagRectangle = flagpole.CollisionRectangle;
            intersectRectangle = Rectangle.Intersect(playerRectangle, flagRectangle);

            if (playerRectangle.Intersects(flagRectangle))
            {
                collisionHandler.HandleCollision(player, flagpole, collision);
            }
        }

        public void Update(IPlayer player, Flagpole flagpole)
        {
            DetectCollision(player, flagpole);
        }
    }
}
