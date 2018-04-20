using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class DeadMarioState : IPlayerState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;

        public DeadMarioState(Mario mario)
        {
            collisionSize = new Point(16, 16);
            this.mario = mario;
            game = mario.game;
            mario.Velocity = new Vector2(0.0f, -300.0f);
            mario.Acceleration = Vector2.Zero;
            sprite = SmallMarioSpriteFactory.Instance.CreateDeadMario();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 0); } }

        public void TransitionRight()
        {

        }

        public void TransitionLeft()
        {
            
        }

        public void Jump()
        {
            
        }

        public void Crouch()
        {
            
        }

        public void Land()
        {

        }

        public void Idle()
        {
            mario.state = new RightIdleSmallMarioState(mario);
        }

        public void GetFireFlower()
        {
            
        }

        public void GetMushroom()
        {
            
        }

        public void TakeDamage()
        {

        }

        public void UseWeapon()
        {

        }

        public void TouchFlagpole()
        {

        }

        public void TouchAxe()
        {

        }

        public void Kill()
        {
            
        }

        public void Update(GameTime gametime)
        {
            
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, mario.Location);
        }
    }
}