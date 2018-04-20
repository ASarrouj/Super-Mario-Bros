using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class InactiveSwordState : IWeaponState
    {

        public InactiveSwordState(Sword sword)
        {
            
        }
        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(0, 0, 0, 0);
            }
        }

        public void Create()
        {
            
        }

        public void Delete()
        {

        }
        public void CollideWithFloor()
        {

        }

        public void Update(GameTime gametime)
        {

        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {

        }
    }
}