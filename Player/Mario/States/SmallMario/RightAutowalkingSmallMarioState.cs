﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class RightAutowalkingSmallMarioState : IBigMarioState
    {
        private AnimatedSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;
        private bool castleReached;

        public RightAutowalkingSmallMarioState(Mario mario)
        {
            collisionSize = new Point(15, 16);
            this.mario = mario;
            mario.Acceleration = Vector2.Zero;
            mario.Velocity = new Vector2(ConstantValues.PLAYER_AUTOWALK_VELOCITY, 0f);
            game = mario.game;
            castleReached = false;
            sprite = SmallMarioSpriteFactory.Instance.CreateRightRunningSmallMario();
            mario.Auto = true;
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 0); } }

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
            mario.state = new RightIdleSmallMarioState(mario);
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
            mario.state = new DeadMarioState(mario);
        }

        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            if (!castleReached)
                sprite.Draw(batch, mario.Location);
        }
    }
}