using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class UnboxingSpinningCoinState : IItemState
    {
        private Item sCoin;
        private AnimatedSprite sprite;
        private SpriteFont font;
        private int startHeight;
        private int bump;
        private float timer;
        private IPlayer player;
        float drawPoints;
        Vector2 textPos;

        public UnboxingSpinningCoinState(Item sCoin, IPlayer player)
        {
            this.sCoin = sCoin;
            this.player = player;
            sCoin.Gravity = true;
            bump = 0;
            startHeight = sCoin.Location.Y;
            sprite = ItemSpriteFactory.Instance.CreateSpinningCoin();
            font = SpriteFontFactory.Instance.CreatePointsFont();
            sprite.AnimationPlayer.Play();
            timer = 0.0f;
            SoundFactory.Instance.CreateCoinSound().Play();
            drawPoints = 1.0f;
            textPos = sCoin.Position;
            textPos.Y -= 0x20;
        }

        public void BeConsumed(IPlayer player)
        {
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
            player.Points += 200;
        }

        public void Update(GameTime gameTime)
        {
            if (bump < 2) {
                sCoin.Velocity = new Vector2(0.0f, -450.0f);
                bump++;
            } else
            {
                sCoin.Velocity += new Vector2(0.0f, 50.0f);
            }


            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (sCoin.Location.Y >= startHeight && timer > 0.1f && sCoin.Boxed)
            {
                sCoin.BeConsumed(player);
                sCoin.Boxed = false;
            }

            sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (sCoin.IsVisible()) sprite.Draw(batch, sCoin.Location);
            if (drawPoints > 0.0f)
            {
                batch.DrawString(font, "200", textPos, ConstantValues.HUD_COLOR);
                drawPoints -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void ChangeDirection() { }
    }
}
