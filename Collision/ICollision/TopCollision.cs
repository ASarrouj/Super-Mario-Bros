using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class TopCollision : ICollision
    {
        private int yIntersect;
        private Rectangle IntersectRectangle;

        public TopCollision(Rectangle IntersectRectangle)
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