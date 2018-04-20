using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class PlayerMoveLeftCommand : ICommand
    {
        private IPlayer player;

        public PlayerMoveLeftCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute(GameTime gametime)
        {
            player.TransitionLeft();
        }

        public void ReleaseKey()
        {

        }
    }
}