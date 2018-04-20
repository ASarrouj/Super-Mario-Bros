using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class LeftShootingFireMarioState : IFireMarioState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;
        private int currentFrame;

        public LeftShootingFireMarioState(Mario mario)
        {
            collisionSize = new Point(16, 32);
            currentFrame = 0;
            this.mario = mario;
            game = mario.game;
            sprite = FireMarioSpriteFactory.Instance.CreateLeftShootingFireMario();
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
            mario.state = new LeftJumpingFireMarioState(mario);
        }

        public void Crouch()
        {
            
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
            currentFrame++;
            if (currentFrame == 15)
            {
                if (mario.Jumping)
                    mario.state = new LeftJumpingFireMarioState(mario);
                else
                    mario.state = new LeftIdleFireMarioState(mario);
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, mario.Location);
        }
    }
}