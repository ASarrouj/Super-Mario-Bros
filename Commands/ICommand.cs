using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public interface ICommand
    {
        void Execute(GameTime gameTime);
        void ReleaseKey();
    }
}
