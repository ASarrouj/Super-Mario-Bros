using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StaticCoinState : IItemState
    {
        private Item coin;
        private AnimatedSprite sprite;
        private SpriteFont font;
        float drawPoints;
        Vector2 textPos;

        public StaticCoinState(Item coin)
        {
            this.coin = coin;
            coin.Gravity = false;
            coin.Velocity = new Vector2(0.0f, 0.0f);
            sprite = ItemSpriteFactory.Instance.CreateCoin();
            font = SpriteFontFactory.Instance.CreatePointsFont();
            sprite.AnimationPlayer.Play();
            drawPoints = 0.0f;
        }

        public void BeConsumed(IPlayer player)
        {
            SoundFactory.Instance.CreateCoinSound().Play();
            if (player.Coins == 99)
            {
                player.Coins = 0;
                player.Lives = player.Lives + 1;
                SoundFactory.Instance.Create1UpSound().Play();
            }
            else
            {
                player.Coins++;
            }
            player.Points += ConstantValues.POINTS_COIN;
            drawPoints = 1.0f;
            textPos = coin.Position;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (coin.IsVisible()) sprite.Draw(batch, coin.Location);
            if (drawPoints > 0.0f)
            {
                batch.DrawString(font, ConstantValues.POINTS_COIN.ToString(), textPos, ConstantValues.HUD_COLOR);
                drawPoints -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void ChangeDirection() { }
    }
}
