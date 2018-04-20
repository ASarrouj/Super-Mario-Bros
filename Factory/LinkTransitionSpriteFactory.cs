using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LinkTransitionSpriteFactory
    {
        private Texture2D linkSpriteSet;

        private static LinkTransitionSpriteFactory instance = new LinkTransitionSpriteFactory();

        public static LinkTransitionSpriteFactory Instance
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

        public AnimatedSprite CreateLeftGreenToRedLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(17, 1, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(114, 1, 16, 32), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public AnimatedSprite CreateRightGreenToRedLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(66, 1, 16, 32), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(163, 1, 16, 32), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public AnimatedSprite CreateLeftRedToGreenLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(114, 366, 16, 29), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(17, 366, 16, 29), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }

        public AnimatedSprite CreateRightRedToGreenLink()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(163, 366, 16, 29), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(66, 366, 16, 29), 0.1f));

            return new AnimatedSprite(linkSpriteSet, animation);
        }
    }
}
