using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class DeadGoombaState : GoombaState, IEnemyState
    {

        public DeadGoombaState(Goomba goomba) : base(goomba, new Point(0x0, 0x0))
        {
            goomba.Velocity = new Vector2(0.0f, 0.0f);
        }

        public bool IsFlipped { get { return true; } }

        public bool Dead { get { return true; } }

        public bool Gravity { get { return true; } }

        public bool FacingLeft { get { return false; } }

        public void ChangeDirection() { }

        public void BeStomped() { }

        public void BeFlipped() { }

        public void Bounce()
        {
        }

        public void FollowPlayer(IPlayer player) { }

        public void Update(GameTime gameTime) { }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
        }
    }
}
