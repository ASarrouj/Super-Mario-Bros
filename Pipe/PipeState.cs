
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public abstract class PipeState
    {
        protected Pipe pipe;

        protected Point collisionSize;

        protected PipeState(Pipe pipe, Point collisionSize)
        {
            this.pipe = pipe;
            this.collisionSize = collisionSize;
        }

        public Rectangle CollisionRectangle { get { return new Rectangle(pipe.Position, collisionSize); } }
    }
}
