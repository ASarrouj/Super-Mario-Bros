using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class LeftCollision : ICollision
    {
        private int xIntersect;
        private Rectangle IntersectRectangle;
        

        public LeftCollision(Rectangle IntersectRectangle)
        {
            xIntersect = IntersectRectangle.Width;
            this.IntersectRectangle = IntersectRectangle;
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
