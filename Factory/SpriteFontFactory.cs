using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class SpriteFontFactory
    {
        private SpriteFont hudFont, pointsFont;

        private static SpriteFontFactory instance = new SpriteFontFactory();

        public static SpriteFontFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllFonts(ContentManager content)
        {
            hudFont = content.Load<SpriteFont>("hud");
            pointsFont = content.Load<SpriteFont>("points_font");
        }

        public SpriteFont CreatePointsFont()
        {
            return pointsFont;
        }

        public SpriteFont CreateHudFont()
        {
            return hudFont;
        }
    }
}