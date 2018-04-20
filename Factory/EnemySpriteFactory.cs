using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class EnemySpriteFactory
    {
        private Texture2D spriteSheet;
        private Texture2D bowserSheet;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("enemies");
            bowserSheet = content.Load<Texture2D>("bowser");
        }

        public AnimatedSprite CreateLeftWalkingGreenKoopa()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x50, 0x00, 0x10, 0x20), 0.3f, new Point(0, -0x20)));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x60, 0x00, 0x10, 0x20), 0.3f, new Point(0, -0x20)));

            return new AnimatedSprite(spriteSheet, animation);
        }

        public AnimatedSprite CreateRightWalkingGreenKoopa()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x50, 0x00, 0x10, 0x20), 0.3f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x60, 0x00, 0x10, 0x20), 0.3f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));

            return new AnimatedSprite(spriteSheet, animation);
        }

        public AnimatedSprite CreateLeftFlyingGreenKoopa()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x30, 0x00, 0x10, 0x20), 0.3f, new Point(0, -0x20)));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x40, 0x00, 0x10, 0x20), 0.3f, new Point(0, -0x20)));

            return new AnimatedSprite(spriteSheet, animation);
        }

        public AnimatedSprite CreateRightFlyingGreenKoopa()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x30, 0x00, 0x10, 0x20), 0.3f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x40, 0x00, 0x10, 0x20), 0.3f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));

            return new AnimatedSprite(spriteSheet, animation);
        }


        public StaticSprite CreateGreenKoopaShell()
        {
            return new StaticSprite(spriteSheet, new Rectangle(0x00, 0x20, 0x10, 0x10), new Point(0, -0xE));
        }

        public StaticSprite CreateGreenFlippedKoopa()
        {
            return new StaticSprite(spriteSheet, new Rectangle(0x00, 0x20, 0x10, 0x0E), new Point(0, -0xE), SpriteEffects.FlipVertically);
        }

        public AnimatedSprite CreateLeftWalkingRedKoopa()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x50, 0x20, 0x10, 0x20), 0.3f, new Point(0, -0x20)));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x60, 0x20, 0x10, 0x20), 0.3f, new Point(0, -0x20)));

            return new AnimatedSprite(spriteSheet, animation);
        }

        public AnimatedSprite CreateRightWalkingRedKoopa()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x50, 0x20, 0x10, 0x20), 0.3f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x60, 0x20, 0x10, 0x20), 0.3f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));

            return new AnimatedSprite(spriteSheet, animation);
        }

        public AnimatedSprite CreateLeftFlyingRedKoopa()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x30, 0x20, 0x10, 0x20), 0.3f, new Point(0, -0x20)));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x40, 0x20, 0x10, 0x20), 0.3f, new Point(0, -0x20)));

            return new AnimatedSprite(spriteSheet, animation);
        }

        public AnimatedSprite CreateRightFlyingRedKoopa()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x30, 0x20, 0x10, 0x20), 0.3f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x40, 0x20, 0x10, 0x20), 0.3f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));

            return new AnimatedSprite(spriteSheet, animation);
        }


        public StaticSprite CreateRedKoopaShell()
        {
            return new StaticSprite(spriteSheet, new Rectangle(0x00, 0x30, 0x10, 0x10), new Point(0, -0xE));
        }

        public StaticSprite CreateRedFlippedKoopa()
        {
            return new StaticSprite(spriteSheet, new Rectangle(0x00, 0x30, 0x10, 0x0E), new Point(0, -0xE), SpriteEffects.FlipVertically);
        }

        public AnimatedSprite CreateWalkingGoomba()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x00, 0x00, 0x10, 0x10), 0.3f, new Point(0, -0x10)));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x10, 0x00, 0x10, 0x10), 0.3f, new Point(0, -0x10)));

            return new AnimatedSprite(spriteSheet, animation);
        }

        public StaticSprite CreateStompedGoomba()
        {
            return new StaticSprite(spriteSheet, new Rectangle(0x20, 0x00, 0x10, 0x10), new Point(0, -0x10));
        }

        public StaticSprite CreateFlippedGoomba()
        {
            return new StaticSprite(spriteSheet, new Rectangle(0x10, 0x00, 0x10, 0x10), new Point(0, -0x10), SpriteEffects.FlipVertically);
        }

        public AnimatedSprite CreateLeftMovingBowser()
        {
            Animation animation = new Animation();
            for (int i = 0; i < 2; i++)
            {
                animation.AddFrame(new Animation.Frame(new Rectangle(0x0, 0x00, 0x20, 0x20), 0.3f, new Point(0, -0x20)));
                animation.AddFrame(new Animation.Frame(new Rectangle(0x20, 0x00, 0x20, 0x20), 0.3f, new Point(0, -0x20)));
            }
            for (int i = 0; i < 2; i++)
            {
                animation.AddFrame(new Animation.Frame(new Rectangle(0x40, 0x00, 0x20, 0x20), 0.3f, new Point(0, -0x20)));
                animation.AddFrame(new Animation.Frame(new Rectangle(0x60, 0x00, 0x20, 0x20), 0.3f, new Point(0, -0x20)));
            }

            return new AnimatedSprite(bowserSheet, animation);
        }

        public AnimatedSprite CreateRightMovingBowser()
        {
            Animation animation = new Animation();
            for (int i = 0; i < 2; i++)
            {
                animation.AddFrame(new Animation.Frame(new Rectangle(0x0, 0x00, 0x20, 0x20), 0.5f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));
                animation.AddFrame(new Animation.Frame(new Rectangle(0x20, 0x00, 0x20, 0x20), 0.5f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));
            }
            for (int i = 0; i < 2; i++)
            {
                animation.AddFrame(new Animation.Frame(new Rectangle(0x40, 0x00, 0x20, 0x20), 0.5f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));
                animation.AddFrame(new Animation.Frame(new Rectangle(0x60, 0x00, 0x20, 0x20), 0.5f, new Point(0, -0x20), SpriteEffects.FlipHorizontally));
            }

            return new AnimatedSprite(bowserSheet, animation);
        }

        public AnimatedSprite CreateStandingStillBowser()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x0, 0x00, 0x20, 0x20), 0.5f, new Point(0, -0x20)));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x20, 0x00, 0x20, 0x20), 0.5f, new Point(0, -0x20)));

            return new AnimatedSprite(bowserSheet, animation);
        }   
    }
}