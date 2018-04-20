using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class WeaponPipeCollisionHandler
    {
        public WeaponPipeCollisionHandler()
        {

        }

        public void HandleCollision(IWeapon weapon, Pipe pipe, ICollision collision)
        {
            if (weapon.State is IActiveWeaponState)
            {
                if (collision is LeftCollision)
                {
                    weapon.StandardCollision();
                }
                else if (collision is RightCollision)
                {
                    weapon.StandardCollision();
                }
                else if (collision is TopCollision)
                {
                    weapon.StandardCollision();
                }
                else if (collision is BottomCollision)
                {
                    weapon.Location = new Point(weapon.Location.X, weapon.Location.Y - collision.GetIntersectDistance());
                    weapon.CollideWithFloor();
                }
            }
        }
    }
}