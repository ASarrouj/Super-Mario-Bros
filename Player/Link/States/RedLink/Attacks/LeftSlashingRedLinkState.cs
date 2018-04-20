using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class LeftSlashingRedLinkState : IGreenLinkState
    {
        private StaticSprite sprite1, sprite2;
        private Point collisionSize;
        private Link link;
        private Sword sword;
        private $safeprojectname$ game;
        private int currentFrame;

        public LeftSlashingRedLinkState(Link link)
        {
            collisionSize = new Point(20, 32);
            this.link = link;
            sword = link.sword;
            game = link.game;
            currentFrame = 0;
            sprite1 = RedLinkSpriteFactory.Instance.CreateLeftSlashingRedLink1();
            sprite2 = RedLinkSpriteFactory.Instance.CreateLeftSlashingRedLink2();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(link.Location, collisionSize); } }

        public Point StartOffset
        { get { return new Point(0, 16); } }

        public void TransitionRight()
        {
            link.Acceleration = new Vector2(ConstantValues.PLAYER_ACCELERATION, 0.0f);
        }

        public void TransitionLeft()
        {
            link.Acceleration = new Vector2(-ConstantValues.PLAYER_ACCELERATION, 0.0f);
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
            if (currentFrame == 10)
                sword.state = new LeftStandingSwordState(sword);
            else if (currentFrame == 20)
                sword.Delete();
            else if (currentFrame > 40)
            {
                if (link.Jumping)
                    link.state = new LeftJumpingRedLinkState(link);
                else
                    link.state = new LeftIdleRedLinkState(link);
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            if (currentFrame >= 10 & currentFrame < 20)
                sprite2.Draw(batch, link.Location);
            else
                sprite1.Draw(batch, link.Location);
        }
    }
}