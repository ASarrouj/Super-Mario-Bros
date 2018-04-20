using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class LeftSprintingBigMarioState : IBigMarioState
    {
        private AnimatedSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;

        public LeftSprintingBigMarioState(Mario mario)
        {
            collisionSize = new Point(16, 32);
            this.mario = mario;
            game = mario.game;
            sprite = BigMarioSpriteFactory.Instance.CreateLeftSprintingBigMario();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 16); } }

        public void TransitionRight()
        {
            mario.Acceleration = new Vector2(ConstantValues.PLAYER_ACCELERATION, 0.0f);
            mario.terminalVelocity.X = 130.0f;
            mario.state = new RightSlidingBigMarioState(mario);
        }

        public void TransitionLeft()
        {
            mario.Acceleration = new Vector2(-ConstantValues.PLAYER_ACCELERATION, 0.0f);
        }

        public void Jump()
        {
            mario.state = new LeftJumpingBigMarioState(mario);
        }

        public void Crouch()
        {
            mario.Location = new Point(mario.Location.X, mario.Location.Y + 10);
            mario.terminalVelocity.X = 130.0f;
            mario.state = new LeftCrouchingBigMarioState(mario);
        }

        public void Land()
        {

        }

        public void Idle()
        {
            mario.terminalVelocity.X = 130.0f;
            mario.state = new LeftRunningBigMarioState(mario);
        }

        public void GetFireFlower()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new LeftBigToFireMarioTransitionState(mario);
        }

        public void GetMushroom()
        {

        }

        public void TakeDamage()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new LeftBigToSmallMarioTransitionState(mario);
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
            sprite.Update(gametime);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, mario.Location);
        }
    }
}