using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class RightBigToSmallMarioTransitionState : IPlayerState
    {
        private AnimatedSprite sprite;
        private Point collisionSize, oldLocation;
        private Mario mario;
        private int currentFrame;

        public RightBigToSmallMarioTransitionState(Mario mario)
        {
            collisionSize = new Point(0, 0);
            currentFrame = 0;
            this.mario = mario;
            oldLocation = mario.Location;
            mario.Location = new Point(mario.Location.X, mario.Location.Y + 16);
            sprite = MarioTransitionSpriteFactory.Instance.CreateRightBigToSmallMario();
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

        }

        public void GetMushroom()
        {

        }

        public void TakeDamage()
        {
            mario.invincible = true;
            if (mario.Jumping)
                mario.state = new RightJumpingSmallMarioState(mario);
            else
                mario.state = new RightIdleSmallMarioState(mario);
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
                TakeDamage();
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            if ((sprite.AnimationPlayer.FrameIndex) == 0)
                sprite.Draw(batch, mario.Location);
            else
                sprite.Draw(batch, oldLocation);
        }
    }
}