using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class KeyboardOnCommand : ICommand
    {
        KeyboardController keyboard;
        GamepadController gamepad;

        public KeyboardOnCommand(KeyboardController keyboard, GamepadController gamepad)
        {
            this.keyboard = keyboard;
            this.gamepad = gamepad;
        }

        public void Execute(GameTime gametime)
        {
            keyboard.keyboardOn = true;
            gamepad.gamepadOn = false;
        }

        public void ReleaseKey()
        {

        }
    }
}
