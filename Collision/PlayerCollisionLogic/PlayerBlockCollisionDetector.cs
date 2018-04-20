using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerBlockCollisionDetector
    {
        private Rectangle PlayerRectangle, BlockRectangle, IntersectRectangle;

        public List<ICollision> collisions;
        public List<Block> blockArray;
        private PlayerBlockCollisionHandler collisionHandler;

        public PlayerBlockCollisionDetector()
        {
            collisionHandler = new PlayerBlockCollisionHandler();
            collisions = new List<ICollision>();
            blockArray = new List<Block>();
        }

        public void DetectCollision(IPlayer player, Block block)
        {
            PlayerRectangle = player.CollisionRectangle;
            BlockRectangle = block.CollisionRectangle;

            if (PlayerRectangle.Intersects(BlockRectangle))
            {
                IntersectRectangle = Rectangle.Intersect(PlayerRectangle, BlockRectangle);

                if (IntersectRectangle.Height >= IntersectRectangle.Width)
                {
                    if (player.Location.X > block.Position.X)
                    {
                        if (!(block.State is HiddenBlockState))
                        {
                            collisions.Add(new LeftCollision(IntersectRectangle));
                            blockArray.Add(block);
                        }
                    }
                    else
                    {
                        if (!(block.State is HiddenBlockState))
                        {
                            collisions.Add(new RightCollision(IntersectRectangle));
                            blockArray.Add(block);
                        }
                    }
                }
                else if (IntersectRectangle.Width > IntersectRectangle.Height)
                {
                    if (player.Location.Y > block.Position.Y)
                    {
                        if (player.Velocity.Y <= 0)
                        {
                            collisions.Add(new TopCollision(IntersectRectangle));
                            blockArray.Add(block);
                        }
                    }
                    else
                    {
                        if (!(block.State is HiddenBlockState))
                        {
                            collisions.Add(new BottomCollision(IntersectRectangle));
                            blockArray.Add(block);
                        }
                    }
                }
            }
        }

        public void HandleCollision(IPlayer player)
        {
            collisionHandler.HandleCollision(player, blockArray, collisions);
            collisions = new List<ICollision>();
            blockArray = new List<Block>();
        }

        public void Update(IPlayer player, Block block)
        {
            DetectCollision(player, block);
        }
    }
}