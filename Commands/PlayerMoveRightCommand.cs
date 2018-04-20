using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class PlayerMoveRightCommand : ICommand
    {
        private IPlayer player;

        public PlayerMoveRightCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute(GameTime gametime)
        {
            player.TransitionRight();
        }

        public void ReleaseKey()
        {

        }
    }
}