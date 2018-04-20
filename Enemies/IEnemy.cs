using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public interface IEnemy : IGameObject, ICollidable, IPhysicsObject
    {
        IEnemyState State { get; set; }

        Point Location { get; set; }

        List<IProjectile> Projectiles { get; }

        bool IsFlipped { get; }

        bool IsShell { get; }

        bool Dead { get; }

        void ChangeDirection();

        void BeStomped(string points);

        void BeFlipped(string points);

        void Bounce();

        void Shoot();

        void FollowPlayer(IPlayer player);

        void Stop();
    }
}
