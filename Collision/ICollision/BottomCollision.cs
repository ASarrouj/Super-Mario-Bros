using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class BottomCollision : ICollision
    {
        private int yIntersect;
        private Rectangle IntersectRectangle;

        public BottomCollision(Rectangle IntersectRectangle)
        {
            this.IntersectRectangle = IntersectRectangle;
            yIntersect = IntersectRectangle.Height;
        }

        public int GetIntersectDistance()
        {
            return yIntersect;
        }

        public int GetIntersectArea()
        {
            return (IntersectRectangle.Width * IntersectRectangle.Height);
        }
    }
}
