using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public abstract class BowserState
    {
        protected Bowser bowser;

        protected Point collisionSize;

        public bool IsShell { get { return false; } }

        protected BowserState(Bowser bowser, Point collisionSize)
        {
            this.bowser = bowser;
            this.collisionSize = collisionSize;
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(bowser.Location - new Point(0, collisionSize.Y), collisionSize);
            }
        }
    }
}
