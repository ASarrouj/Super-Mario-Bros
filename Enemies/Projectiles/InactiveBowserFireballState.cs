using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{   
    class InactiveBowserFireballState : IProjectileState
    {
        private IEnemy bowser;
        private BowserFireball fireball;

        public InactiveBowserFireballState(BowserFireball fireball)
        {
            this.fireball = fireball;
            bowser = fireball.bowser;
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
            fireball.state = new LeftMovingBowserFireballState(fireball);
        }

        public void Delete()
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
