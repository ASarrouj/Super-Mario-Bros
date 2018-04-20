using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class DownCursorCommand : ICommand
    {
        private MenuController menuController;

        public DownCursorCommand(MenuController menuController)
        {
            this.menuController = menuController;
        }

        public void Execute(GameTime gametime)
        {
            menuController.Down();
        }

        public void ReleaseKey()
        {

        }
    }
}
