using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class RightBigToFireMarioTransitionState : IPlayerState
    {
        private AnimatedSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private int currentFrame;

        public RightBigToFireMarioTransitionState(Mario mario)
        {
            collisionSize = new Point(0, 0);
            currentFrame = 0;
            this.mario = mario;
            sprite = MarioTransitionSpriteFactory.Instance.CreateRightBigToFireMario();
            SoundFactory.Instance.CreateMarioPowerupSound().Play();
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

        }

        public void GetFireFlower()
        {
            if (mario.Jumping)
                mario.state = new RightJumpingFireMarioState(mario);
            else
                mario.state = new RightIdleFireMarioState(mario);
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
            mario.state = new DeadMarioState(mario);
        }

        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
            currentFrame++;
            if (currentFrame == 60)
            {
                GetFireFlower();
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, mario.Location);
        }
    }
}