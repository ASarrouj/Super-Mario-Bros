using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class MenuController
    {
        public $safeprojectname$ game;
        public Coin coinCursor;
        public IMenuState state;

        public MenuController($safeprojectname$ game)
        {
            this.game = game;
            coinCursor = new Coin(ConstantValues.COIN_CURSOR_POS1, false);
            state = new StartGameMenuState(this);
        }

        public void Up()
        {
            state.Up();
        }

        public void Down()
        {
            state.Down();
        }

        public void Select()
        {
            state.Select();
        }

        public void Back()
        {
            state.Back();
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            state.Draw(gametime, batch);
        }
    }
}
