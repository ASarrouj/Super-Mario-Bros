using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class GreenLinkSpriteFactory
    {
        private Texture2D linkSpriteSet;

        private static GreenLinkSpriteFactory instance = new GreenLinkSpriteFactory();

        public static GreenLinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkSpriteSet = content.Load<Texture2D>("link");
        }

        public StaticSprite CreateRightIdleGreenLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(66, 1, 16, 32));
        }

        public StaticSprite CreateLeftIdleGreenLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(17, 1, 16, 32));
        }

        public AnimatedSprite CreateRightRunningGreenLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(66, 67, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(66, 100, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(66, 134, 16, 31), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftRunningGreenLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(17, 67, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(17, 100, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(17, 134, 16, 31), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public AnimatedSprite CreateRightSprintingGreenLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(66, 67, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(66, 100, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(66, 134, 16, 31), 0.05f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftSprintingGreenLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(17, 67, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(17, 100, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(17, 134, 16, 31), 0.05f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public StaticSprite CreateRightCrouchingGreenLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(66, 237, 16, 27));
        }

        public StaticSprite CreateLeftCrouchingGreenLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(17, 237, 16, 27));
        }

        public StaticSprite CreateRightJumpingGreenLink1()
        {
            return CreateRightCrouchingGreenLink();
        }

        public StaticSprite CreateRightJumpingGreenLink2()
        {
            return CreateRightIdleGreenLink();
        }

        public StaticSprite CreateLeftJumpingGreenLink1()
        {
            return CreateLeftCrouchingGreenLink();
        }

        public StaticSprite CreateLeftJumpingGreenLink2()
        {
            return CreateLeftIdleGreenLink();
        }

        public StaticSprite CreateRightSlashingGreenLink1()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(58, 166, 23, 32));

        }

        public StaticSprite CreateRightSlashingGreenLink2()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(66, 201, 32, 30));
        }

        public StaticSprite CreateLeftSlashingGreenLink1()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(18, 166, 23, 32));
        }

        public StaticSprite CreateLeftSlashingGreenLink2()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(1, 201, 32, 30));
        }

        public StaticSprite CreateRightStabbingGreenLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(66, 271, 32, 26));
        }

        public StaticSprite CreateLeftStabbingGreenLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(1, 271, 32, 26));
        }

        public StaticSprite CreateRightDamagedGreenLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(66, 366, 16, 29));
        }

        public StaticSprite CreateLeftDamagedGreenLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(17, 366, 16, 29));
        }

        public AnimatedSprite CreateDescendingGreenLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(17, 430, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(66, 430, 16, 32), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }
    }
}