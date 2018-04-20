using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace $safeprojectname$
{
    class GamepadController : IController
    {
        private PlayerIndex playerIndex;
        private GamePadState currentState;
        private List<Buttons> buttonList, buttonsPressed;
        private Buttons[] buttonPresses;
        public bool gamepadOn;

        protected List<KeyValuePair<IButtonChecker, ICommand>> buttonDownCallbacks;

        public GamepadController(PlayerIndex playerIndex = PlayerIndex.One)
        {
            gamepadOn = false;
            this.playerIndex = playerIndex;
            buttonDownCallbacks = new List<KeyValuePair<IButtonChecker, ICommand>>();
            buttonList = new List<Buttons>();

            buttonList.Add(Buttons.A);                      buttonList.Add(Buttons.B);
            buttonList.Add(Buttons.Back);                   buttonList.Add(Buttons.BigButton);
            buttonList.Add(Buttons.DPadDown);               buttonList.Add(Buttons.DPadLeft);
            buttonList.Add(Buttons.DPadRight);              buttonList.Add(Buttons.DPadUp);
            buttonList.Add(Buttons.LeftShoulder);           buttonList.Add(Buttons.LeftStick);
            buttonList.Add(Buttons.LeftThumbstickDown);     buttonList.Add(Buttons.LeftThumbstickLeft);
            buttonList.Add(Buttons.LeftThumbstickRight);    buttonList.Add(Buttons.LeftThumbstickUp);
            buttonList.Add(Buttons.LeftTrigger);            buttonList.Add(Buttons.RightShoulder);
            buttonList.Add(Buttons.RightStick);             buttonList.Add(Buttons.RightThumbstickDown);
            buttonList.Add(Buttons.RightThumbstickLeft);    buttonList.Add(Buttons.RightThumbstickRight);
            buttonList.Add(Buttons.RightThumbstickUp);      buttonList.Add(Buttons.RightTrigger);
            buttonList.Add(Buttons.Start);                  buttonList.Add(Buttons.X);
            buttonList.Add(Buttons.Y);

        }

        public void RegisterCallback(IButtonChecker buttonChecker, ICommand command)
        {
            buttonDownCallbacks.Add(new KeyValuePair<IButtonChecker, ICommand>(buttonChecker, command));
        }

        public void ClearCallbacks()
        {
            buttonDownCallbacks = new List<KeyValuePair<IButtonChecker, ICommand>>();
        }

        public void Update(GameTime gameTime)
        {
            currentState = GamePad.GetState(playerIndex);
            buttonsPressed = new List<Buttons>();

            foreach (var button in buttonList)
            {
                if (currentState.IsButtonDown(button))
                    buttonsPressed.Add(button);
            }

            buttonPresses = buttonsPressed.ToArray();

            foreach (var callback in buttonDownCallbacks)
            {
                if (gamepadOn)
                {
                    if (callback.Key.CheckButtons(buttonPresses))
                    {
                        callback.Value.Execute(gameTime);
                    }
                    else if (!callback.Key.CheckButtons(buttonPresses))
                    {
                        callback.Value.ReleaseKey();
                    }
                }
                else if (callback.Key.CheckButtons(buttonPresses) & callback.Value is GamepadOnCommand)
                    callback.Value.Execute(gameTime);
            }
        }
    }
}