using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Pipe : IGameObject, ICollidable
    {
        public IPipeState State { get; set; }

        public Point Position { get; set; }

        public Rectangle CollisionRectangle { get { return State.CollisionRectangle; } }

        public bool HasDestination { get { return !string.IsNullOrWhiteSpace(DestinationLevel); } }

        public string DestinationLevel { get; set; }

        public Point DestinationPoint { get; set; }

        protected Pipe(Point position)
        {
            Position = position;
        }

        public static Pipe CreateUpPipe(Point position)
        {
            Pipe pipe = new Pipe(position);
            pipe.State = new UpPipeState(pipe);
            return pipe;
        }

        public static Pipe CreateLeftPipe(Point position)
        {
            Pipe pipe = new Pipe(position);
            pipe.State = new LeftPipeState(pipe);
            return pipe;
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            State.Draw(gameTime, spriteBatch);
        }
    }
}
