using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class RedLinkSpriteFactory
    {
        private Texture2D linkSpriteSet;

        private static RedLinkSpriteFactory instance = new RedLinkSpriteFactory();

        public static RedLinkSpriteFactory Instance
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

        public StaticSprite CreateRightIdleRedLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(163, 1, 16, 32));
        }

        public StaticSprite CreateLeftIdleRedLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(114, 1, 16, 32));
        }

        public AnimatedSprite CreateRightRunningRedLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(163, 67, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(163, 100, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(163, 134, 16, 31), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftRunningRedLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(114, 67, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(114, 100, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(114, 134, 16, 31), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public AnimatedSprite CreateRightSprintingRedLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(163, 67, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(163, 100, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(163, 134, 16, 31), 0.05f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftSprintingRedLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(114, 67, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(114, 100, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(114, 134, 16, 31), 0.05f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public StaticSprite CreateRightCrouchingRedLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(163, 237, 16, 27));
        }

        public StaticSprite CreateLeftCrouchingRedLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(114, 237, 16, 27));
        }

        public StaticSprite CreateRightJumpingRedLink1()
        {
            return CreateRightCrouchingRedLink();
        }

        public StaticSprite CreateRightJumpingRedLink2()
        {
            return CreateRightIdleRedLink();
        }

        public StaticSprite CreateLeftJumpingRedLink1()
        {
            return CreateLeftCrouchingRedLink();
        }

        public StaticSprite CreateLeftJumpingRedLink2()
        {
            return CreateLeftIdleRedLink();
        }

        public StaticSprite CreateRightSlashingRedLink1()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(155, 166, 23, 32));
        }
        public StaticSprite CreateRightSlashingRedLink2()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(163, 201, 32, 30));
        }

        public StaticSprite CreateLeftSlashingRedLink1()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(114, 166, 23, 32));
        }
        public StaticSprite CreateLeftSlashingRedLink2()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(98, 201, 32, 30));
        }

        public StaticSprite CreateRightStabbingRedLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(163, 271, 32, 26));
        }

        public StaticSprite CreateLeftStabbingingRedLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(98, 271, 32, 26));
        }

        public StaticSprite CreateRightDamagedRedLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(163, 366, 16, 29));
        }

        public StaticSprite CreateLeftDamagedRedLink()
        {
            return new StaticSprite(linkSpriteSet, new Rectangle(114, 366, 16, 29));
        }
        public AnimatedSprite CreateDescendingRedLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(114, 430, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(163, 430, 16, 32), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }
    }
}