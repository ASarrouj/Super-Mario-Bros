using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PlayerEnemyCollisionDetector
    {
        private Rectangle playerRectangle, enemyRectangle, intersectRectangle;
        private PlayerEnemyCollisionHandler collisionHandler;
        public ICollision collision;

        public PlayerEnemyCollisionDetector()
        {
            collisionHandler = new PlayerEnemyCollisionHandler();
        }

        private void DetectCollision(IPlayer player, IEnemy enemy)
        {
            playerRectangle = player.CollisionRectangle;
            enemyRectangle = enemy.CollisionRectangle;

            if (playerRectangle.Intersects(enemyRectangle))
            {
                intersectRectangle = Rectangle.Intersect(playerRectangle, enemyRectangle);
                if (intersectRectangle.Width > 0 && intersectRectangle.Height > 0) {
                    if (intersectRectangle.Height > intersectRectangle.Width)
                    {
                        if (playerRectangle.X > enemyRectangle.X) collision = new LeftCollision(intersectRectangle);
                        else collision = new RightCollision(intersectRectangle);
                    }
                    else
                    {
                        if (playerRectangle.Y + 1 >= enemyRectangle.Y) collision = new TopCollision(intersectRectangle);
                        else collision = new BottomCollision(intersectRectangle);
                    }

                    if (player.Velocity.Y < 0) collision = new BottomCollision(intersectRectangle);

                    collisionHandler.HandleCollision(player, enemy, collision);
                }
            }
        }

        public void Update(IPlayer player, IEnemy enemy)
        {
            DetectCollision(player, enemy);
        }
    }
}
