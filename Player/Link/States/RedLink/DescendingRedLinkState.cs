using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class DescendingRedLinkState : IGreenLinkState
    {
        private AnimatedSprite sprite;
        private Point collisionSize;
        private Link link;
        private $safeprojectname$ game;
        private int currentFrame;

        public DescendingRedLinkState(Link link)
        {
            collisionSize = new Point(16, 32);
            this.link = link;
            game = link.game;
            game.state.TouchFlagpole();
            link.Acceleration = new Vector2(0, -ConstantValues.PLAYER_ACCELERATION);
            link.Velocity = new Vector2(0, 125.0f);
            currentFrame = 0;
            sprite = RedLinkSpriteFactory.Instance.CreateDescendingRedLink();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(link.Location, collisionSize); } }

        public Point StartOffset
        { get { return new Point(0, 16); } }

        public void TransitionRight()
        {
            link.state = new RightAutowalkingRedLinkState(link);
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
            sprite.AnimationPlayer.Stop();
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

        }

        public void UseWeapon()
        {

        }

        public void TouchFlagpole()
        {

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
            sprite.Update(gametime);
            currentFrame++;
            if (currentFrame == 120)
                TransitionRight();
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, link.Location);
        }
    }
}
