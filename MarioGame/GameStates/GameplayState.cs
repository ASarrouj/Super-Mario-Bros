
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    class GameplayState : IGameState
    {
        private $safeprojectname$ game;
        private IPlayer player;
        private Level level;
        private ICamera camera;
        private MarioGameHud hud;
        private CommandRegister input;
        private Song starMusic;

        public GameplayState($safeprojectname$ game)
        {
            this.game = game;
            player = game.player;
            player.Auto = false;
            level = game.level;
            camera = new PlayerCamera(player);
            hud = game.headsUpDisplay;
            level.Camera = camera;
            input = game.input;
            input.GetGameplayControls();
            starMusic = MusicFactory.Instance.CreateStarMusic();
            MediaPlayer.Resume();

            if (MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.Play(level.BackgroundMusic);
            }
        }

        public void NextSequencedState()
        {

        }

        public void TogglePause()
        {
            game.state = new PausedState(game);
            SoundFactory.Instance.CreatePauseSound().Play();
        }

        public void PlayerDying()
        {
            game.state = new PlayerDyingState(game);
            SoundFactory.Instance.CreateMarioDieSound().Play();
        }

        public void PowerUpOrDamaged()
        {
            game.state = new PlayerDamagedOrPowerUpState(game);
        }

        public void TouchFlagpole()
        {
            game.state = new FlagpoleReachedState(game);
        }

        public void TouchAxe()
        {
            game.state = new AxeReachedState(game);
        }

        public void CheckPlayerOffscreen()
        {
            if (!(player.CollisionRectangle.Intersects(camera.CollisionRectangle)))
            {
                PlayerDying();
            }
        }

        public void CheckWeaponsOffscreen()
        {
            foreach (IWeapon weapon in player.Weapons)
            if (!(weapon.CollisionRectangle.Intersects(camera.CollisionRectangle)))
                weapon.Delete();
        }

        public void CheckIfTimeIsUp()
        {
            if (hud.Time <= ConstantValues.ZERO)
            {
                player.Kill();
                PlayerDying();
            }
        }

        public void Update(GameTime gameTime)
        {
            input.Update(gameTime);
            player.Update(gameTime);
            level.Update(gameTime, player);

            CheckPlayerOffscreen();
            CheckWeaponsOffscreen();

            hud.Update(player.Points, player.Coins, gameTime.ElapsedGameTime.TotalSeconds);
            UpdateMusic(gameTime);
        }

        public void UpdateMusic(GameTime gameTime)
        {
            if (player.Star.Active)
            {
                if (MediaPlayer.Queue.ActiveSong != starMusic)
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(starMusic);
                }
            }
            else if (MediaPlayer.Queue.ActiveSong != level.BackgroundMusic)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(level.BackgroundMusic);
            }
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
