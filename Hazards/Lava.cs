using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class Lava : IHazard
    {
        private Point Position { get; set; }

        private StaticSprite sprite;

        public Lava(Point position)
        {
            Position = position;
            sprite = HazardSpriteFactory.Instance.CreateLava();
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(Position, ConstantValues.BLOCK_SIZE);
            }
        }

        public bool InstantDeath { get { return true; } }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, Position);
        }

        public void Update(GameTime gametime) { }
    }
}
