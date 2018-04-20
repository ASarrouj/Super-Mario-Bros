using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class ItemSpriteFactory
    {
        private Texture2D itemSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSheet = content.Load<Texture2D>("items");
        }

        public StaticSprite CreateRedMushroom()
        {
            return new StaticSprite(itemSheet, new Rectangle(0x0, 0x0, 0x10, 0x10));
        }

        public StaticSprite CreateGreenMushroom()
        {
            return new StaticSprite(itemSheet, new Rectangle(0x10, 0x0, 0x10, 0x10));
        }

        public AnimatedSprite CreateFireFlower()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x0, 0x10, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x10, 0x10, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x20, 0x10, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x30, 0x10, 0x10, 0x10), 0.1f));

            return new AnimatedSprite(itemSheet, animation);
        }

        public AnimatedSprite CreateStar()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x0, 0x20, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x10, 0x20, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x20, 0x20, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x30, 0x20, 0x10, 0x10), 0.1f));

            return new AnimatedSprite(itemSheet, animation);
        }

        public StaticSprite CreateHudCoin()
        {
            return new StaticSprite(itemSheet, new Rectangle(0x0, 0x30, 0x10, 0x10));
        }

        public AnimatedSprite CreateCoin()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x0, 0x30, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x10, 0x30, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x20, 0x30, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x30, 0x30, 0x10, 0x10), 0.1f));

            return new AnimatedSprite(itemSheet, animation);
        }

        public AnimatedSprite CreateSpinningCoin()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x0, 0x40, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x10, 0x40, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x20, 0x40, 0x10, 0x10), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x30, 0x40, 0x10, 0x10), 0.1f));

            return new AnimatedSprite(itemSheet, animation);
        }
    }
}
