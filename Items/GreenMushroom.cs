using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class GreenMushroom : Item
    {

        public GreenMushroom(Point position, bool boxed)
        {
            this.boxed = boxed;
            visible = !boxed;
            Location = position;
            State = new StaticGreenMushroomState(this);
        }

        public override void Unbox(IPlayer player)
        {
            visible = true;
            State = new UnboxingGreenMushroomState(this, player.Location.X);
        }

    }
}
