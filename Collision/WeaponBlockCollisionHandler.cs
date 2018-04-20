using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public class WeaponBlockCollisionHandler
    {
        private ICollision collision;

        public WeaponBlockCollisionHandler()
        {
            collision = new NoCollision();
        }

        public void HandleCollision(IWeapon weapon,  List<ICollision> collisions)
        {
            for (int i = 0; i < collisions.Count; i++)
            {
                if (collisions[i].GetIntersectArea() > collision.GetIntersectArea())
                {
                    collision = collisions[i];
                }
            }

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
                collision = new NoCollision();
            }
        }
    }
}