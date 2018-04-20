using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class RightAutowalkingGreenLinkState : IGreenLinkState
    {
        private AnimatedSprite sprite;
        private Point collisionSize;
        private Link link;
        private $safeprojectname$ game;
        private bool castleReached;

        public RightAutowalkingGreenLinkState(Link link)
        {
            collisionSize = new Point(16, 32);
            this.link = link;
            link.Acceleration = Vector2.Zero;
            link.Velocity = new Vector2(ConstantValues.PLAYER_AUTOWALK_VELOCITY, 0f);
            game = link.game;
            castleReached = false;
            sprite = GreenLinkSpriteFactory.Instance.CreateRightRunningGreenLink();
            link.Auto = true;
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(link.Location, collisionSize); } }

        public Point StartOffset
        { get { return new Point(0, 16); } }

        public void TransitionRight()
        {
            castleReached = true;
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
            link.state = new RightIdleGreenLinkState(link);
        }

        public void GetFireFlower()
        {

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
            link.state = new DeadLinkState(link);
        }

        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            if (!castleReached)
                sprite.Draw(batch, link.Location);
        }
    }
}