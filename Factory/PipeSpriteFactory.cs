using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class PipeSpriteFactory
    {
        private Texture2D pipeTileSet;

        private static PipeSpriteFactory instance = new PipeSpriteFactory();

        public static PipeSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            pipeTileSet = content.Load<Texture2D>("pipes");
        }

        public StaticSprite CreateUpPipeSprite()
        {
            return new StaticSprite(pipeTileSet, new Rectangle(0x00, 0x00, 0x20, 0x10));
        }

        public StaticSprite CreateLeftPipeSprite()
        {
            return new StaticSprite(pipeTileSet, new Rectangle(0x20, 0x00, 0x10, 0x20));
        }

        public StaticSprite CreateLeftVerticalPipeSprite()
        {
            return new StaticSprite(pipeTileSet, new Rectangle(0x00, 0x10, 0x10, 0x10));
        }

        public StaticSprite CreateRightVerticalPipeSprite()
        {
            return new StaticSprite(pipeTileSet, new Rectangle(0x10, 0x10, 0x10, 0x10));
        }

        public StaticSprite CreateTopHorizontalPipeSprite()
        {
            return new StaticSprite(pipeTileSet, new Rectangle(0x30, 0x00, 0x10, 0x10));
        }

        public StaticSprite CreateBottomHorizontalPipeSprite()
        {
            return new StaticSprite(pipeTileSet, new Rectangle(0x30, 0x10, 0x10, 0x10));
        }
    }
}
