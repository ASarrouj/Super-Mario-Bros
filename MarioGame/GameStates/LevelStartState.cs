using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    class LevelStartState : IGameState
    {
        private $safeprojectname$ game;
        private IPlayer player;
        private IPlayerState oldState;
        private SpriteFont font;
        private Level level;
        private int currentFrame;

        public LevelStartState($safeprojectname$ game)
        {
            this.game = game;
            player = game.player;
            oldState = player.State;
            player.Reset();
            player.Position = ConstantValues.LEVEL_START_PLAYER_POS - player.StartOffset.ToVector2();
            level = game.level;
            game.headsUpDisplay.ResetTimer();
            font = SpriteFontFactory.Instance.CreateHudFont();
            currentFrame = 0;
            MediaPlayer.Stop();
        }

        public void NextSequencedState()
        {
            game.state = new GameplayState(game);
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

        public void RevertMario()
        {       
            player.State = oldState;
            player.Velocity = Vector2.Zero;
            game.ReloadLevel();
            player.Location = game.level.StartLocation - player.StartOffset;
            player.Idle();
            player.Auto = false;
        }

        public void Update(GameTime gameTime)
        {
            currentFrame++;
            if (currentFrame == 250)
            {
                RevertMario();
                NextSequencedState();
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            batch.Begin();
            batch.DrawString(font, ConstantValues.HUD_WORLD, ConstantValues.LEVEL_START_WORLD_POS, ConstantValues.HUD_COLOR);
            batch.DrawString(font, level.Name, ConstantValues.LEVEL_START_LEVEL_POS, ConstantValues.HUD_COLOR);
            batch.DrawString(font, ConstantValues.HUD_X, ConstantValues.LEVEL_START_X_POS, ConstantValues.HUD_COLOR);
            batch.DrawString(font, player.Lives.ToString(), ConstantValues.LEVEL_START_LIVES_POS, ConstantValues.HUD_COLOR);
            player.Draw(gametime, batch);
            batch.End();
        }
    }
}