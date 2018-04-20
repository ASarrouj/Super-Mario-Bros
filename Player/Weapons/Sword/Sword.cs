using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Sword :  IWeapon
    {
        public IWeaponState state;
        public Link link;
        private Vector2 position;

        public Point Location
        {
            get { return position.ToPoint(); }
            set { position = new Vector2(value.X, value.Y); }
        }

        public Sword(Link link)
        {
            this.link = link;
            state = new InactiveSwordState(this);
        }

        public Rectangle CollisionRectangle
        {
            get { return state.CollisionRectangle; }
        }

        public IWeaponState State { get { return state; } set { state = value; } }

        public void Create()
        {
            state.Create();
        }

        public void CollideWithFloor()
        {
            
        }

        public void StandardCollision()
        {
            
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