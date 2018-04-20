using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class PlayerUseWeaponCommand : ICommand
    {
        private IPlayer player;
        private bool Released { get; set; }
        public PlayerUseWeaponCommand(IPlayer player)
        {
            this.player = player;
            Released = true;
        }
        public void Execute(GameTime gametime)
        {
            if (Released)
            {
                player.UseWeapon();
                Released = false;
            }
        }

        public void ReleaseKey()
        {
            Released = true;
        }
    }
}