using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerHazardCollisionDetector
    {
        private Rectangle playerRectangle, hazardRectangle;
        private PlayerHazardCollisionHandler collisionHandler;
        public ICollision collision;

        public PlayerHazardCollisionDetector()
        {
            collisionHandler = new PlayerHazardCollisionHandler();
        }

        private void DetectCollision(IPlayer player, IHazard hazard)
        {
            playerRectangle = player.CollisionRectangle;
            hazardRectangle = hazard.CollisionRectangle;

            if (playerRectangle.Intersects(hazardRectangle))
            {
                collisionHandler.HandleCollision(player, hazard);
            }
        }

        public void Update(IPlayer player, IHazard hazard)
        {
            DetectCollision(player, hazard);
        }

    }
}
