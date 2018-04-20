using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class UnboxingGreenMushroomState : IItemState
    {
        private Item shroom;
        private StaticSprite sprite;
        private int startHeight;
        private bool marioIsLeft;

        public UnboxingGreenMushroomState(Item shroom, int marioPosX)
        {
            this.shroom = shroom;
            shroom.Gravity = false;
            startHeight = shroom.Location.Y;
            marioIsLeft = shroom.Location.X > marioPosX;
            shroom.Velocity = new Vector2(0.0f, 0.0f);
            sprite = ItemSpriteFactory.Instance.CreateGreenMushroom();
            SoundFactory.Instance.CreatePowerupAppearsSound().Play();
        }

        public void BeConsumed(IPlayer player)
        {
        }

        public void Update(GameTime gameTime)
        {
            shroom.Location = new Point(shroom.Location.X, shroom.Location.Y - 1);
            if (shroom.Location.Y + 0x10 <= startHeight)
            {
                shroom.Boxed = false;
                if (marioIsLeft) shroom.State = new RightMovingGreenMushroomState(shroom);
                else shroom.State = new LeftMovingGreenMushroomState(shroom);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (shroom.IsVisible()) sprite.Draw(batch, shroom.Location);
        }

        public void ChangeDirection() { }
    }
}
