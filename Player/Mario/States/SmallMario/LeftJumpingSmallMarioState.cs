using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class LeftJumpingSmallMarioState : ISmallMarioState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;

        public LeftJumpingSmallMarioState(Mario mario)
        {
            collisionSize = new Point(16, 16);
            this.mario = mario;
            game = mario.game;
            sprite = SmallMarioSpriteFactory.Instance.CreateLeftJumpingSmallMario();
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
        }

        public void Jump()
        {

        }

        public void Crouch()
        {
            mario.state = new LeftIdleSmallMarioState(mario);
        }

        public void Land()
        {
            mario.state = new LeftIdleSmallMarioState(mario);
        }

        public void Idle()
        {
            
        }

        public void GetFireFlower()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new LeftSmallToFireMarioTransitionState(mario);
        }

        public void GetMushroom()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new LeftSmallToBigMarioTransitionState(mario);
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

        public void Update(GameTime gametime) { }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, mario.Location);
        }
    }
}