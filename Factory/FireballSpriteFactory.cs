using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class FireballSpriteFactory
    {
        private Texture2D fireballSprites;

        private static FireballSpriteFactory instance = new FireballSpriteFactory();

        public static FireballSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            fireballSprites = content.Load<Texture2D>("fireballs");
        }

        public AnimatedSprite CreateActiveFireball()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0, 0, 8, 8), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(8, 0, 8, 8), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0, 8, 8, 8), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(8, 8, 8, 8), 0.05f));

            return new AnimatedSprite(fireballSprites, animation);
        }

        public AnimatedSprite CreateDestroyedFireball()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(20, 4, 8, 8), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(18, 17, 12, 14), 0.05f));
            animation.AddFrame(new Animation.Frame(new Rectangle(16, 32, 16, 16), 0.05f));

            return new AnimatedSprite(fireballSprites, animation);
        }

        public AnimatedSprite CreateLeftBowserFireball()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x0, 0x30, 0x18, 0x8), 0.1f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x0, 0x38, 0x18, 0x8), 0.1f));

            return new AnimatedSprite(fireballSprites, animation);
        }
    }
}