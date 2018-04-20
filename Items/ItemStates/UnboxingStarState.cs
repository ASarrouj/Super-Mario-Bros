using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class UnboxingStarState : IItemState
    {
        private Item star;
        private AnimatedSprite sprite;
        private int startHeight;

        public UnboxingStarState(Item star)
        {
            this.star = star;
            star.Gravity = false;
            startHeight = star.Location.Y;
            star.Velocity = new Vector2(0.0f, 0.0f);
            sprite = ItemSpriteFactory.Instance.CreateStar();
            sprite.AnimationPlayer.Play();
            SoundFactory.Instance.CreatePowerupAppearsSound().Play();
        }

        public void BeConsumed(IPlayer player)
        {
        }

        public void ChangeDirection() { }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            star.Location = new Point(star.Location.X, star.Location.Y - 1);
            if (star.Location.Y + 0x10 <= startHeight)
            {
                star.Boxed = false;
                star.State = new StaticStarState(star);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (star.IsVisible()) sprite.Draw(batch, star.Location);
        }
    }
}
