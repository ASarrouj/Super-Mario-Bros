using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class QuitCommand : ICommand
    {
        protected Game game;

        public QuitCommand(Game game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.Exit();
        }

        public void ReleaseKey()
        {

        }
    }
}
