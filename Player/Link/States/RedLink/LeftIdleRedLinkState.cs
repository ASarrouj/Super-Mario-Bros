﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftIdleRedLinkState : IRedLinkState
    {
        protected StaticSprite sprite;
        private Point collisionSize;
        private Link link;
        private $safeprojectname$ game;

        public LeftIdleRedLinkState(Link link)
        {
            collisionSize = new Point(16, 32);
            this.link = link;
            game = link.game;
            sprite = RedLinkSpriteFactory.Instance.CreateLeftIdleRedLink();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(link.Location, collisionSize); } }

        public Point StartOffset
        { get { return new Point(0, 16); } }

        public void TransitionRight()
        {
            link.Acceleration = new Vector2(ConstantValues.PLAYER_ACCELERATION, 0.0f);
            link.state = new RightIdleRedLinkState(link);
        }

        public void TransitionLeft()
        {
            link.Acceleration = new Vector2(-ConstantValues.PLAYER_ACCELERATION, 0.0f);
            link.state = new LeftRunningRedLinkState(link);
        }

        public void Jump()
        {
            link.state = new LeftJumpingRedLinkState(link);
        }

        public void Crouch()
        {
            link.Location = new Point(link.Location.X, link.Location.Y + 10);
            link.state = new LeftCrouchingRedLinkState(link);
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
            link.state = new LeftRedToGreenLinkTransitionState(link);
        }

        public void UseWeapon()
        {
            link.state = new LeftSlashingRedLinkState(link);
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

        public void Update(GameTime gametime) { }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, link.Location);
        }
    }
}
