using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace $safeprojectname$
{
    public class ConstantValues
    {
        public static int ZERO = 0;
        public static int MAX_TIME = 300;

        public static Color HUD_COLOR = Color.White;

        public static readonly Vector2 HUD_TITLE_POS = new Vector2(10, 10);
        public static readonly Vector2 HUD_SCORE_VAR_POS = new Vector2(10, 30);

        public static readonly String HUD_X = "X";
        public static readonly Point HUD_COIN_SPRITE_POS = new Point(72, 10);
        public static readonly Vector2 HUD_X_POS = new Vector2(88, 10);
        public static readonly Vector2 HUD_COIN_VAR_POS = new Vector2(104, 10);

        public static readonly String HUD_WORLD = "WORLD";
        public static readonly Vector2 HUD_WORLD_POS = new Vector2(128, 10);

        public static readonly String HUD_LEVEL = "1-1";
        public static readonly Vector2 HUD_LEVEL_POS = new Vector2(134, 30);

        public static readonly String HUD_TIME = "TIME";
        public static readonly Vector2 HUD_TIME_POS = new Vector2(192, 10);
        public static readonly Vector2 HUD_TIME_VAR_POS = new Vector2(192, 30);

        public static readonly Vector2 LEVEL_START_WORLD_POS = new Vector2(88, 80);
        public static readonly Vector2 LEVEL_START_LEVEL_POS = new Vector2(148, 80);

        public static readonly Vector2 LEVEL_START_PLAYER_POS = new Vector2(98, 113);
        public static readonly Vector2 LEVEL_START_X_POS = new Vector2(128, 116);
        public static readonly Vector2 LEVEL_START_LIVES_POS = new Vector2(150, 116);

        public static readonly Point COIN_CURSOR_POS1 = new Point(75, 160);
        public static readonly Point COIN_CURSOR_POS2 = new Point(75, 180);
        public static readonly Vector2 MENU_OPTION1_POS = new Vector2(95, 160);
        public static readonly Vector2 MENU_OPTION2_POS = new Vector2(95, 180);
        public static readonly String START_GAME = "START GAME";
        public static readonly String OPTIONS = "OPTIONS";
        public static readonly String PLAY_AS_MARIO = "PLAY AS MARIO";
        public static readonly String PLAY_AS_LINK = "PLAY AS LINK";

        public static readonly String GAME_OVER = "GAME OVER";
        public static readonly Vector2 GAME_OVER_POS = new Vector2(88, 116);

        public static readonly int POINTS_ENEMY = 100;
        public static readonly int POINTS_COIN = 200;
        public static readonly int POINTS_POWERUP = 1000;
        public static readonly int POINTS_FLAG = 5000;

        public static readonly int CAMERA_WIDTH = 256;
        public static readonly int CAMERA_HEIGHT = 240;
        public static readonly int CAMERA_SCALE = 4;

        public static readonly Point BLOCK_SIZE = new Point(16, 16);
        public static readonly Point FIREBALL_SIZE = new Point(8, 8);

        public static readonly int SPINNY_FIREBALL_COUNT = 6;
        public static readonly float SPINNY_ANGULAR_VELOCITY = 1.57f;
        public static readonly float SPINNY_FIREBALL_SPACING = 8.0f;

        public static readonly float PLAYER_ACCELERATION = 600.0f;
        public static readonly float PLAYER_AUTOWALK_VELOCITY = 75.0f;
        public static readonly float PLAYER_TERMINAL_SPRINT_VELOCITY = 200.0f;
        public static readonly float PLAYER_TERMINAL_WALK_VELOCITY = 100.0f;
    }
}