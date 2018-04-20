using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public interface IGameState
    {
        void NextSequencedState();
        void TogglePause();
        void PowerUpOrDamaged();
        void PlayerDying();
        void TouchFlagpole();
        void TouchAxe();
        void Update(GameTime gameTime);
        void Draw(GameTime gametime, SpriteBatch batch);
    }
}
