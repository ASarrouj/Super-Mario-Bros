using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class EnemyPipeCollisionHandler
    {
        public EnemyPipeCollisionHandler()
        {
            
        }

        public void HandleCollision(IEnemy enemy, Pipe pipe, ICollision collision)
        {
            if (collision is LeftCollision)
            {
                enemy.Location = new Point(enemy.Location.X + collision.GetIntersectDistance(), enemy.Location.Y);
                enemy.ChangeDirection();
            }
            else if (collision is RightCollision)
            {
                enemy.Location = new Point(enemy.Location.X - collision.GetIntersectDistance(), enemy.Location.Y);
                enemy.ChangeDirection();
            }
            else if (collision is TopCollision)
            {
            }
            else if (collision is BottomCollision)
            {
                enemy.Location = new Point(enemy.Location.X, enemy.Location.Y - collision.GetIntersectDistance());
                enemy.Velocity = new Vector2(enemy.Velocity.X, 0.0f);
            }
        }
    }
}