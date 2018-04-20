using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public interface IProjectileState : ICollidable
    {
        void Create();
        void Delete();
        void Update(GameTime gametime);
        void Draw(GameTime gametime, SpriteBatch batch);
    }
}
