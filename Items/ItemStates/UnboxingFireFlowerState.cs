using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class UnboxingFireFlowerState : IItemState
    {
        private Item flower;
        private AnimatedSprite sprite;
        private int startHeight;

        public UnboxingFireFlowerState(Item flower)
        {
            this.flower = flower;
            flower.Gravity = false;
            startHeight = flower.Location.Y;
            flower.Velocity = new Vector2(0.0f, 0.0f);
            sprite = ItemSpriteFactory.Instance.CreateFireFlower();
            sprite.AnimationPlayer.Play();
            SoundFactory.Instance.CreatePowerupAppearsSound().Play();
        }

        public void BeConsumed(IPlayer player)
        {
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            flower.Location = new Point(flower.Location.X, flower.Location.Y - 1);
            if (flower.Location.Y + 0x10 <= startHeight)
            {
                flower.Boxed = false;
                flower.State = new StaticFireFlowerState(flower);
            }
        }

        public void ChangeDirection() { }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (flower.IsVisible()) sprite.Draw(batch, flower.Location);
        }
    }
}
