using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class SmallMarioSpriteFactory
    {
        private Texture2D marioSpriteSet;

        private static SmallMarioSpriteFactory instance = new SmallMarioSpriteFactory();

        public static SmallMarioSpriteFactory Instance
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

        public StaticSprite CreateRightIdleSmallMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(211, 0, 13, 16));
        }

        public StaticSprite CreateLeftIdleSmallMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(181, 0, 13, 16));
        }

        public AnimatedSprite CreateRightRunningSmallMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(241, 0, 14, 15), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(272, 0, 12, 16), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(300, 0, 16, 16), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftRunningSmallMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(150, 0, 14, 15), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(121, 0, 12, 16), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(89, 0, 16, 16), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }
        public AnimatedSprite CreateRightSprintingSmallMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(241, 0, 14, 15), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(272, 0, 12, 16), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(300, 0, 16, 16), 0.05f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftSprintingSmallMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(150, 0, 14, 15), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(121, 0, 12, 16), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(89, 0, 16, 16), 0.05f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public StaticSprite CreateRightJumpingSmallMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(359, 0, 17, 16));
        }

        public StaticSprite CreateLeftJumpingSmallMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(29, 0, 17, 16));
        }

        public StaticSprite CreateRightSlidingSmallMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(331, 0, 14, 16));
        }

        public StaticSprite CreateLeftSlidingSmallMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(60, 0, 14, 16));
        }

        public AnimatedSprite CreateRightDescendingSmallMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(331, 30, 13, 15), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(361, 30, 14, 16), 0.05f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public StaticSprite CreateLeftDescendingSmallMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(61, 30, 13, 15));
        }

        public StaticSprite CreateDeadMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(0, 16, 15, 14));
        }

        public StaticSprite CreateSparkle()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(0, 0, 3, 3), new Point(-1, -1));
        }
    }
}