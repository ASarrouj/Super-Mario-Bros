using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class FireFlower : Item
    {

        public FireFlower(Point position, bool boxed)
        {
            this.boxed = boxed;
            visible = !boxed;
            Location = position;
            State = new StaticFireFlowerState(this);
        }

        public override void Unbox(IPlayer player)
        {
            visible = true;
            State = new UnboxingFireFlowerState(this);
        }
    }
}
