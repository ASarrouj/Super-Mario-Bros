using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class EnemyBlockCollisionDetector
    {
        private Rectangle EnemyRectangle, BlockRectangle, IntersectRectangle;

        public ICollision collisionSide;
        private EnemyBlockCollisionHandler collisionHandler;

        public EnemyBlockCollisionDetector()
        {
            collisionHandler = new EnemyBlockCollisionHandler();
        }

        public void DetectCollision(IEnemy enemy, Block block, IPlayer player)
        {
            EnemyRectangle = enemy.CollisionRectangle;
            BlockRectangle = block.CollisionRectangle;

            if (EnemyRectangle.Intersects(BlockRectangle))
            {
                IntersectRectangle = Rectangle.Intersect(EnemyRectangle, BlockRectangle);

                if (IntersectRectangle.Height - IntersectRectangle.Width > 2)
                {
                    if (EnemyRectangle.X > BlockRectangle.X) collisionSide = new LeftCollision(IntersectRectangle);
                    else collisionSide = new RightCollision(IntersectRectangle);
                }
                else
                {
                    if (EnemyRectangle.Y > BlockRectangle.Y) collisionSide = new TopCollision(IntersectRectangle);
                    else collisionSide = new BottomCollision(IntersectRectangle);
                }

                collisionHandler.HandleCollision(enemy, block, collisionSide, player);
            }
        }

        public void Update(IEnemy enemy, Block block, IPlayer player)
        {
            DetectCollision(enemy, block, player);
        }
    }
}