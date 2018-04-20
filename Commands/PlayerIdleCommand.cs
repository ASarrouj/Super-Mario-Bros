using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class PlayerIdleCommand : ICommand
    {
        private IPlayer player;

        public PlayerIdleCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute(GameTime gametime)
        {        
            if (MathHelper.Distance(player.Velocity.X, 0.0f) > 10)
            {
                float decceleration = (player.Velocity.X < 0.0f ? ConstantValues.PLAYER_ACCELERATION : -ConstantValues.PLAYER_ACCELERATION);
                player.Acceleration = new Vector2(decceleration, player.Acceleration.Y);
                
            } else {
                player.Acceleration = new Vector2(0.0f, player.Acceleration.Y);
                player.Velocity = new Vector2(0.0f, player.Velocity.Y);
            }

            player.Idle();
        }

        public void ReleaseKey()
        {

        }
    }
}
