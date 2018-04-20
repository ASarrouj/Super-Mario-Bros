using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace $safeprojectname$
{
    public class $safeprojectname$ : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private RenderTarget2D renderTarget;

        public IGameState state;
        public IPlayer player;
        public MenuController menuController;
        public Level level;
        private CSVLevelLoader levelLoader;
        public CommandRegister input;
        public MarioGameHud headsUpDisplay;

        public $safeprojectname$()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = ConstantValues.CAMERA_WIDTH * ConstantValues.CAMERA_SCALE;
            graphics.PreferredBackBufferHeight = ConstantValues.CAMERA_HEIGHT * ConstantValues.CAMERA_SCALE;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            renderTarget = new RenderTarget2D(graphics.GraphicsDevice, ConstantValues.CAMERA_WIDTH, ConstantValues.CAMERA_HEIGHT,
                false, SurfaceFormat.Color, DepthFormat.None, 2, RenderTargetUsage.DiscardContents);
            MediaPlayer.IsRepeating = true;
            base.Initialize();    
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SmallMarioSpriteFactory.Instance.LoadAllTextures(Content);
            BigMarioSpriteFactory.Instance.LoadAllTextures(Content);
            FireMarioSpriteFactory.Instance.LoadAllTextures(Content);
            MarioTransitionSpriteFactory.Instance.LoadAllTextures(Content);
            GreenLinkSpriteFactory.Instance.LoadAllTextures(Content);
            RedLinkSpriteFactory.Instance.LoadAllTextures(Content);
            LinkTransitionSpriteFactory.Instance.LoadAllTextures(Content);
            FireballSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            PipeSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            ScenerySpriteFactory.Instance.LoadAllTextures(Content);
            EndObjectSpriteFactory.Instance.LoadAllTextures(Content);
            SoundFactory.Instance.LoadAllSounds(Content);
            MusicFactory.Instance.LoadAllMusic(Content);
            SpriteFontFactory.Instance.LoadAllFonts(Content);
            HazardSpriteFactory.Instance.LoadAllTextures(Content);
            PlatformSpriteFactory.Instance.LoadAllTextures(Content);

            player = new Mario(this);
            levelLoader = new CSVLevelLoader();
            state = new GameStartState(this);
        }

        private string levelName;

        public void LoadLevel(string name)
        {
            this.levelName = "Content/" + name + ".csv";
            level = levelLoader.LoadLevel(levelName);
        }

        public void ReloadLevel()
        {
            level = levelLoader.LoadLevel(levelName);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            state.Update(gameTime);
            base.Update(gameTime);
        }

        private void RenderGame(GameTime gameTime)
        {
            graphics.GraphicsDevice.SetRenderTarget(renderTarget);
            state.Draw(gameTime, spriteBatch);
            headsUpDisplay.Draw(spriteBatch, player.GetType().Name.ToUpper());

            graphics.GraphicsDevice.SetRenderTarget(null);
        }

        private void DrawUpscaledToScreen()
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(renderTarget,
                new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                Color.White);
            spriteBatch.End();
        }
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            RenderGame(gameTime);
            DrawUpscaledToScreen();
        }
    }
}