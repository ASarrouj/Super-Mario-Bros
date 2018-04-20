using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class LeftGreenToRedLinkTransitionState : IPlayerState
    {
        private AnimatedSprite sprite;
        private Point collisionSize;
        private Link link;
        private int currentFrame;

        public LeftGreenToRedLinkTransitionState(Link link)
        {
            collisionSize = new Point(16, 29);
            currentFrame = 0;
            this.link = link;
            sprite = LinkTransitionSpriteFactory.Instance.CreateLeftGreenToRedLink();
            SoundFactory.Instance.CreateLinkPowerupSound().Play();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(link.Location, collisionSize); } }

        public Point StartOffset
        { get { return new Point(0, 16); } }

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
            if (link.Jumping)
                link.state = new LeftJumpingRedLinkState(link);
            else
                link.state = new LeftIdleRedLinkState(link);
        }

        public void GetMushroom()
        {
            if (link.Jumping)
                link.state = new LeftJumpingRedLinkState(link);
            else
                link.state = new LeftIdleRedLinkState(link);
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
            link.state = new DeadLinkState(link);
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
            sprite.Draw(batch, link.Location);
        }
    }
}