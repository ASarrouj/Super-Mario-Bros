using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftBouncingKoopaState : KoopaState, IEnemyState
    {
        private AnimatedSprite sprite;

        public LeftBouncingKoopaState(Koopa koopa) : base (koopa, new Point(0x10, 0x18))
        {
            sprite = EnemySpriteFactory.Instance.CreateLeftFlyingGreenKoopa();
            koopa.Velocity = new Vector2(-40.0f, koopa.Velocity.Y);
        }

        public bool Dead { get { return false; } }

        public bool IsShell { get { return false; } }

        public bool Gravity { get { return true; } }

        public bool FacingLeft { get { return true; } }

        public bool IsFlipped { get { return false; } }

        public void BeStomped()
        {
            koopa.State = new LeftWalkingGreenKoopaState(koopa);
        }

        public void BeFlipped()
        {
            koopa.State = new FlippedGreenKoopaState(koopa);
        }

        public void ChangeDirection()
        {
            koopa.State = new RightBouncingKoopaState(koopa);
        }

        public void Bounce()
        {
            koopa.Velocity = new Vector2(koopa.Velocity.X, -200.0f);
        }

        public void FollowPlayer(IPlayer player) { }

        public void Update(GameTime gameTime )
        {
            sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, koopa.Location);
        }

    }
}
