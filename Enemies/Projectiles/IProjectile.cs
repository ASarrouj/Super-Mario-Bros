using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public interface IProjectile : ICollidable, IGameObject
    {
        Point Location { get; set; }
        void Create();
        void Delete();
    }
}
