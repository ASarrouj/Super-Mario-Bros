using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class RightRedToGreenLinkTransitionState : IPlayerState
    {
        private AnimatedSprite sprite;
        private Point collisionSize;
        private Link link;
        private int currentFrame;

        public RightRedToGreenLinkTransitionState(Link link)
        {
            collisionSize = new Point(16, 29);
            currentFrame = 0;
            this.link = link;
            sprite = LinkTransitionSpriteFactory.Instance.CreateRightRedToGreenLink();
            SoundFactory.Instance.CreatePlayerDamageSound().Play();
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

        }

        public void GetMushroom()
        {

        }

        public void TakeDamage()
        {
            link.invincible = true;
            if (link.Jumping)
                link.state = new RightJumpingGreenLinkState(link);
            else
                link.state = new RightIdleGreenLinkState(link);
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
                TakeDamage();
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, link.Location);
        }
    }
}