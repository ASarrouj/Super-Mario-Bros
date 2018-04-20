using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class RightIdleGreenLinkState : IGreenLinkState
    {
        protected StaticSprite sprite;
        private Point collisionSize;
        private Link link;
        private $safeprojectname$ game;

        public RightIdleGreenLinkState(Link link)
        {
            collisionSize = new Point(16, 32);
            this.link = link;
            game = link.game;
            sprite = GreenLinkSpriteFactory.Instance.CreateRightIdleGreenLink();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(link.Location, collisionSize); } }

        public Point StartOffset
        { get { return new Point(0, 16); } }

        public void TransitionRight()
        {
            link.Acceleration = new Vector2(ConstantValues.PLAYER_ACCELERATION, 0.0f);
            link.state = new RightRunningGreenLinkState(link);
        }

        public void TransitionLeft()
        {
            link.Acceleration = new Vector2(-ConstantValues.PLAYER_ACCELERATION, 0.0f);
            link.state = new LeftIdleGreenLinkState(link);
        }

        public void Jump()
        {
            link.state = new RightJumpingGreenLinkState(link);
        }

        public void Crouch()
        {
            link.Location = new Point(link.Location.X, link.Location.Y + 5);
            link.state = new RightCrouchingGreenLinkState(link);
        }

        public void Land()
        {

        }

        public void Idle()
        {

        }

        public void GetFireFlower()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            link.state = new RightGreenToRedLinkTransitionState(link);
        }

        public void GetMushroom()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            link.state = new RightGreenToRedLinkTransitionState(link);
        }

        public void TakeDamage()
        {
            game.state.PlayerDying();
            link.state = new DeadLinkState(link);
        }

        public void UseWeapon()
        {
            link.state = new RightSlashingGreenLinkState(link);
        }

        public void TouchFlagpole()
        {
            link.state = new DescendingGreenLinkState(link);
        }

        public void TouchAxe()
        {
            link.state = new RightAutowalkingGreenLinkState(link);
        }

        public void Kill()
        {
            link.state = new DeadLinkState(link);
        }

        public void Update(GameTime gametime) { }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, link.Location);
        }
    }
}
