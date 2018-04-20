using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    class GameOverState : IGameState
    {
        private $safeprojectname$ game;
        private IPlayer player;
        private SpriteFont font;
        private int currentFrame;

        public GameOverState($safeprojectname$ game)
        {
            this.game = game;
            player = game.player;
            font = SpriteFontFactory.Instance.CreateHudFont();
            currentFrame = 0;
            MediaPlayer.Stop();
        }

        public void NextSequencedState()
        {
            game.state = new GameStartState(game);
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

        public void FullResetPlayer()
        {
            player.Reset();
            player.Lives = 3;
            player.Coins = 0;
            player.Points = 0;
        }

        public void Update(GameTime gameTime)
        {
            currentFrame++;
            if (currentFrame == 300)
            {
                FullResetPlayer();
                NextSequencedState();
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            batch.Begin();
            batch.DrawString(font, ConstantValues.GAME_OVER, ConstantValues.GAME_OVER_POS, ConstantValues.HUD_COLOR);
            batch.End();
        }
    }
}