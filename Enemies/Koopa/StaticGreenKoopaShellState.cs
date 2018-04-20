using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StaticGreenKoopaShellState : KoopaState, IEnemyState
    {
        private StaticSprite sprite;
        private bool left;

        public StaticGreenKoopaShellState(Koopa koopa) : base (koopa, new Point(0x10, 0xE))
        {
            sprite = EnemySpriteFactory.Instance.CreateGreenKoopaShell();
            koopa.Velocity = new Vector2(0.0f, koopa.Velocity.Y);
            left = false;
            SoundFactory.Instance.CreateStompSound().Play();
        }

        public bool IsFlipped { get { return false; } }

        public bool IsShell { get { return true; } }

        public bool Dead { get { return true; } }

        public bool Gravity { get { return true; } }

        public bool FacingLeft { get { return left; } }

        public void BeStomped()
        {
            if (left) koopa.State = new LeftMovingGreenKoopaShellState(koopa);
            else koopa.State = new RightMovingGreenKoopaShellState(koopa);
        }

        public void BeFlipped()
        {
            koopa.State = new FlippedGreenKoopaState(koopa);
        }

        public void ChangeDirection()
        {
            left = !left;
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
