using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class EnemyBlockCollisionHandler
    {
        public EnemyBlockCollisionHandler()
        {
            
        }

        public void HandleCollision(IEnemy enemy, Block block, ICollision collision, IPlayer player)
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
                if (block.bumped)
                {
                    enemy.BeFlipped(ConstantValues.POINTS_ENEMY.ToString());
                    player.Points += ConstantValues.POINTS_ENEMY;
                }
                else
                {
                    enemy.Location = new Point(enemy.Location.X, enemy.Location.Y - collision.GetIntersectDistance());
                    enemy.Velocity = new Vector2(enemy.Velocity.X, 0.0f);
                    enemy.Bounce();
                }
            }
        }
    }
}