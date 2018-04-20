using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class HazardSpriteFactory
    {
        private Texture2D texture;

        private static HazardSpriteFactory instance = new HazardSpriteFactory();

        public static HazardSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("hazards");
        }

        public StaticSprite CreateLavaTop()
        {
            return new StaticSprite(texture, new Rectangle(0x00, 0x00, 0x10, 0x10));
        }

        public StaticSprite CreateLava()
        {
            return new StaticSprite(texture, new Rectangle(0x00, 0x10, 0x10, 0x10));
        }
    }
}