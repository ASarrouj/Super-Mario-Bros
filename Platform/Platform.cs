using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Platform : IGameObject, ICollidable
    {
        public float Speed { get; set; }

        protected IPlatformState state;

        public IPlatformState State { get { return state; } set { state = value; } }

        public Rectangle CollisionRectangle
        {
            get
            {
                return state.CollisionRectangle;
            }
        }

        public Point Delta {  get { return state.Delta; } }

        public Platform(float speed)
        {
            this.Speed = speed;
        }

        public void Update(GameTime gametime)
        {
            this.state.Update(gametime);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            this.state.Draw(gametime, batch);
        }

        public static Platform CreateMovingPlatform(Point start, Point end, float speed)
        {
            Platform platform = new Platform(speed);
            platform.State = new MovingPlatformState(platform, start, end);
            return platform;
        }
    }
}
