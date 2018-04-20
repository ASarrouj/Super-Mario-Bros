using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class BowserFireball : IPhysicsObject, IProjectile
    {
        public IProjectileState state;
        public IEnemy bowser;
        private Vector2 position;

        public Point Location
        {
            get { return position.ToPoint(); }
            set { position = new Vector2(value.X, value.Y); }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration
        {
            get { return Vector2.Zero; }
            set { }
        }

        public BowserFireball(IEnemy bowser)
        {
            this.bowser = bowser;
            state = new InactiveBowserFireballState(this);
        }

        public Rectangle CollisionRectangle
        {
            get { return state.CollisionRectangle; }
        }

        public IProjectileState State { get { return state; } set { state = value; } }

        public void Create()
        {
            Location = new Point(bowser.Location.X, bowser.CollisionRectangle.Top + 0x8);
            SoundFactory.Instance.CreateBowserFireSound().Play();
            state.Create();
        }

        public void Delete()
        {
            state.Delete();
        }

        public void Update(GameTime gametime)
        {
            state.Update(gametime);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            state.Draw(gametime, batch);
        }
    }
}
