using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public class Bridge : ICollidable
    {
        private StaticSprite bridgeSprite;
        private StaticSprite chainSprite;
        private Point collisionSize;
        private Point position;
        private int length;
        private int brokenFrame;

        public Point Position { get { return position; } }

        public Axe Axe { get; }

        public Bridge(Point position, int length)
        {
            this.length = length;
            this.position = position;
            collisionSize = new Point(length*0x10, 0x10);
            Axe = new Axe(new Point(position.X + collisionSize.X, position.Y - 0x20));
            bridgeSprite = EndObjectSpriteFactory.Instance.CreateBridge();
            chainSprite = EndObjectSpriteFactory.Instance.CreateChain();
            brokenFrame = -1;
        }

        public void Break()
        {
            brokenFrame = 0;
            Axe.Drop();
        }

        public Rectangle CollisionRectangle { get { return new Rectangle(position, collisionSize); } }

        public void Update(GameTime gameTime)
        {        
            if (brokenFrame >= 0)
            {
                brokenFrame++;
                if (brokenFrame == length * 5) collisionSize = Point.Zero;
            } else
            {
                Axe.Update(gameTime);
            }
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < length; i++)
                {
                if (i < length - brokenFrame / 5)
                {
                    bridgeSprite.Draw(spriteBatch, new Point(position.X + i * 0x10, position.Y));
                    if (i == length - 1)
                    {
                        chainSprite.Draw(spriteBatch, new Point(position.X + i * 0x10, position.Y - 0x10));
                    }
                }
            }
            if (brokenFrame < 0) Axe.Draw(gameTime, spriteBatch);
        }
    }
}
