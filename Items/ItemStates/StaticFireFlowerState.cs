using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StaticFireFlowerState : IItemState
    {
        private AnimatedSprite sprite;
        private SpriteFont font;
        private Item flower;
        float drawPoints;
        Vector2 textPos;

        public StaticFireFlowerState(Item flower)
        {
            this.flower = flower;
            flower.Gravity = false;
            flower.Velocity = new Vector2(0.0f, 0.0f);
            sprite = ItemSpriteFactory.Instance.CreateFireFlower();
            font = SpriteFontFactory.Instance.CreatePointsFont();
            sprite.AnimationPlayer.Play();
            drawPoints = 0.0f;
        }

        public void BeConsumed(IPlayer player)
        {
            player.GetFireFlower();
            player.Points += ConstantValues.POINTS_POWERUP;
            drawPoints = 1.0f;
            textPos = flower.Position;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (flower.IsVisible()) sprite.Draw(batch, flower.Location);
            if (drawPoints > 0.0f)
            {
                batch.DrawString(font, ConstantValues.POINTS_POWERUP.ToString(), textPos, ConstantValues.HUD_COLOR);
                drawPoints -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void ChangeDirection() { }
    }
}
