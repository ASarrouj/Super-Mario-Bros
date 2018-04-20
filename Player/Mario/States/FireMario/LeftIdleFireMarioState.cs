using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class LeftIdleFireMarioState : IFireMarioState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;

        public LeftIdleFireMarioState(Mario mario)
        {
            collisionSize = new Point(16, 32);
            this.mario = mario;
            game = mario.game;
            sprite = FireMarioSpriteFactory.Instance.CreateLeftIdleFireMario();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 16); } }

        public void TransitionRight()
        {
            mario.Acceleration = new Vector2(ConstantValues.PLAYER_ACCELERATION, 0.0f);
            mario.state = new RightIdleFireMarioState(mario);
        }

        public void TransitionLeft()
        {
            mario.Acceleration = new Vector2(-ConstantValues.PLAYER_ACCELERATION, 0.0f);
            mario.state = new LeftRunningFireMarioState(mario);
        }

        public void Jump()
        {
            mario.state = new LeftJumpingFireMarioState(mario);
        }

        public void Crouch()
        {
            mario.Location = new Point(mario.Location.X, mario.Location.Y + 10);
            mario.state = new LeftCrouchingFireMarioState(mario);
        }

        public void Land()
        {

        }

        public void Idle()
        {
            
        }

        public void GetFireFlower()
        {

        }

        public void GetMushroom()
        {
            
        }

        public void TakeDamage()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new LeftFireToSmallMarioTransitionState(mario);
            SoundFactory.Instance.CreatePlayerDamageSound().Play();
        }

        public void UseWeapon()
        {
            mario.state = new LeftShootingFireMarioState(mario);
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