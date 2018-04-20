using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftMovingGreenKoopaShellState : KoopaState, IEnemyState
    {
        private StaticSprite sprite;

        public LeftMovingGreenKoopaShellState(Koopa koopa) : base (koopa, new Point(0x10, 0xE))
        {
            sprite = EnemySpriteFactory.Instance.CreateGreenKoopaShell();
            koopa.Velocity = new Vector2(-250.0f, koopa.Velocity.Y);
        }

        public bool IsFlipped { get { return false; } }

        public bool IsShell { get { return true; } }

        public bool Dead { get { return true; } }

        public bool Gravity { get { return true; } }

        public bool FacingLeft { get { return true; } }

        public void BeStomped()
        {
            koopa.State = new StaticGreenKoopaShellState(koopa);
        }

        public void BeFlipped()
        {
            koopa.State = new FlippedGreenKoopaState(koopa);
        }

        public void ChangeDirection()
        {
            koopa.State = new RightMovingGreenKoopaShellState(koopa);
        }

        public void Bounce()
        {
        }

        public void FollowPlayer(IPlayer player) { }

        public void Update(GameTime gameTime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, koopa.Location);
        }
    }
}
