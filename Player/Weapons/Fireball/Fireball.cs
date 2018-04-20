using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Fireball : IPhysicsObject, IWeapon
    {
        public IWeaponState state;
        public Mario mario;
        private Vector2 position;
        private PhysicsEngine physics;

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

        public Fireball(Mario mario)
        {
            this.mario = mario;
            state = new InactiveFireballState(this);
            physics = new PhysicsEngine();
        }

        public Rectangle CollisionRectangle
        {
            get { return state.CollisionRectangle; }
        }

        public IWeaponState State { get { return state; } set { state = value; } }

        public void Create()
        {
            Location = mario.Location;
            state.Create();
        }

        public void CollideWithFloor()
        {
            state.CollideWithFloor();
        }

        public void StandardCollision()
        {
            Delete();
        }

        public void Delete()
        {
            state.Delete();
        }

        public void Update(GameTime gametime)
        {
            state.Update(gametime);
            physics.Update(gametime, this);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            state.Draw(gametime, batch);
        }
    }
}
