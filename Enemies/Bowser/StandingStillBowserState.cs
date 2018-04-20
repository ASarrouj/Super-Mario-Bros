using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StandingStillBowserState : BowserState, IEnemyState
    {
        private AnimatedSprite bowserSprite;

        public StandingStillBowserState(Bowser bowser) : base(bowser, new Point(0x20, 0x20))
        {
            bowserSprite = EnemySpriteFactory.Instance.CreateStandingStillBowser();
            bowser.Velocity = new Vector2(0.0f, bowser.Velocity.Y);
        }

        public bool IsFlipped { get { return false; } }

        public bool Dead { get { return false; } }

        public bool FacingLeft { get { return true; } }

        public bool Gravity { get { return true; } }

        public void ChangeDirection()
        {
            bowser.State = new RightMovingBowserState(bowser);
        }

        public void BeStomped()
        {
        }

        public void BeFlipped()
        {
        }

        public void Bounce()
        {
        }

        public void FollowPlayer(IPlayer player)
        {
            if (bowser.Location.X > player.Location.X) bowser.State = new LeftMovingBowserState(bowser);
            else bowser.State = new RightMovingBowserState(bowser);
        }

        public void Update(GameTime gameTime)
        {
            bowserSprite.Update(gameTime);
            bowser.Shoot();
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            bowserSprite.Draw(batch, bowser.Location);
        }
    }
}
