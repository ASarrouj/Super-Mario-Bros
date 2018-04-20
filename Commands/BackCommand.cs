using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class BackCommand : ICommand
    {
        private MenuController menuController;
        private bool Released { get; set; }

        public BackCommand(MenuController menuController)
        {
            this.menuController = menuController;
            Released = true;
        }

        public void Execute(GameTime gametime)
        {
            if (Released)
            {
                Released = false;
                menuController.Back();
            }
        }

        public void ReleaseKey()
        {
            Released = true;
        }
    }
}