﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class RightMovingRedMushroomState : IItemState
    {
        private Item mushroom;
        private StaticSprite sprite;
        private SpriteFont font;
        float drawPoints;
        Vector2 textPos;

        public RightMovingRedMushroomState(Item mushroom)
        {
            this.mushroom = mushroom;
            mushroom.Gravity = true;
            mushroom.Velocity = new Vector2(50.0f, mushroom.Velocity.Y);
            sprite = ItemSpriteFactory.Instance.CreateRedMushroom();
            font = SpriteFontFactory.Instance.CreatePointsFont();
            drawPoints = 0.0f;
        }

        public void ChangeDirection()
        {
            mushroom.State = new LeftMovingRedMushroomState(mushroom);
        }

        public void BeConsumed(IPlayer player)
        {
            player.GetMushroom();
            player.Points += ConstantValues.POINTS_POWERUP;
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
                batch.DrawString(font, ConstantValues.POINTS_POWERUP.ToString(), textPos, ConstantValues.HUD_COLOR);
                drawPoints -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
