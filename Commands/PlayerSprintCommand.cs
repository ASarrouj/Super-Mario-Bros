using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class PlayerSprintCommand : ICommand
    {
        private IPlayer player;

        public PlayerSprintCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute(GameTime gametime)
        {
            player.TerminalVelocity = new Vector2(ConstantValues.PLAYER_TERMINAL_SPRINT_VELOCITY, player.TerminalVelocity.Y);
        }

        public void ReleaseKey()
        {
            player.TerminalVelocity = new Vector2(ConstantValues.PLAYER_TERMINAL_WALK_VELOCITY, player.TerminalVelocity.Y);
        }
    }
}
