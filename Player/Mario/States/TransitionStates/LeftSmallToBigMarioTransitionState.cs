using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class LeftSmallToBigMarioTransitionState : IPlayerState
    {
        private AnimatedSprite sprite;
        private Point collisionSize, oldLocation;
        private Mario mario;
        private int currentFrame;

        public LeftSmallToBigMarioTransitionState(Mario mario)
        {
            collisionSize = new Point(0, 0);
            currentFrame = 0;
            this.mario = mario;
            oldLocation = mario.Location;
            mario.Location = new Point(mario.Location.X, mario.Location.Y - 16);
            sprite = MarioTransitionSpriteFactory.Instance.CreateLeftSmallToBigMario();
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

        }

        public void GetMushroom()
        {
            if (mario.Jumping)
                mario.state = new LeftJumpingBigMarioState(mario);
            else
                mario.state = new LeftIdleBigMarioState(mario);
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
                GetMushroom();
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