using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class FireMarioSpriteFactory
    {
        private Texture2D marioSpriteSet;

        private static FireMarioSpriteFactory instance = new FireMarioSpriteFactory();

        public static FireMarioSpriteFactory Instance
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

        public StaticSprite CreateRightIdleFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(209, 122, 16, 32));
        }

        public StaticSprite CreateLeftIdleFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(180, 122, 16, 32));
        }

        public AnimatedSprite CreateRightRunningFireMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(237, 122, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(263, 122, 14, 31), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(287, 123, 16, 30), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftRunningFireMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(152, 122, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(128, 122, 14, 31), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(102, 123, 16, 30), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateRightSprintingFireMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(237, 122, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(263, 122, 14, 31), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(287, 123, 16, 30), 0.05f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftSprintingFireMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(152, 122, 16, 32), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(128, 122, 14, 31), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(102, 123, 16, 30), 0.05f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public StaticSprite CreateRightSlidingFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(52, 122, 16, 32));
        }

        public StaticSprite CreateLeftSlidingFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(337, 122, 16, 32));
        }

        public StaticSprite CreateRightCrouchingFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(389, 127, 16, 22));
        }

        public StaticSprite CreateLeftCrouchingFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(0, 127, 16, 22));
        }

        public StaticSprite CreateRightJumpingFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(362, 122, 16, 32));
        }

        public StaticSprite CreateLeftJumpingFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(27, 122, 16, 32));
        }

        public StaticSprite CreateRightShootingFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(312, 123, 16, 30));
        }

        public StaticSprite CreateLeftShootingFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(77, 123, 16, 30));
        }

        public AnimatedSprite CreateRightDescendingFireMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(363, 159, 14, 27), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(390, 158, 14, 30), 0.05f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public StaticSprite CreateLeftDescendingFireMario()
        {
            return new StaticSprite(marioSpriteSet, new Rectangle(28, 159, 14, 27));
        }
    }
}