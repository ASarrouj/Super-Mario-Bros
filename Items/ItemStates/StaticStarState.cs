using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StaticStarState : IItemState
    {
        private AnimatedSprite sprite;
        private SpriteFont font;
        private Item star;
        float drawPoints;
        Vector2 textPos;

        public StaticStarState(Item star)
        {
            this.star = star;
            star.Gravity = !star.Boxed;
            star.Velocity = new Vector2(0.0f, 0.0f);
            sprite = ItemSpriteFactory.Instance.CreateStar();
            font = SpriteFontFactory.Instance.CreatePointsFont();
            sprite.AnimationPlayer.Play();
            drawPoints = 0.0f;
        }

        public void BeConsumed(IPlayer player)
        {
            player.GetStar();
            player.Points += ConstantValues.POINTS_POWERUP;
            drawPoints = 1.0f;
            textPos = star.Position;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (star.IsVisible()) sprite.Draw(batch, star.Location);
            if (drawPoints > 0.0f)
            {
                batch.DrawString(font, ConstantValues.POINTS_POWERUP.ToString(), textPos, ConstantValues.HUD_COLOR);
                drawPoints -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void ChangeDirection() { }
    }
}
