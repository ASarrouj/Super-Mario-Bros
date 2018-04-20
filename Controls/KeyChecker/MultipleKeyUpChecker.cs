using Microsoft.Xna.Framework.Input;
using System;

namespace $safeprojectname$
{
    class MultipleKeyUpChecker : IKeyChecker
    {
        private Keys[] keyList;
        public MultipleKeyUpChecker(Keys[] keys)
        {
            keyList = keys;
        }

        public bool CheckKeys(Keys[] keys)
        {
            for (int i = 0; i < keyList.Length; i++)
            {
                if (Array.IndexOf(keys, keyList[i]) != -1)
                    return false;
            }
            return true;
        }
    }
}
