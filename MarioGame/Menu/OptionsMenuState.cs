using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class OptionsMenuState : IMenuState
    {
        private MenuController menuController;
        private $safeprojectname$ game;
        private SpriteFont font;
        private Coin coinCursor;

        public OptionsMenuState(MenuController menuController)
        {
            this.menuController = menuController;
            game = menuController.game;
            coinCursor = menuController.coinCursor;
            coinCursor.Location = ConstantValues.COIN_CURSOR_POS2;
            font = SpriteFontFactory.Instance.CreateHudFont();
        }
        public void Back()
        {

        }

        public void Down()
        {
            
        }

        public void Select()
        {
            SoundFactory.Instance.CreateStompSound().Play();
            menuController.state = new PlayAsMarioMenuState(menuController);
        }

        public void Up()
        {
            SoundFactory.Instance.CreateBumpSound().Play();
            menuController.state = new StartGameMenuState(menuController);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            batch.DrawString(font, ConstantValues.START_GAME, ConstantValues.MENU_OPTION1_POS, ConstantValues.HUD_COLOR);
            batch.DrawString(font, ConstantValues.OPTIONS, ConstantValues.MENU_OPTION2_POS, ConstantValues.HUD_COLOR);
            coinCursor.Draw(gametime, batch);
        }
    }
}