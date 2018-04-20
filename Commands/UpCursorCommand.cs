using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class UpCursorCommand : ICommand
    {
        private MenuController menuController;

        public UpCursorCommand(MenuController menuController)
        {
            this.menuController = menuController;
        }

        public void Execute(GameTime gametime)
        {
            menuController.Up();
        }

        public void ReleaseKey()
        {

        }
    }
}
