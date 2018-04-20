using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Coin : Item
    {

        public Coin(Point position, bool boxed)
        {
            this.boxed = false;
            visible = true;
            Location = position;
            State = new StaticCoinState(this);
        }

        public override void Unbox(IPlayer player)
        {
        }
    }
}
