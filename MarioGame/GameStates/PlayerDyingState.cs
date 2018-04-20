using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    class PlayerDyingState : IGameState
    {
        private $safeprojectname$ game;
        private IPlayer player;
        private Level level;
        private ICamera camera;
        private int currentFrame;

        public PlayerDyingState($safeprojectname$ game)
        {
            this.game = game;
            player = game.player;
            level = game.level;
            camera = new PlayerCamera(player);
            if (player.Lives != 0)
                player.Lives = player.Lives - 1;
            currentFrame = 0;
            MediaPlayer.Stop();
        }

        public void NextSequencedState()
        {
            if (player.Lives != 0)
            {
                player.Reset();
                game.state = new LevelStartState(game);
            }
            else
                game.state = new GameOverState(game);
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
            if (currentFrame == 180)
            {
                NextSequencedState();
            }
        }

        public void Update(GameTime gameTime)
        {
            IncrementTime();
            level.Physics.Update(gameTime, player);
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