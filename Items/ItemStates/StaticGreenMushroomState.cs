using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StaticGreenMushroomState : IItemState
    {
        private Item mushroom;
        private StaticSprite sprite;
        private SpriteFont font;
        float drawPoints;
        Vector2 textPos;

        public StaticGreenMushroomState(Item mushroom)
        {
            this.mushroom = mushroom;
            mushroom.Gravity = !mushroom.Boxed;
            mushroom.Velocity = new Vector2(0.0f, 0.0f);
            sprite = ItemSpriteFactory.Instance.CreateGreenMushroom();
            font = SpriteFontFactory.Instance.CreatePointsFont();
            drawPoints = 0.0f;
        }

        public void BeConsumed(IPlayer player)
        {
            player.Lives = player.Lives + 1;
            player.Points += 100;
            SoundFactory.Instance.Create1UpSound().Play();
            drawPoints = 1.0f;
            textPos = mushroom.Position;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (mushroom.IsVisible()) sprite.Draw(batch, mushroom.Location);
            if (drawPoints > 0.0f)
            {
                batch.DrawString(font, "1-UP", textPos, ConstantValues.HUD_COLOR);
                drawPoints -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void ChangeDirection() { }
    }
}
