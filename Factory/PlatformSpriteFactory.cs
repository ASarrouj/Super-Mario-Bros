using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class PlatformSpriteFactory
    {
        private Texture2D PlatformTileSet;

        private static PlatformSpriteFactory instance = new PlatformSpriteFactory();

        public static PlatformSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            PlatformTileSet = content.Load<Texture2D>("platforms");
        }

        public StaticSprite CreateSmallPlatformSprite()
        {
            return new StaticSprite(PlatformTileSet, new Rectangle(0x00, 0x00, 0x20, 0x08));
        }
    }
}
