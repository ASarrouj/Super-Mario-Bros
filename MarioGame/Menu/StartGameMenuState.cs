using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class StartGameMenuState : IMenuState
    {
        private MenuController menuController;
        private $safeprojectname$ game;
        private SpriteFont font;
        private Coin coinCursor;

        public StartGameMenuState(MenuController menuController)
        {
            this.menuController = menuController;
            game = menuController.game;
            coinCursor = menuController.coinCursor;
            coinCursor.Location = ConstantValues.COIN_CURSOR_POS1;
            font = SpriteFontFactory.Instance.CreateHudFont();
        }
        public void Back()
        {
            
        }

        public void Down()
        {
            SoundFactory.Instance.CreateBumpSound().Play();
            menuController.state = new OptionsMenuState(menuController);
        }

        public void Select()
        {
            game.LoadLevel("level1");
            game.state.NextSequencedState();
        }

        public void Up()
        {
            
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            batch.DrawString(font, ConstantValues.START_GAME, ConstantValues.MENU_OPTION1_POS, ConstantValues.HUD_COLOR);
            batch.DrawString(font, ConstantValues.OPTIONS, ConstantValues.MENU_OPTION2_POS, ConstantValues.HUD_COLOR);
            coinCursor.Draw(gametime, batch);
        }
    }
}
