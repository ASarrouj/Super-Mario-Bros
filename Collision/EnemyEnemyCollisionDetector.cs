using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class EnemyEnemyCollisionDetector
    {
        private Rectangle Enemy1Rectangle, Enemy2Rectangle;

        private EnemyEnemyCollisionHandler collisionHandler;

        public EnemyEnemyCollisionDetector()
        {
            collisionHandler = new EnemyEnemyCollisionHandler();
        }

        public void DetectCollision(IEnemy enemy1, IEnemy enemy2, IPlayer player)
        {
            Enemy1Rectangle = enemy1.CollisionRectangle;
            Enemy2Rectangle = enemy2.CollisionRectangle;

            if (Enemy1Rectangle.Intersects(Enemy2Rectangle))
            {
                collisionHandler.HandleCollision(enemy1, enemy2, player);
            }
        }

        public void Update(IEnemy enemy1, IEnemy enemy2, IPlayer player)
        {
            DetectCollision(enemy1, enemy2, player);
        }
    }
}