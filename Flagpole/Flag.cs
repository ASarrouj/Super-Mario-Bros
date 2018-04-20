using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Flag : IGameObject
    {
        private StaticSprite sprite;
        private bool descending;
        private int distance;
        public Point Position { get; set; }

        public Flag(Point position)
        {
            Position = position;
            distance = 0;
            descending = false;
            sprite = EndObjectSpriteFactory.Instance.CreateFlag();
        }

        public void LowerFlag()
        {
            descending = true;
        }

        public Rectangle CollisionRectangle { get { return new Rectangle(Position + new Point(14, 0), new Point(2, 152)); } }

        public void Update(GameTime gameTime)
        {
            if (descending)
            {
                Position = new Point(Position.X, Position.Y + 2);
                distance += 2;
                if (distance >= 120)
                    descending = false;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }
    }
}