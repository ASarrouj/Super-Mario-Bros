using Microsoft.Xna.Framework;
namespace $safeprojectname$
{
    public class PlayerEnemyCollisionHandler
    {
        public PlayerEnemyCollisionHandler() { }

        public int BonusValue(int bonus)
        {
            switch (bonus)
            {
                case 1: return 100;
                case 2: return 200;
                case 3: return 300;
                case 4: return 500;
                case 5: return 800;
                case 6: return 1000;
                case 7: return 2000;
                case 8: return 4000;
                case 9: return 5000;
                case 10: return 8000;
                default: return -1;
            }

        }

        public void HandleCollision(IPlayer player, IEnemy enemy, ICollision collision)
        {
            if (collision is BottomCollision)
            {
                if (enemy is Bowser && !player.Invincible)
                {
                    if (!player.Star.Active)
                    {
                        player.TakeDamage();
                        player.Location = new Point(player.Location.X, player.Location.Y - collision.GetIntersectDistance());
                    }
                }
                else if (player.Star.Active && !(enemy.IsShell && enemy.Velocity.X == 0))
                {
                    enemy.BeFlipped(ConstantValues.POINTS_ENEMY.ToString());
                    player.Points += ConstantValues.POINTS_ENEMY;
                }
                else if (player.Velocity.Y > 0)
                {
                    if (enemy.IsShell && enemy.Velocity.X == 0 && enemy.Location.X < player.Location.X) enemy.ChangeDirection();
                    int b = BonusValue(++player.JumpBonus);
                    if (b > 0)
                    {
                        player.Points += b;
                        enemy.BeStomped(b.ToString());
                    }
                    else
                    {
                        player.Lives = player.Lives + 1;
                        enemy.BeStomped("1-UP");
                    }
                    player.Jumping = true;
                    player.Location = new Point(player.Location.X, player.Location.Y - collision.GetIntersectDistance());
                    player.Velocity = new Vector2(player.Velocity.X, -200.0f);       
                }
            }
            else if (!player.Invincible && collision is TopCollision)
            {
                if (player.Star.Active) enemy.BeFlipped(ConstantValues.POINTS_ENEMY.ToString());
                else player.TakeDamage();
            }
            else if (!player.Invincible && collision is LeftCollision)
            {
                if (enemy.IsShell && enemy.Velocity.X == 0)
                {
                    player.Location = new Point(player.Location.X + collision.GetIntersectDistance(), player.Location.Y);
                    enemy.ChangeDirection();
                    enemy.BeStomped(ConstantValues.POINTS_ENEMY.ToString());
                }
                else if (player.Star.Active) enemy.BeFlipped(ConstantValues.POINTS_ENEMY.ToString());
                else player.TakeDamage();
            }
            else if (!player.Invincible && collision is RightCollision)
            {
                if (enemy.IsShell && enemy.Velocity.X == 0)
                {
                    player.Location = new Point(player.Location.X - collision.GetIntersectDistance(), player.Location.Y);
                    enemy.BeStomped(ConstantValues.POINTS_ENEMY.ToString());
                }
                else if (player.Star.Active) enemy.BeFlipped(ConstantValues.POINTS_ENEMY.ToString());
                else player.TakeDamage();
            }
        }

    }
}