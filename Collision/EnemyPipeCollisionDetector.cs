using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class EnemyPipeCollisionDetector
    {
        private Rectangle EnemyRectangle, PipeRectangle, IntersectRectangle;

        public ICollision collisionSide;
        private EnemyPipeCollisionHandler collisionHandler;

        public EnemyPipeCollisionDetector()
        {
            collisionHandler = new EnemyPipeCollisionHandler();
        }

        public void DetectCollision(IEnemy enemy, Pipe pipe)
        {
            EnemyRectangle = enemy.CollisionRectangle;
            PipeRectangle = pipe.CollisionRectangle;

            if (EnemyRectangle.Intersects(PipeRectangle))
            {
                IntersectRectangle = Rectangle.Intersect(EnemyRectangle, PipeRectangle);

                if (IntersectRectangle.Height > IntersectRectangle.Width)
                {
                    if (EnemyRectangle.X > PipeRectangle.X) collisionSide = new LeftCollision(IntersectRectangle);
                    else collisionSide = new RightCollision(IntersectRectangle);
                }
                else
                {
                    if (EnemyRectangle.Y > PipeRectangle.Y) collisionSide = new TopCollision(IntersectRectangle);
                    else collisionSide = new BottomCollision(IntersectRectangle);
                }

                collisionHandler.HandleCollision(enemy, pipe, collisionSide);
            }
        }

        public void Update(IEnemy enemy, Pipe pipe)
        {
            DetectCollision(enemy, pipe);
        }
    }
}