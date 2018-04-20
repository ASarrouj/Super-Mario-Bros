using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftMovingBowserFireballState : IProjectileState
    {
        private Point collisionSize;
        private AnimatedSprite sprite;
        private BowserFireball fireball;

        public LeftMovingBowserFireballState(BowserFireball fireball)
        {
            this.fireball = fireball;
            collisionSize = new Point(0x18, 0x8);
            fireball.Velocity = new Vector2(-75.0f, 0.0f);
            sprite = FireballSpriteFactory.Instance.CreateLeftBowserFireball();
        }

        public void Create()
        {

        }

        public void Delete()
        {
            fireball.state = new InactiveBowserFireballState(fireball);
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(fireball.Location, collisionSize);
            }
        }

        public void Update(GameTime gameTime)
        {
            fireball.Position += (float)gameTime.ElapsedGameTime.TotalSeconds * fireball.Velocity;
            sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            sprite.Draw(batch, fireball.Location);
        }
    }
}