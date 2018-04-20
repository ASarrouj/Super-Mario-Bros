using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerHazardCollisionHandler
    {
        public PlayerHazardCollisionHandler() { }

        public void HandleCollision(IPlayer player, IHazard hazard)
        {
            if (hazard.InstantDeath)
                player.Kill();
            else if(!player.Invincible && !player.Star.Active)
                player.TakeDamage();
        }
    }
}