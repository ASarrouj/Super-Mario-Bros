using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class PlayerJumpCommand : ICommand
    {
        private IPlayer player;
        public bool Released { get; set; }
        private int holdCounter;

        public PlayerJumpCommand(IPlayer player)
        {
            this.player = player;
            holdCounter = 0;
            Released = true;
        }

        public void Execute(GameTime gametime)
        {
            if (Released)
            {
                if (!player.Jumping)
                {
                    player.Velocity = new Vector2(player.Velocity.X, -200.0f);
                    player.Jumping = true;
                    player.Jump();
                    holdCounter++;
                }
                Released = false;
            }
            else if (holdCounter == 1)
            {
                holdCounter++;
            }
            else if(holdCounter == 2)
            {
                player.Velocity = new Vector2(player.Velocity.X, player.Velocity.Y - 100.0f);
                holdCounter = 0;
            }
        }

        public void ReleaseKey()
        {
            Released = true;
            holdCounter = 0;
        }
    }
}
