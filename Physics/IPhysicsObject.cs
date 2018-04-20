using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public interface IPhysicsObject
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
    }
}
