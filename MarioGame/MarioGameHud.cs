using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class MarioGameHud
    {
        private SpriteFont HudFont;
        private int Score;
        private int Coins;
        public int Time;
        private double ElapsedTimeCounter;

        public MarioGameHud()
        {
            HudFont = SpriteFontFactory.Instance.CreateHudFont();
            Score = ConstantValues.ZERO;
            Coins = ConstantValues.ZERO;
            Time = ConstantValues.MAX_TIME;
            ElapsedTimeCounter = 0;
        }

        public void ResetTimer()
        {
            Time = ConstantValues.MAX_TIME;
        }

        public void ConvertTimeToPoints()
        {
            if (Time > 0)
            {
                Time--;
                Score += 100;
            }

        }

        public void Draw(SpriteBatch spriteBatch, string playerType)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);

            spriteBatch.DrawString(HudFont, playerType, ConstantValues.HUD_TITLE_POS, ConstantValues.HUD_COLOR);
            spriteBatch.DrawString(HudFont, Score.ToString(), ConstantValues.HUD_SCORE_VAR_POS, ConstantValues.HUD_COLOR);

            ItemSpriteFactory.Instance.CreateHudCoin().Draw(spriteBatch, ConstantValues.HUD_COIN_SPRITE_POS);
            
            spriteBatch.DrawString(HudFont, ConstantValues.HUD_X, ConstantValues.HUD_X_POS, ConstantValues.HUD_COLOR);
            spriteBatch.DrawString(HudFont, Coins.ToString(), ConstantValues.HUD_COIN_VAR_POS, ConstantValues.HUD_COLOR);

            spriteBatch.DrawString(HudFont, ConstantValues.HUD_WORLD, ConstantValues.HUD_WORLD_POS, ConstantValues.HUD_COLOR);
            spriteBatch.DrawString(HudFont, ConstantValues.HUD_LEVEL, ConstantValues.HUD_LEVEL_POS, ConstantValues.HUD_COLOR);

            spriteBatch.DrawString(HudFont, ConstantValues.HUD_TIME, ConstantValues.HUD_TIME_POS, ConstantValues.HUD_COLOR);
            spriteBatch.DrawString(HudFont, Time.ToString(), ConstantValues.HUD_TIME_VAR_POS, ConstantValues.HUD_COLOR);

            spriteBatch.End();
        }

        public void Update(int score, int coins, double elapsedTime)
        {
            Score = score;
            Coins = coins;
            ElapsedTimeCounter += elapsedTime;
            if(ElapsedTimeCounter.CompareTo(1) >= 0)
            {
                Time--;
                ElapsedTimeCounter = 0;
            }
        }
    }
}