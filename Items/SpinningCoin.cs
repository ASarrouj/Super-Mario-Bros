using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class SpinningCoin : Item
    {

        public SpinningCoin(Point position, bool boxed)
        {
            this.boxed = boxed;
            visible = !boxed;
            Location = position;
            State = new StaticSpinningCoinState(this);
        }

        public override void Unbox(IPlayer player)
        {
            visible = true;
            State = new UnboxingSpinningCoinState(this, player);
        }
    }
}
