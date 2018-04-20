using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class PlayerDamagedOrPowerUpState : IGameState
    {
        private $safeprojectname$ game;
        private IPlayer player;
        private Level level;
        private ICamera camera;
        private int currentFrame;

        public PlayerDamagedOrPowerUpState($safeprojectname$ game)
        {
            this.game = game;
            player = game.player;
            level = game.level;
            camera = new PlayerCamera(player);
            currentFrame = 0;
        }

        public void NextSequencedState()
        {
            game.state = new GameplayState(game);
        }

        public void TogglePause()
        {

        }

        public void PowerUpOrDamaged()
        {

        }

        public void PlayerDying()
        {

        }

        public void TouchFlagpole()
        {

        }

        public void TouchAxe()
        {

        }

        public void IncrementTime()
        {
            currentFrame++;
            if (currentFrame == 60)
                NextSequencedState();
        }

        public void Update(GameTime gameTime)
        {
            IncrementTime();
            player.Update(gameTime);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            camera.BeginSpriteBatch(batch);
            level.Draw(gametime, batch);
            player.Draw(gametime, batch);
            batch.End();
        }
    }
}
