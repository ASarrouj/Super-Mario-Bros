using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class BrokenBlockState : BlockState, IBlockState
    {
        protected StaticSprite[] sprites = new StaticSprite[5];
        private Point[] positions = new Point[5];
        private float timer;
        private int verticalVelocity = -5;
        private bool frameSkip = false;

        private Rectangle oldRectangle;

        public BrokenBlockState(Block block) : base(block)
        {
            timer = 0.0f;
            oldRectangle = block.CollisionRectangle;
            Point startPoint = new Point(block.Position.X, block.Position.Y);
            for (int i = 0; i < 5; i++)
            {
                sprites[i] = BlockSpriteFactory.Instance.CreateBrickBlockBit();
                positions[i] = startPoint;
            }
        }

        public void BeHit(IPlayer player) {}

        public void BeBumped(IPlayer player) { }

        public new Rectangle CollisionRectangle
        {
            get
            {
                if (timer < 0.1f) return oldRectangle;
                else return Rectangle.Empty;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (positions[0].Y < 500) {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                int positionModifier = -2;
                for (int i = 0; i < 5; i++)
                {
                    positions[i] = new Point(positions[i].X + positionModifier, positions[i].Y + verticalVelocity);
                    positionModifier++;
                }

                if (frameSkip)
                {
                    verticalVelocity++;
                    frameSkip = false;
                }
                else
                {
                    frameSkip = true;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (positions[0].Y < 500) {
                for (int i = 0; i < 5; i++)
                {
                    sprites[i].Draw(spriteBatch, positions[i]);
                }
            }
        }     
    }
}
