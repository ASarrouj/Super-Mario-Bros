using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StaticRedKoopaShellState : KoopaState, IEnemyState
    {
        private StaticSprite sprite;
        private bool left;

        public StaticRedKoopaShellState(Koopa koopa) : base (koopa, new Point(0x10, 0xE))
        {
            sprite = EnemySpriteFactory.Instance.CreateRedKoopaShell();
            koopa.Velocity = new Vector2(0.0f, koopa.Velocity.Y);
            left = false;
            SoundFactory.Instance.CreateStompSound().Play();
        }

        public bool IsFlipped { get { return false; } }

        public bool IsShell { get { return true; } }

        public bool Dead { get { return true; } }

        public bool Gravity { get { return true; } }

        public bool FacingLeft { get { return false; } }

        public void BeStomped()
        {
            if (left) koopa.State = new LeftMovingRedKoopaShellState(koopa);
            else koopa.State = new RightMovingRedKoopaShellState(koopa);
        }

        public void BeFlipped()
        {
            koopa.State = new FlippedRedKoopaState(koopa);
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
