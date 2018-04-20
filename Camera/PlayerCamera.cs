using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public sealed class PlayerCamera : ICamera
    {
        private IPlayer player;

        private Point size;

        private Point Offset {  get { return new Point(-size.X / 2, -size.Y / 2); } }

        private Point Position {
            get {
                Point position = player.Location + Offset;
                position.X = Math.Max(position.X, 0);
                position.Y = Math.Min(position.Y, 0);
                return position;
            }
        }
        public Rectangle CollisionRectangle
        {
            get { return new Rectangle(Position, size); }
        }

        public Matrix Transform
        {
            get {
                return Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0.0f));
            }
        }

        public PlayerCamera(IPlayer player)
        {
            this.player = player;
            this.size = new Point(256, 240);
        }

        public void BeginSpriteBatch(SpriteBatch batch, SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null)
        {
            batch.Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect, Transform);
        }
    }
}