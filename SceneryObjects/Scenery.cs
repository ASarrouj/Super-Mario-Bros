using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Scenery : IGameObject
    {
        public ISceneryState State { get; set; }

        public Point Position { get; set; }

        protected Scenery(Point position)
        {
            Position = position;
        }

        public static Scenery CreateSmallHill(Point position)
        {
            Scenery scenery = new Scenery(position);
            scenery.State = new SmallHill(scenery);
            return scenery;
        }

        public static Scenery CreateBigHill(Point position)
        {
            Scenery scenery = new Scenery(position);
            scenery.State = new BigHill(scenery);
            return scenery;
        }

        public static Scenery CreateSingleCloud(Point position)
        {
            Scenery scenery = new Scenery(position);
            scenery.State = new SingleCloud(scenery);
            return scenery;
        }

        public static Scenery CreateDoubleCloud(Point position)
        {
            Scenery scenery = new Scenery(position);
            scenery.State = new DoubleCloud(scenery);
            return scenery;
        }

        public static Scenery CreateTripleCloud(Point position)
        {
            Scenery scenery = new Scenery(position);
            scenery.State = new TripleCloud(scenery);
            return scenery;
        }

        public static Scenery CreateSingleBush(Point position)
        {
            Scenery scenery = new Scenery(position);
            scenery.State = new SingleBush(scenery);
            return scenery;
        }

        public static Scenery CreateDoubleBush(Point position)
        {
            Scenery scenery = new Scenery(position);
            scenery.State = new DoubleBush(scenery);
            return scenery;
        }

        public static Scenery CreateTripleBush(Point position)
        {
            Scenery scenery = new Scenery(position);
            scenery.State = new TripleBush(scenery);
            return scenery;
        }

        public static Scenery CreateTitleBlock(Point position)
        {
            Scenery scenery = new Scenery(position);
            scenery.State = new TitleBlock(scenery);
            return scenery;
        }

        public void Update(GameTime gametime) { }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            State.Draw(gameTime, spriteBatch);
        }
    }
}
