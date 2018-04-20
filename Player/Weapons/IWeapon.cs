using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public interface IWeapon : ICollidable, IGameObject
    {
        IWeaponState State { get; set; }
        Point Location { get; set; }
        void Delete();
        void StandardCollision();
        void CollideWithFloor();
    }
}
