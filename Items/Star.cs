using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Star : Item
    {

        public Star(Point position, bool boxed)
        {
            this.boxed = boxed;
            visible = !boxed;
            Location = position;
            State = new StaticStarState(this);
        }

        public override void Unbox(IPlayer player)
        {
            visible = true;
            State = new UnboxingStarState(this);
        }
    }
}