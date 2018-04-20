using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class RedMushroom : Item
    {
        public RedMushroom(Point position, bool boxed)
        {
            this.boxed = boxed;
            visible = !boxed;
            Location = position;
            State = new StaticRedMushroomState(this);
        }

        public override void Unbox(IPlayer player)
        {
            visible = true;
            if (player.State is ISmallMarioState) State = new UnboxingRedMushroomState(this, player.Location.X);
            else State = new UnboxingFireFlowerState(this);
        }
    }
}
