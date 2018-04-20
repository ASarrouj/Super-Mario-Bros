using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public interface IGameObject
    {
        void Update(GameTime gametime);

        void Draw(GameTime gametime, SpriteBatch batch);
    }
}
