using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerProjectileCollisionDetector
    {
        private Rectangle playerRectangle, projRectangle;
        public ICollision collision;

        public PlayerProjectileCollisionDetector()
        {
        }

        private void DetectCollision(IPlayer player, IProjectile projectile)
        {
            playerRectangle = player.CollisionRectangle;
            projRectangle = projectile.CollisionRectangle;

            if (playerRectangle.Intersects(projRectangle) && !player.Invincible && !player.Star.Active)
            {
                player.TakeDamage();
            }
        }

        public void Update(IPlayer player, IProjectile proj)
        {
            DetectCollision(player, proj);
        }
    }
}
