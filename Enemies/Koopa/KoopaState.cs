using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public abstract class KoopaState
    {
        protected Koopa koopa;

        protected Point collisionSize;

        protected KoopaState(Koopa koopa, Point collisionSize)
        {
            this.koopa = koopa;
            this.collisionSize = collisionSize;
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(koopa.Location - new Point(0, collisionSize.Y), collisionSize);
            }
        }
    }
}
