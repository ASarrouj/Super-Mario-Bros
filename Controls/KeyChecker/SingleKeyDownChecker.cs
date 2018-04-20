using Microsoft.Xna.Framework.Input;
using System;

namespace $safeprojectname$
{
    class SingleKeyDownChecker : IKeyChecker
    {
        private Keys key;
        public SingleKeyDownChecker(Keys key)
        {
            this.key = key;
        }

        public bool CheckKeys(Keys[] keys)
        {
            if (Array.IndexOf(keys, key) != -1)
                return true;
            else
                return false;
        }
    }
}