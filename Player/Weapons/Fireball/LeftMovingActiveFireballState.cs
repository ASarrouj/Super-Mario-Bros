using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftMovingActiveFireballState : IWeaponState, IActiveWeaponState
    {
        private Point collisionSize;
        private AnimatedSprite sprite;
        private Fireball fireball;
        private bool bounced;

        public LeftMovingActiveFireballState(Fireball fireball)
        {
            this.fireball = fireball;
            collisionSize = new Point(8, 8);
            fireball.Velocity = new Vector2(-300.0f, 300.0f);
            bounced = false;
            sprite = FireballSpriteFactory.Instance.CreateActiveFireball();
            SoundFactory.Instance.CreateFireballSound().Play();
        }

        public void Create()
        {

        }

        public void Delete()
        {
            fireball.state = new DestroyedFireballState(fireball);
        }

        public void CollideWithFloor()
        {
            Bounce();
        }

        public void Bounce()
        {
            if (bounced)
                fireball.Velocity = new Vector2(fireball.Velocity.X, -(fireball.Velocity.Y));
            else
            {
                fireball.Velocity = new Vector2(fireball.Velocity.X, -(fireball.Velocity.Y / 3));
                bounced = true;
            }
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
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, fireball.Location);
        }
    }
}