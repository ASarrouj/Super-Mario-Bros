using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftCrouchingRedLinkState : IRedLinkState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Link link;
        private $safeprojectname$ game;
    
        public LeftCrouchingRedLinkState(Link link)
        {
            collisionSize = new Point(16, 27);
            this.link = link;
            game = link.game;
            sprite = RedLinkSpriteFactory.Instance.CreateLeftCrouchingRedLink();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(link.Location, collisionSize); } }

        public Point StartOffset
        { get { return new Point(0, 16); } }

        public void TransitionRight()
        {
            link.Location = new Point(link.Location.X, link.Location.Y - 5);
            link.state = new RightIdleRedLinkState(link);
        }

        public void TransitionLeft()
        {
            Idle();
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
            link.Location = new Point(link.Location.X, link.Location.Y - 5);
            link.state = new LeftIdleRedLinkState(link);
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
            link.state = new LeftRedToGreenLinkTransitionState(link);
        }

        public void UseWeapon()
        {
            link.state = new LeftStabbingRedLinkState(link);
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

        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, link.Location);
        }
    }
}
