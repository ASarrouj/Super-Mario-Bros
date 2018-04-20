using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace $safeprojectname$
{
    class KeyboardController : IController
    {
        protected List<KeyValuePair<IKeyChecker, ICommand>> keyDownCallbacks;
        public bool keyboardOn;
        private Keys[] keyPresses;

        public KeyboardController()
        {
            keyboardOn = true;
            keyDownCallbacks = new List<KeyValuePair<IKeyChecker, ICommand>>();
        }

        public void RegisterCallback(IKeyChecker keyChecker, ICommand command)
        {
            keyDownCallbacks.Add(new KeyValuePair<IKeyChecker, ICommand>(keyChecker, command));
        }

        public void ClearCallbacks()
        {
            keyDownCallbacks = new List<KeyValuePair<IKeyChecker, ICommand>>();
        }

        public void Update(GameTime gameTime)
        {
            keyPresses = Keyboard.GetState().GetPressedKeys();

            foreach (var callback in keyDownCallbacks)
            {
                if (keyboardOn)
                {
                    if (callback.Key.CheckKeys(keyPresses))
                    {
                        callback.Value.Execute(gameTime);
                    }
                    else if (!(callback.Key.CheckKeys(keyPresses)))
                    {
                        callback.Value.ReleaseKey();
                    }
                }
                else if (callback.Key.CheckKeys(keyPresses) & callback.Value is KeyboardOnCommand)
                {
                    callback.Value.Execute(gameTime);
                }
            }
        }
    }
}