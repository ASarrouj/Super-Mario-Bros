using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{   
    class InactiveFireballState : IWeaponState
    {
        private Mario mario;
        private Fireball fireball;

        public InactiveFireballState(Fireball fireball)
        {
            this.fireball = fireball;
            mario = fireball.mario;
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
            if (mario.state is LeftShootingFireMarioState)
                fireball.state = new LeftMovingActiveFireballState(fireball);
            else if (mario.state is RightShootingFireMarioState)
                fireball.state = new RightMovingActiveFireballState(fireball);
        }

        public void Delete()
        {

        }
        public void CollideWithFloor()
        {

        }

        public void Bounce()
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
