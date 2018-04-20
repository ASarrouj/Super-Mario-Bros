using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class RightCrouchingBigMarioState : IBigMarioState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;

        public RightCrouchingBigMarioState(Mario mario)
        {
            collisionSize = new Point(16, 22);
            this.mario = mario;
            game = mario.game;
            sprite = BigMarioSpriteFactory.Instance.CreateRightCrouchingBigMario();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 6); } }

        public void TransitionRight()
        {
            Idle();
        }

        public void TransitionLeft()
        {
            mario.Location = new Point(mario.Location.X, mario.Location.Y - 10);
            mario.state = new LeftIdleBigMarioState(mario);
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
            mario.Location = new Point(mario.Location.X, mario.Location.Y - 10);
            mario.state = new RightIdleBigMarioState(mario);
        }

        public void GetFireFlower()
        {
            mario.Location = new Point(mario.Location.X, mario.Location.Y - 10);
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new RightBigToFireMarioTransitionState(mario);
        }

        public void GetMushroom()
        {

        }

        public void TakeDamage()
        {
            mario.Location = new Point(mario.Location.X, mario.Location.Y - 10);
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new RightBigToSmallMarioTransitionState(mario);
            SoundFactory.Instance.CreatePlayerDamageSound().Play();
        }

        public void UseWeapon()
        {

        }

        public void TouchFlagpole()
        {
            mario.state = new RightDescendingBigMarioState(mario);
        }

        public void TouchAxe()
        {
            mario.state = new RightAutowalkingBigMarioState(mario);
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