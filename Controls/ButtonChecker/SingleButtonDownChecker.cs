using Microsoft.Xna.Framework.Input;
using System;

namespace $safeprojectname$
{
    class SingleButtonDownChecker : IButtonChecker
    {
        private Buttons button;
        public SingleButtonDownChecker(Buttons button)
        {
            this.button = button;
        }

        public bool CheckButtons(Buttons[] buttons)
        {
            if (Array.IndexOf(buttons, button) != -1)
                return true;
            else
                return false;
        }
    }
}