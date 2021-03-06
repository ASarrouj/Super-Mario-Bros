﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class LeftSlashingGreenLinkState : IGreenLinkState
    {
        private StaticSprite sprite1, sprite2;
        private Point collisionSize;
        private Link link;
        private Sword sword;
        private $safeprojectname$ game;
        private int currentFrame;

        public LeftSlashingGreenLinkState(Link link)
        {
            collisionSize = new Point(20, 32);
            this.link = link;
            sword = link.sword;
            game = link.game;
            currentFrame = 0;
            sprite1 = GreenLinkSpriteFactory.Instance.CreateLeftSlashingGreenLink1();
            sprite2 = GreenLinkSpriteFactory.Instance.CreateLeftSlashingGreenLink2();
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
            link.state = new LeftJumpingGreenLinkState(link);
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
            game.state = new PlayerDamagedOrPowerUpState(game);
            link.state = new LeftGreenToRedLinkTransitionState(link);
        }

        public void GetMushroom()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
            link.state = new LeftGreenToRedLinkTransitionState(link);
        }

        public void TakeDamage()
        {

        }

        public void UseWeapon()
        {

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
                    link.state = new LeftJumpingGreenLinkState(link);
                else
                    link.state = new LeftIdleGreenLinkState(link);
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