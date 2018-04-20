using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    class LeftDescendingSmallMarioState : ISmallMarioState
    {
        private StaticSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;
        private int currentFrame;

        public LeftDescendingSmallMarioState(Mario mario)
        {
            collisionSize = new Point(14, 16);
            this.mario = mario;
            game = mario.game;
            mario.Location = new Point(mario.Location.X + 15, mario.Location.Y);
            sprite = SmallMarioSpriteFactory.Instance.CreateLeftDescendingSmallMario();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 0); } }

        public void TransitionRight()
        {
            mario.state = new RightAutowalkingSmallMarioState(mario);
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
            currentFrame++;
            if (currentFrame == 20)
                TransitionRight();
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, mario.Location);
        }
    }
}