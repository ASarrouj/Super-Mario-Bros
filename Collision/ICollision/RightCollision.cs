using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class RightCollision : ICollision
    {
        private int xIntersect;
        private Rectangle IntersectRectangle;

        public RightCollision(Rectangle IntersectRectangle)
        {
            this.IntersectRectangle = IntersectRectangle;
            xIntersect = IntersectRectangle.Width;
        }

        public int GetIntersectDistance()
        {
            return xIntersect;
        }

        public int GetIntersectArea()
        {
            return (IntersectRectangle.Width * IntersectRectangle.Height);
        }
    }
}