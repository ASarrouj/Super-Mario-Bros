namespace $safeprojectname$
{
    public class EnemyWeaponCollisionHandler
    {
        public EnemyWeaponCollisionHandler() { }

        public void HandleCollision(IEnemy enemy, IWeapon weapon, IPlayer player)
        {
            enemy.BeFlipped(ConstantValues.POINTS_ENEMY.ToString());
            weapon.StandardCollision();
            player.Points += ConstantValues.POINTS_ENEMY;
        }
    }
}