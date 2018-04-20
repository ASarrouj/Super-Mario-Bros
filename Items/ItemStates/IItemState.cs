using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public interface IItemState
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch batch);
        void ChangeDirection();
        void BeConsumed(IPlayer player);
    }
}
