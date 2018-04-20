using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class ResetGameCommand : ICommand
    {
        protected $safeprojectname$ game;

        public ResetGameCommand($safeprojectname$ game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.state = new GameStartState(game);
        }

        public void ReleaseKey()
        {

        }
    }
}
