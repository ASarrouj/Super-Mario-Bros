using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class LeftCrouchingFireMarioState : IFireMarioState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;

        public LeftCrouchingFireMarioState(Mario mario)
        {
            collisionSize = new Point(16, 22);
            this.mario = mario;
            game = mario.game;
            sprite = FireMarioSpriteFactory.Instance.CreateLeftCrouchingFireMario();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 6); } }

        public void TransitionRight()
        {
            mario.Location = new Point(mario.Location.X, mario.Location.Y - 10);
            mario.state = new RightIdleFireMarioState(mario);
        }

        public void TransitionLeft()
        {
            Idle();
        }

        public void Jump()
        {
            
        }

        public void Crouch() { }

        public void Land()
        {

        }

        public void Idle()
        {
            mario.Location = new Point(mario.Location.X, mario.Location.Y - 10);
            mario.state = new LeftIdleFireMarioState(mario);
        }

        public void GetFireFlower() { }

        public void GetMushroom()
        {
            
        }

        public void TakeDamage()
        {
            mario.Location = new Point(mario.Location.X, mario.Location.Y - 10);
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new LeftFireToSmallMarioTransitionState(mario);
            SoundFactory.Instance.CreatePlayerDamageSound().Play();
        }

        public void UseWeapon()
        {

        }

        public void TouchFlagpole()
        {
            mario.state = new RightDescendingFireMarioState(mario);
        }

        public void TouchAxe()
        {
            mario.state = new RightAutowalkingFireMarioState(mario);
        }

        public void Kill()
        {
            mario.state = new DeadMarioState(mario);
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