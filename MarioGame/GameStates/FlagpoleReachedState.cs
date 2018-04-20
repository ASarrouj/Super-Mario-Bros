using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    class FlagpoleReachedState : IGameState
    {
        private $safeprojectname$ game;
        private IPlayer player;
        private Level level;
        private MarioGameHud hud;
        private ICamera camera;
        private int currentFrame;
        private int autorunFrame;

        public FlagpoleReachedState($safeprojectname$ game)
        {
            this.game = game;
            player = game.player;
            level = game.level;
            hud = game.headsUpDisplay;
            camera = new PlayerCamera(player);
            currentFrame = 0;
            autorunFrame = 0;
            MediaPlayer.Pause();
            SoundFactory.Instance.CreateFlagpoleSound().Play();
        }

        public void NextSequencedState()
        {
            game.state = new LevelStartState(game);
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
            if (player.Auto) autorunFrame++;
            if (autorunFrame == 85)
            {
                player.Velocity = Vector2.Zero;
                player.TransitionRight();
            }
            if (currentFrame == 570)
            {
                game.LoadLevel(level.NextLevel);
                player.Idle();
                player.Velocity = Vector2.Zero;
                NextSequencedState();
            }
            else if (currentFrame == 200)
                SoundFactory.Instance.CreateStageClearSound().Play();
            else if (currentFrame > 210 & player.Velocity.X == ConstantValues.ZERO)
                hud.ConvertTimeToPoints();
        }

        public void Update(GameTime gameTime)
        {
            IncrementTime();
            player.Update(gameTime);
            level.Update(gameTime, player);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
            camera.BeginSpriteBatch(batch);
            level.Draw(gametime, batch);
            player.Draw(gametime, batch);
            batch.End();
        }
    }
}