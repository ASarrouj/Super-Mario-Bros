
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    class PipeTransitionState : IGameState
    {
        private $safeprojectname$ game;
        private IPlayer player;
        private Level level;
        private ICamera camera;
        private int currentFrame;
        private Point destinationPoint;
        private string destinationLevel;

        public PipeTransitionState($safeprojectname$ game, string destinationLevel, Point destinationPoint)
        {
            this.game = game;
            player = game.player;
            level = game.level;
            camera = new PlayerCamera(player);
            level.Camera = camera;
            this.destinationLevel = destinationLevel;
            this.destinationPoint = destinationPoint;
            SoundFactory.Instance.CreatePipeSound().Play();
            MediaPlayer.Pause();
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

        public void ChangeLevel()
        {
            game.LoadLevel(destinationLevel);
            player.Location = destinationPoint;
            NextSequencedState();
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            currentFrame++;
            if (currentFrame <= 45)
                player.Position += player.Velocity;
            if (currentFrame == 90)
                ChangeLevel();
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            camera.BeginSpriteBatch(batch);
            if (currentFrame <= 45)
                player.Draw(gametime, batch);
            level.Draw(gametime, batch);
            batch.End();
        }
    }
}
