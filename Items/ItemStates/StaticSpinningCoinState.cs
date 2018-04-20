using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StaticSpinningCoinState : IItemState
    {
        private Item coin;
        private AnimatedSprite sprite;

        public StaticSpinningCoinState(Item coin)
        {
            this.coin = coin;
            coin.Gravity = false;
            coin.Velocity = new Vector2(0.0f, 0.0f);
            sprite = ItemSpriteFactory.Instance.CreateSpinningCoin();
            sprite.AnimationPlayer.Play();
        }

        public void BeConsumed(IPlayer player)
        {
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (coin.IsVisible()) sprite.Draw(batch, coin.Location);
        }

        public void ChangeDirection() { }
    }
}
