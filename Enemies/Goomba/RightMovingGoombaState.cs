using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class RightMovingGoombaState : GoombaState, IEnemyState
    {
        private AnimatedSprite goombaSprite;

        public RightMovingGoombaState(Goomba goomba) :base(goomba, new Point(0x10, 0x10))
        {
            goombaSprite = EnemySpriteFactory.Instance.CreateWalkingGoomba();
            goomba.Velocity = new Vector2(50.0f, goomba.Velocity.Y);
        }

        public bool IsFlipped { get { return false; } }

        public bool Dead { get { return false; } }

        public bool Gravity { get { return true; } }

        public bool FacingLeft { get { return false; } }

        public void ChangeDirection()
        {
            goomba.State = new LeftMovingGoombaState(goomba);
        }

        public void BeStomped()
        {
            goomba.State = new StompedGoombaState(goomba);
            SoundFactory.Instance.CreateStompSound().Play();
        }

        public void BeFlipped()
        {
            goomba.State = new FlippedGoombaState(goomba);
            SoundFactory.Instance.CreateStompSound().Play();
        }

        public void Bounce()
        {
        }

        public void FollowPlayer(IPlayer player) { }

        public void Update(GameTime gameTime)
        {
            goombaSprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            goombaSprite.Draw(batch, goomba.Location);
        }
    }
}
