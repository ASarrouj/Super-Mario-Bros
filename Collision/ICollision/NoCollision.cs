using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class NoCollision : ICollision
    {
        public int GetIntersectDistance()
        {
            return 0;
        }

        public int GetIntersectArea()
        {
            return 0;
        }
    }
}
