using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class VerticalFlyingKoopaState : KoopaState, IEnemyState
    {
        private AnimatedSprite sprite;
        private float timer;
        private bool upDirection;

        public VerticalFlyingKoopaState(Koopa koopa) : base (koopa, new Point(0x10, 0x18))
        {
            timer = 0.0f;
            this.sprite = EnemySpriteFactory.Instance.CreateLeftFlyingRedKoopa();
            koopa.Velocity = new Vector2(0.0f, 50.0f);
            upDirection = false;
        }

        public bool IsFlipped { get { return false; } }

        public bool IsShell { get { return false; } }

        public bool Dead { get { return false; } }

        public bool Gravity {  get { return false; } }

        public bool FacingLeft { get { return true; } }

        public void BeStomped()
        {
            koopa.State = new LeftWalkingRedKoopaState(koopa);
        }

        public void BeFlipped()
        {
            koopa.State = new FlippedRedKoopaState(koopa);
        }

        public void ChangeDirection()
        {
        }

        public void Bounce()
        {
        }

        public void FollowPlayer(IPlayer player) { }

        public void Update(GameTime gameTime )
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            sprite.Update(gameTime);
            if (timer > 2.0f)
            {
                upDirection = !upDirection;
                if (upDirection)
                {
                    koopa.Velocity = new Vector2(0.0f, -50.0f);
                }
                else
                {
                    koopa.Velocity = new Vector2(0.0f, 50.0f);
                }
                timer = 0;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, koopa.Location);
        }

    }
}
