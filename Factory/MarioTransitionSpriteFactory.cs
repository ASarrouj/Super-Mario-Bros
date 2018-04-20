using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class MarioTransitionSpriteFactory
    {
        private Texture2D marioSpriteSet;

        private static MarioTransitionSpriteFactory instance = new MarioTransitionSpriteFactory();

        public static MarioTransitionSpriteFactory Instance
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

        public AnimatedSprite CreateLeftSmallToBigMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(180, 52, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(181, 0, 13, 16), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftSmallToFireMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(180, 122, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(181, 0, 13, 16), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftBigToSmallMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(181, 0, 13, 16), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(180, 52, 16, 32), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftBigToFireMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(180, 122, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(180, 52, 16, 32), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftFireToSmallMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(181, 0, 13, 16), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(180, 122, 16, 32), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }
        public AnimatedSprite CreateRightSmallToBigMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(209, 52, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(211, 0, 13, 16), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateRightSmallToFireMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(209, 122, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(211, 0, 13, 16), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateRightBigToSmallMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(211, 0, 13, 16), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(209, 52, 16, 32), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateRightBigToFireMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(209, 122, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(209, 52, 16, 32), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }

        public AnimatedSprite CreateRightFireToSmallMario()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(211, 0, 13, 16), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(209, 122, 16, 32), 0.1f));

            return new AnimatedSprite(marioSpriteSet, animation);
        }
    }
}
