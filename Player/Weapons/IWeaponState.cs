using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public interface IWeaponState : ICollidable
    {
        void Create();
        void Delete();
        void CollideWithFloor();
        void Update(GameTime gametime);
        void Draw(GameTime gametime, SpriteBatch batch);
    }
}
