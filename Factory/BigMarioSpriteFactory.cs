using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class BigMarioSpriteFactory
    {
        private Texture2D marioSpriteSet;

        private static BigMarioSpriteFactory instance = new BigMarioSpriteFactory();

        public static BigMarioSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            marioSpriteSet = content.Load<Texture2D>("mario");
        }

        public StaticSprite CreateRightIdleBigMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(209, 52, 16, 32));
        }

        public StaticSprite CreateLeftIdleBigMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(180, 52, 16, 32));
        }

        public AnimatedSprite CreateRightRunningBigMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(239, 52, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(270, 52, 14, 31), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(299, 53, 16, 30), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftRunningBigMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(150, 52, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(121, 52, 14, 31), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(90, 53, 16, 30), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateRightSprintingBigMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(239, 52, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(270, 52, 14, 31), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(299, 53, 16, 30), 0.05f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftSprintingBigMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(150, 52, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(121, 52, 14, 31), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(90, 53, 16, 30), 0.05f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public StaticSprite CreateRightSlidingBigMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(60, 52, 16, 32));
        }

        public StaticSprite CreateLeftSlidingBigMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(329, 52, 16, 32));
        }

        public StaticSprite CreateRightCrouchingBigMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(389, 57, 16, 22));
        }

        public StaticSprite CreateLeftCrouchingBigMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(0, 57, 16, 22));
        }

        public StaticSprite CreateRightJumpingBigMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(359, 52, 16, 32));
        }

        public StaticSprite CreateLeftJumpingBigMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(30, 52, 16, 32));
        }

        public AnimatedSprite CreateRightDescendingBigMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(363, 89, 14, 27), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(390, 88, 14, 30), 0.05f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public StaticSprite CreateLeftDescendingBigMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(28, 89, 14, 27));
        }
    }
}