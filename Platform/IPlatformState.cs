using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public interface IPlatformState : IGameObject, ICollidable
    {
        Point Delta { get; }
    }
}
