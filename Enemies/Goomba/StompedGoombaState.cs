using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class StompedGoombaState : GoombaState, IEnemyState
    {
        private StaticSprite goombaSprite;
        private float timer;

        public StompedGoombaState(Goomba goomba) : base(goomba, new Point(0x0, 0x0))
        {
            goombaSprite = EnemySpriteFactory.Instance.CreateStompedGoomba();
            goomba.Velocity = new Vector2(0.0f, 0.0f);
            timer = 0.0f;
        }

        public bool IsFlipped { get { return false; } }

        public bool Dead { get { return true; } }

        public bool Gravity { get { return false; } }

        public bool FacingLeft { get { return false; } }

        public void ChangeDirection() { }

        public void BeStomped() { }

        public void BeFlipped() { }

        public void Bounce() { }

        public void FollowPlayer(IPlayer player) { }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 1.0f)
            {
                goomba.State = new DeadGoombaState(goomba);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            goombaSprite.Draw(batch, goomba.Location);
        }
    }
}
