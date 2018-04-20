using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class RightJumpingBigMarioState : IBigMarioState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;

        public RightJumpingBigMarioState(Mario mario)
        {
            collisionSize = new Point(16, 32);
            this.mario = mario;
            game = mario.game;
            sprite = BigMarioSpriteFactory.Instance.CreateRightJumpingBigMario();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 16); } }

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
            
        }

        public void Land()
        {
            mario.state = new RightIdleBigMarioState(mario);
        }

        public void Idle()
        {
            
        }

        public void GetFireFlower()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            mario.state = new RightBigToFireMarioTransitionState(mario);
        }

        public void GetMushroom()
        {

        }

        public void TakeDamage()
        {
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