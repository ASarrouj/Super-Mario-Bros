using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class RightDescendingFireMarioState : IFireMarioState
    {
        private AnimatedSprite sprite;
        private Point collisionSize;
        private Mario mario;
        private $safeprojectname$ game;
        private int currentFrame;

        public RightDescendingFireMarioState(Mario mario)
        {
            collisionSize = new Point(14, 30);
            this.mario = mario;
            game = mario.game;
            game.state.TouchFlagpole();
            mario.Acceleration = new Vector2(0, -ConstantValues.PLAYER_ACCELERATION);
            mario.Velocity = new Vector2(0, 125.0f);
            currentFrame = 0;
            sprite = FireMarioSpriteFactory.Instance.CreateRightDescendingFireMario();
        }

        public Rectangle CollisionRectangle
        { get { return new Rectangle(mario.Location, collisionSize); } }

        public Point StartOffset { get { return new Point(0, 16); } }

        public void TransitionRight()
        {
            mario.state = new LeftDescendingFireMarioState(mario);
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

        }

        public void Kill()
        {
            mario.state = new DeadMarioState(mario);
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
            sprite.Draw(batch, mario.Location);
        }
    }
}