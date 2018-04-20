using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class FlippedGreenKoopaState : KoopaState, IEnemyState
    {
        private StaticSprite sprite;

        public FlippedGreenKoopaState(Koopa koopa) : base(koopa, new Point(0x0, 0x0))
        {
            sprite = EnemySpriteFactory.Instance.CreateGreenFlippedKoopa();
            koopa.Velocity = new Vector2(0.0f, koopa.Velocity.Y);
            SoundFactory.Instance.CreateStompSound().Play();
        }

        public void BeStomped() { }

        public void BeFlipped() { }

        public bool IsFlipped { get { return true; } }

        public bool IsShell { get { return false; } }

        public bool Dead {  get { return true; } }

        public bool Gravity { get { return true; } }

        public bool FacingLeft { get { return false; } }

        public void ChangeDirection() { }

        public void Bounce() { }

        public void FollowPlayer(IPlayer player) { }

        public void Update(GameTime gameTime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, koopa.Location);
        }
    }
}
