using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    class EndObjectSpriteFactory
    {
        private Texture2D levelEndTileSet;

        private static EndObjectSpriteFactory instance = new EndObjectSpriteFactory();

        public static EndObjectSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            levelEndTileSet = content.Load<Texture2D>("endObjects");
        }

        public StaticSprite CreateFlagpole()
        {
            return new StaticSprite(levelEndTileSet, new Rectangle(0, 16, 8, 152));
        }
        public StaticSprite CreateFlag()
        {
            return new StaticSprite(levelEndTileSet, new Rectangle(0, 0, 16, 16));
        }

        public StaticSprite CreateCastle()
        {
            return new StaticSprite(levelEndTileSet, new Rectangle(0, 173, 148, 176));
        }

        public StaticSprite CreateToad()
        {
            return new StaticSprite(levelEndTileSet, new Rectangle(0x20, 0x18, 0x10, 0x18));
        }

        public StaticSprite CreateBridge()
        {
            return new StaticSprite(levelEndTileSet, new Rectangle(0x10, 0x20, 0x10, 0x10));
        }

        public StaticSprite CreateChain()
        {
            return new StaticSprite(levelEndTileSet, new Rectangle(0x10, 0x10, 0x10, 0x10));
        }

        public AnimatedSprite CreateAxe()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Animation.Frame(new Rectangle(0x10, 0x0, 0x10, 0x10), 0.3f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x20, 0x0, 0x10, 0x10), 0.15f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x30, 0x0, 0x10, 0x10), 0.15f));
            animation.AddFrame(new Animation.Frame(new Rectangle(0x40, 0x0, 0x10, 0x10), 0.15f));

            return new AnimatedSprite(levelEndTileSet, animation);
        }
    }
}
