using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class EnemyBridgeCollisionDetector
    {
        private Rectangle enemyRectangle, bridgeRectangle, intersectRectangle;
        public ICollision collision;

        public EnemyBridgeCollisionDetector()
        {
        }

        private void DetectCollision(IEnemy enemy, Bridge bridge)
        {
            enemyRectangle = enemy.CollisionRectangle;
            bridgeRectangle = bridge.CollisionRectangle;

            if (enemyRectangle.Intersects(bridgeRectangle))
            {               
                intersectRectangle = Rectangle.Intersect(enemyRectangle, bridgeRectangle);

                collision = new BottomCollision(intersectRectangle);
                enemy.Location = new Point(enemy.Location.X, enemy.Location.Y - collision.GetIntersectDistance());
                enemy.Velocity = new Vector2(enemy.Velocity.X, 0.0f);
                enemy.Bounce();
            }
        }

        public void Update(IEnemy enemy, Bridge bridge)
        {
            DetectCollision(enemy, bridge);
        }
    }
}
