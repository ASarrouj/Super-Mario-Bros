using Microsoft.Xna.Framework.Input;
using System;

namespace $safeprojectname$
{
    class MultipleButtonUpChecker : IButtonChecker
    {
        private Buttons[] buttonList;
        public MultipleButtonUpChecker(Buttons[] buttons)
        {
            buttonList = buttons;
        }

        public bool CheckButtons(Buttons[] buttons)
        {
            for (int i = 0; i < buttonList.Length; i++)
            {
                if (Array.IndexOf(buttons, buttonList[i]) != -1)
                    return false;
            }
            return true;
        }
    }
}