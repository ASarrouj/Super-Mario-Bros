using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class WeaponPipeCollisionDetector
    {
        private Rectangle WeaponRectangle, PipeRectangle, IntersectRectangle;

        public ICollision collisionSide;
        private WeaponPipeCollisionHandler collisionHandler;

        public WeaponPipeCollisionDetector()
        {
            collisionHandler = new WeaponPipeCollisionHandler();
        }

        public void DetectCollision(IWeapon weapon, Pipe pipe)
        {
            WeaponRectangle = weapon.CollisionRectangle;
            PipeRectangle = pipe.CollisionRectangle;

            if (WeaponRectangle.Intersects(PipeRectangle))
            {
                IntersectRectangle = Rectangle.Intersect(WeaponRectangle, PipeRectangle);

                if (IntersectRectangle.Height >= IntersectRectangle.Width)
                {
                    if (weapon.Location.X > pipe.Position.X)
                    {
                        collisionSide = new LeftCollision(IntersectRectangle);
                    }
                    else
                    {
                        collisionSide = new RightCollision(IntersectRectangle);
                    }
                }
                else if (IntersectRectangle.Width > IntersectRectangle.Height)
                {
                    if (weapon.Location.Y > pipe.Position.Y)
                    {
                        collisionSide = new TopCollision(IntersectRectangle);
                    }
                    else
                    {
                        collisionSide = new BottomCollision(IntersectRectangle);
                    }
                }

                if (pipe.State is HiddenBlockState)
                {
                    collisionSide = new NoCollision();
                }

                collisionHandler.HandleCollision(weapon, pipe, collisionSide);
            }
            else
            {
                collisionSide = new NoCollision();
            }
        }

        public void Update(IWeapon weapon, Pipe pipe)
        {
            DetectCollision(weapon, pipe);
        }
    }
}