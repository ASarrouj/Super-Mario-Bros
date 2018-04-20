using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public abstract class GoombaState
    {
        protected Goomba goomba;

        protected Point collisionSize;

        public bool IsShell { get { return false; } }

        protected GoombaState(Goomba goomba, Point collisionSize)
        {
            this.goomba = goomba;
            this.collisionSize = collisionSize;
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(goomba.Location - new Point(0, collisionSize.Y), collisionSize);
            }
        }
    }
}
