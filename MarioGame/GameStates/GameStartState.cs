using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    class GameStartState : IGameState
    {
        private $safeprojectname$ game;
        private IPlayer player;
        private Level level;
        private MenuController menuController;
        private CommandRegister input;

        public GameStartState($safeprojectname$ game)
        {
            this.game = game;
            game.menuController = new MenuController(game);
            game.input = new CommandRegister(game);
            game.headsUpDisplay = new MarioGameHud();
            game.LoadLevel("titleLevel");
            player = game.player;
            menuController = game.menuController;
            input = game.input;
            input.GetTitleScreenControls();
            level = game.level;
            player.Location = level.StartLocation - player.StartOffset;
            player.Reset();
            MediaPlayer.Stop();
        }

        public void NextSequencedState()
        {
            game.state = new LevelStartState(game);
        }

        public void TogglePause()
        {

        }

        public void PlayerDying()
        {

        }

        public void PowerUpOrDamaged()
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
            batch.Begin();
            level.Draw(gametime, batch);
            menuController.Draw(gametime, batch);
            player.Draw(gametime, batch);
            batch.End();
        }
    }
}