using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class GamepadOnCommand : ICommand
    {
        KeyboardController keyboard;
        GamepadController gamepad;

        public GamepadOnCommand(KeyboardController keyboard, GamepadController gamepad)
        {
            this.keyboard = keyboard;
            this.gamepad = gamepad;
        }

        public void Execute(GameTime gametime)
        {
            keyboard.keyboardOn = false;
            gamepad.gamepadOn = true;
        }

        public void ReleaseKey()
        {

        }
    }
}
