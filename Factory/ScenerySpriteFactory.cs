using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class ScenerySpriteFactory
    {
        private Texture2D sceneryTileSet;

        private static ScenerySpriteFactory instance = new ScenerySpriteFactory();

        public static ScenerySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            sceneryTileSet = content.Load<Texture2D>("backGroundSprites");
        }

        public StaticSprite CreateSmallHill()
        {
            return new StaticSprite(sceneryTileSet, new Rectangle(0, 0, 51, 35));
        }

        public StaticSprite CreateBigHill()
        {
            return new StaticSprite(sceneryTileSet, new Rectangle(51, 0, 80, 35));
        }

        public StaticSprite CreateSingleCloud()
        {
            return new StaticSprite(sceneryTileSet, new Rectangle(0, 35, 32, 24));
        }

        public StaticSprite CreateDoubleCloud()
        {
            return new StaticSprite(sceneryTileSet, new Rectangle(96, 35, 48, 24));
        }

        public StaticSprite CreateTripleCloud()
        {
            return new StaticSprite(sceneryTileSet, new Rectangle(32, 35, 64, 24));
        }

        public StaticSprite CreateSingleBush()
        {
            return new StaticSprite(sceneryTileSet, new Rectangle(0, 59, 32, 16));
        }
        
        public StaticSprite CreateDoubleBush()
        {
            return new StaticSprite(sceneryTileSet, new Rectangle(96, 59, 48, 16));
        }

        public StaticSprite CreateTripleBush()
        {
            return new StaticSprite(sceneryTileSet, new Rectangle(32, 59, 64, 16));
        }
        
        public StaticSprite CreateTitleBlock()
        {
            return new StaticSprite(sceneryTileSet, new Rectangle(144, 0, 176, 88));
        }
    }
}
