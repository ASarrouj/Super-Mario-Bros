using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public interface IMenuState
    {
        void Up();
        void Down();
        void Select();
        void Back();
        void Draw(GameTime gametime, SpriteBatch batch);
    }
}
