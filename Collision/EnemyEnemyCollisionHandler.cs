using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class EnemyEnemyCollisionHandler
    {
        public EnemyEnemyCollisionHandler()
        {
            
        }

        public void HandleCollision(IEnemy enemy1, IEnemy enemy2, IPlayer player)
        {
            if (enemy1.IsShell) {
                if (enemy2.IsShell)
                {
                    if (enemy1.Velocity.X != 0) enemy1.ChangeDirection();
                    if (enemy2.Velocity.X != 0) enemy2.ChangeDirection();
                }
                else if (enemy1.Velocity.X == 0) enemy2.ChangeDirection();
                else enemy2.BeFlipped(ConstantValues.POINTS_ENEMY.ToString()); player.Points += ConstantValues.POINTS_ENEMY;
            }
            else if (enemy2.IsShell) {
                if (enemy2.Velocity.X == 0) enemy1.ChangeDirection();
                else enemy1.BeFlipped(ConstantValues.POINTS_ENEMY.ToString()); player.Points += ConstantValues.POINTS_ENEMY;
            }
            else if ((enemy1.Location.X < enemy2.Location.X && enemy1.Velocity.X > 0 && enemy2.Velocity.X < 0)
                || (enemy2.Location.X < enemy1.Location.X && enemy2.Velocity.X > 0 && enemy1.Velocity.X < 0)) {
                enemy1.ChangeDirection();
                enemy2.ChangeDirection();
            }
        }
    }
}