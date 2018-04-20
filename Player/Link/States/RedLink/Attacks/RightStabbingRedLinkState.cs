using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class RightStabbingRedLinkState : IRedLinkState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Link link;
        private Sword sword;
        private $safeprojectname$ game;
        private int currentFrame;

        public RightStabbingRedLinkState(Link link)
        {
            collisionSize = new Point(16, 26);
            this.link = link;
            sword = link.sword;
            sword.state = new RightCrouchingSwordState(sword);
            game = link.game;
            currentFrame = 0;
            sprite = RedLinkSpriteFactory.Instance.CreateRightStabbingRedLink();
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
            SoundFactory.Instance.CreateLinkPowerupSound().Play();
        }

        public void GetMushroom()
        {
            SoundFactory.Instance.CreateLinkPowerupSound().Play();
        }

        public void TakeDamage()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            link.state = new RightRedToGreenLinkTransitionState(link);
        }

        public void UseWeapon()
        {

        }

        public void TouchFlagpole()
        {
            link.state = new DescendingRedLinkState(link);
        }

        public void TouchAxe()
        {
            link.state = new RightAutowalkingRedLinkState(link);
        }

        public void Kill()
        {
            link.state = new DeadLinkState(link);
        }

        public void Update(GameTime gametime)
        {
            currentFrame++;
            if (currentFrame > 10)
            {
                sword.Delete();
                link.state = new RightCrouchingRedLinkState(link);
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, link.Location);
        }
    }
}