using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class WeaponBlockCollisionDetector
    {
        private Rectangle WeaponRectangle, BlockRectangle, IntersectRectangle;

        public List<ICollision> collisions;
        private WeaponBlockCollisionHandler collisionHandler;

        public WeaponBlockCollisionDetector()
        {
            collisionHandler = new WeaponBlockCollisionHandler();
            collisions = new List<ICollision>();
        }

        public void DetectCollision(IWeapon weapon, Block block)
        {
            WeaponRectangle = weapon.CollisionRectangle;
            BlockRectangle = block.CollisionRectangle;

            if (WeaponRectangle.Intersects(BlockRectangle))
            {
                IntersectRectangle = Rectangle.Intersect(WeaponRectangle, BlockRectangle);

                if (IntersectRectangle.Height >= IntersectRectangle.Width)
                {
                    if (weapon.Location.X > block.Position.X)
                    {
                        if (!(block.State is HiddenBlockState))
                        {
                            collisions.Add(new LeftCollision(IntersectRectangle));
                        }
                    }
                    else
                    {
                        if (!(block.State is HiddenBlockState))
                        {
                            collisions.Add(new RightCollision(IntersectRectangle));
                        }
                    }
                }
                else if (IntersectRectangle.Width > IntersectRectangle.Height)
                {
                    if (weapon.Location.Y > block.Position.Y)
                    {
                        if (!(block.State is HiddenBlockState))
                        {
                            collisions.Add(new TopCollision(IntersectRectangle));
                        }
                    }
                    else
                    {
                        if (!(block.State is HiddenBlockState))
                        {
                            collisions.Add(new BottomCollision(IntersectRectangle));
                        }
                    }
                }
            }
        }

        public void HandleCollision(IWeapon weapon)
        {
            collisionHandler.HandleCollision(weapon, collisions);
            collisions = new List<ICollision>();
        }

        public void Update(IWeapon weapon, Block block)
        {
            DetectCollision(weapon, block);
        }
    }
}