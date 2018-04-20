using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class DestroyedFireballState : IWeaponState
    {
        private Point collisionSize;
        private AnimatedSprite sprite;
        private Fireball fireball;
        private int currentFrame;

        public DestroyedFireballState(Fireball fireball)
        {
            this.fireball = fireball;
            collisionSize = new Point(0, 0);
            fireball.Velocity = new Vector2(0, 0);
            currentFrame = 0;
            sprite = FireballSpriteFactory.Instance.CreateDestroyedFireball();
        }

        public void Create()
        {

        }

        public void Delete()
        {
            fireball.state = new InactiveFireballState(fireball);
        }

        public void CollideWithFloor()
        {

        }

        public void Bounce()
        {
            
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(fireball.Location, collisionSize);
            }
        }

        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);

            currentFrame++;
            if (currentFrame == 4)
                Delete();
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, fireball.Location);
        }
    }
}