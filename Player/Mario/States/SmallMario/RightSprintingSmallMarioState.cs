 using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class RightSprintingSmallMarioState : ISmallMarioState
    {
        private AnimatedSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;

        public RightSprintingSmallMarioState(Mario mario)
        {
            collisionSize = new Point(15, 16);
            this.mario = mario;
            game = mario.game;
            sprite = SmallMarioSpriteFactory.Instance.CreateRightSprintingSmallMario();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 0); } }

        public void TransitionRight()
        {
            mario.Acceleration = new Vector2(ConstantValues.PLAYER_ACCELERATION, 0.0f);
        }

        public void TransitionLeft()
        {
            mario.Acceleration = new Vector2(-ConstantValues.PLAYER_ACCELERATION, 0.0f);
            mario.terminalVelocity.X = 130.0f;
            mario.state = new LeftSlidingSmallMarioState(mario);
        }

        public void Jump()
        {
            mario.state = new RightJumpingSmallMarioState(mario);
        }

        public void Crouch()
        {
            
        }

        public void Land()
        {

        }

        public void Idle()
        {
            mario.terminalVelocity.X = 130.0f;
            mario.state = new RightRunningSmallMarioState(mario);
        }

        public void GetFireFlower()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new RightSmallToFireMarioTransitionState(mario);
        }

        public void GetMushroom()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new RightSmallToBigMarioTransitionState(mario);
        }

        public void TakeDamage()
        {
            game.state.PlayerDying();
            mario.state = new DeadMarioState(mario);
        }

        public void UseWeapon()
        {

        }

        public void TouchFlagpole()
        {
            mario.state = new RightDescendingSmallMarioState(mario);
        }

        public void TouchAxe()
        {
            mario.state = new RightAutowalkingSmallMarioState(mario);
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