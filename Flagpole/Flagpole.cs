using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Flagpole : ICollidable
    {
        private Flag flag;
        private StaticSprite sprite;
        private SpriteFont font;
        private Point collisionSize;
        private string text;
        private float textTimer;
        private int marioHeight;
        public Point Position { get; set; }
        private bool fullMast;
        public bool FullMast { get { return fullMast; } }

        public Flagpole(Point position)
        {
            Position = position;
            collisionSize = new Point(2, 152);
            flag = new Flag(new Point(position.X - 12, position.Y + 9));
            sprite = EndObjectSpriteFactory.Instance.CreateFlagpole();
            font = SpriteFontFactory.Instance.CreatePointsFont();
            textTimer = 0.0f;
            fullMast = true;
        }

        public void LowerFlag()
        {
            flag.LowerFlag();
            collisionSize = Point.Zero;
            fullMast = false; 
        }

        public void DisplayReward(string flagpoleReward, int marioHeight)
        {
            textTimer = 3.0f;
            text = flagpoleReward;
            this.marioHeight = marioHeight;
        }

        public Rectangle CollisionRectangle { get { return new Rectangle(Position + new Point(3, 0), collisionSize); } }

        public void Update(GameTime gameTime)
        {
            flag.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
            flag.Draw(gameTime, spriteBatch);
            if (textTimer > 0.0f)
            {
                spriteBatch.DrawString(font, text, new Vector2(Position.X, marioHeight), ConstantValues.HUD_COLOR);
                textTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
