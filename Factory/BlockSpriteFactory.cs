using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class BlockSpriteFactory
    {
        private Texture2D blockTileSet;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            blockTileSet = content.Load<Texture2D>("blockTileSet");
        }

        public StaticSprite CreateUsedBlock()
        {
            return new StaticSprite(blockTileSet, new Rectangle(0x30, 0x00, 0x10, 0x10));
        }

        public StaticSprite CreateBrickBlock()
        {
            return new StaticSprite(blockTileSet, new Rectangle(0x40, 0x00, 0x10, 0x10));
        }

        public StaticSprite CreateBrickBlockBit()
        {
            return new StaticSprite(blockTileSet, new Rectangle(126, 6, 6, 12));
        }

        public StaticSprite CreateCrackedBlock()
        {
            return new StaticSprite(blockTileSet, new Rectangle(0x50, 0x00, 0x10, 0x10));
        }

        public StaticSprite CreateStoneBlock()
        {
            return new StaticSprite(blockTileSet, new Rectangle(0x60, 0x00, 0x10, 0x10));
        }

        public AnimatedSprite CreateItemBlock()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x00, 0x00, 0x10, 0x10), 0.5f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x10, 0x00, 0x10, 0x10), 0.5f));

            return new AnimatedSprite(blockTileSet, animation);
        }

        public StaticSprite CreateUndergroundBrickBlock()
        {
            return new StaticSprite(blockTileSet, new Rectangle(0x40, 0x10, 0x10, 0x10));
        }

        public StaticSprite CreateUndergroundCrackedBlock()
        {
            return new StaticSprite(blockTileSet, new Rectangle(0x50, 0x10, 0x10, 0x10));
        }

        public StaticSprite CreateUndergroundStoneBlock()
        {
            return new StaticSprite(blockTileSet, new Rectangle(0x60, 0x10, 0x10, 0x10));
        }

        public StaticSprite CreateCastleBrickBlock()
        {
            return new StaticSprite(blockTileSet, new Rectangle(0x40, 0x20, 0x10, 0x10));
        }
    }
}
