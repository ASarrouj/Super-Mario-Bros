using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class MovingPlatformState : IPlatformState
    {
        protected static readonly Point PLATFORM_SIZE = new Point(32, 8);

        private StaticSprite sprite;

        private Platform platform;

        private float progress = 0.0f;

        private Vector2 start, end;

        private Vector2 position;

        private Point Location {  get { return position.ToPoint(); } }

        public Rectangle CollisionRectangle {  get { return new Rectangle(Location, PLATFORM_SIZE); } }

        private Point lastLocation;

        public Point Delta {  get { return Location - lastLocation; } }

        public MovingPlatformState(Platform platform, Point start, Point end)
        {
            this.sprite = PlatformSpriteFactory.Instance.CreateSmallPlatformSprite();
            this.platform = platform;
            this.lastLocation = start;
            this.position = this.start = new Vector2(start.X, start.Y);
            this.end = new Vector2(end.X, end.Y);
        }

        public void Update(GameTime gametime)
        {
            lastLocation = Location;

            float pathLength = (start - end).Length();
            float distanceTraveled = platform.Speed * (float)gametime.ElapsedGameTime.TotalSeconds;

            if (pathLength < 0.001f)
                return;

            progress = MathHelper.Clamp(progress + distanceTraveled / pathLength, 0, 1.0f);

            position = Vector2.Lerp(start, end, progress);

            if (progress > 0.99f)
                platform.State = new MovingPlatformState(platform, end.ToPoint(), start.ToPoint());
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, Location);
        }
    }
}
