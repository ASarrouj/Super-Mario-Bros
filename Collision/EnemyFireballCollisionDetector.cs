using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class EnemyWeaponCollisionDetector
    {
        private Rectangle EnemyRectangle, WeaponRectangle;
        private EnemyWeaponCollisionHandler collisionHandler;

        public EnemyWeaponCollisionDetector()
        {
            collisionHandler = new EnemyWeaponCollisionHandler();
        }

        public void DetectCollision(IEnemy enemy, IWeapon weapon, IPlayer player)
        {
            EnemyRectangle = enemy.CollisionRectangle;
            WeaponRectangle = weapon.CollisionRectangle;

            if (EnemyRectangle.Intersects(WeaponRectangle))
            {
                collisionHandler.HandleCollision(enemy, weapon, player);
            }
        }

        public void Update(IEnemy enemy, IWeapon weapon, IPlayer player)
        {
            DetectCollision(enemy, weapon, player);
        }
    }
}