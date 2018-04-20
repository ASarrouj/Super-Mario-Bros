using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    class PausedState : IGameState
    {
        private $safeprojectname$ game;
        private IPlayer player;
        private Level level;
        private ICamera camera;
        private CommandRegister input;

        public PausedState($safeprojectname$ game)
        {
            this.game = game;
            player = game.player;
            level = game.level;
            camera = new PlayerCamera(player);
            input = game.input;
            input.GetPauseControls();
            MediaPlayer.Pause();
        }

        public void NextSequencedState()
        {

        }

        public void TogglePause()
        {
            game.state = new GameplayState(game);
            SoundFactory.Instance.CreatePauseSound().Play();
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

        public void Update(GameTime gameTime)
        {
            input.Update(gameTime);
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
