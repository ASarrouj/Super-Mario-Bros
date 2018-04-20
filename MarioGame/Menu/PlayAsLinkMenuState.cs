using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class PlayAsLinkMenuState : IMenuState
    {
        private MenuController menuController;
        private $safeprojectname$ game;
        private SpriteFont font;
        private Coin coinCursor;

        public PlayAsLinkMenuState(MenuController menuController)
        {
            this.menuController = menuController;
            game = menuController.game;
            coinCursor = menuController.coinCursor;
            coinCursor.Location = ConstantValues.COIN_CURSOR_POS2;
            font = SpriteFontFactory.Instance.CreateHudFont();
        }
        public void Back()
        {
            SoundFactory.Instance.CreateStompSound().Play();
            menuController.state = new OptionsMenuState(menuController);
        }

        public void Down()
        {
            
        }

        public void Select()
        {
            game.player = new Link(game);
            SoundFactory.Instance.CreateStompSound().Play();
            game.state = new GameStartState(game);
        }

        public void Up()
        {
            SoundFactory.Instance.CreateBumpSound().Play();
            menuController.state = new PlayAsMarioMenuState(menuController);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            batch.DrawString(font, ConstantValues.PLAY_AS_MARIO, ConstantValues.MENU_OPTION1_POS, ConstantValues.HUD_COLOR);
            batch.DrawString(font, ConstantValues.PLAY_AS_LINK, ConstantValues.MENU_OPTION2_POS, ConstantValues.HUD_COLOR);
            coinCursor.Draw(gametime, batch);
        }
    }
}