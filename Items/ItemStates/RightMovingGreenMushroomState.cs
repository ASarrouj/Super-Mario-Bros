using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class RightMovingGreenMushroomState : IItemState
    {
        private Item mushroom;
        private StaticSprite sprite;
        private SpriteFont font;
        float drawPoints;
        Vector2 textPos;

        public RightMovingGreenMushroomState(Item mushroom)
        {
            this.mushroom = mushroom;
            mushroom.Gravity = true;
            mushroom.Velocity = new Vector2(50.0f, mushroom.Velocity.Y);
            sprite = ItemSpriteFactory.Instance.CreateGreenMushroom();
            font = SpriteFontFactory.Instance.CreatePointsFont();
            drawPoints = 0.0f;
        }

        public void ChangeDirection()
        {
            mushroom.State = new LeftMovingGreenMushroomState(mushroom);
        }

        public void BeConsumed(IPlayer player)
        {
            player.Lives = player.Lives + 1;
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
    }
}
