using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class SelectCommand : ICommand
    {
        private MenuController menuController;
        private bool Released { get; set; }

        public SelectCommand(MenuController menuController)
        {
            this.menuController = menuController;
            Released = false;
        }

        public void Execute(GameTime gametime)
        {
            if (Released)
            {
                Released = false;
                menuController.Select();
            }
        }

        public void ReleaseKey()
        {
            Released = true;
        }
    }
}
