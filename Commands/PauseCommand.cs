using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class PauseCommand : ICommand
    {
        protected $safeprojectname$ game;
        private bool Released;

        public PauseCommand($safeprojectname$ game)
        {
            this.game = game;
            Released = true;
        }

        public void Execute(GameTime gameTime)
        {
            if (Released)
            {
                game.state.TogglePause();
                Released = false;
            }
        }

        public void ReleaseKey()
        {
            Released = true;
        }
    }
}
