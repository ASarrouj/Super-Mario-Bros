
namespace $safeprojectname$
{
    public interface IHazard : IGameObject, ICollidable
    {
        bool InstantDeath { get; }
    }
}
