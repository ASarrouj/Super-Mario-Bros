using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class EndObject : IGameObject
    {
        public IEndObjectState State { get; set; }

        public Point Position { get; set; }

        protected EndObject(Point position)
        {
            Position = position;
        }

        public static EndObject CreateCastle(Point position)
        {
            EndObject endObject = new EndObject(position);
            endObject.State = new Castle(endObject);
            return endObject;
        }

        public static EndObject CreateToad(Point position)
        {
            EndObject endObject = new EndObject(position);
            endObject.State = new Toad(endObject);
            return endObject;
        }

        public void Update(GameTime gametime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            State.Draw(gameTime, spriteBatch);
        }
    }
}
