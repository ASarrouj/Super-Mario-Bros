using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace $safeprojectname$
{
    public class CommandRegister
    {
        private IPlayer player;
        private $safeprojectname$ game;
        private KeyboardController keyboard;
        private GamepadController gamepad;

        private UpCursorCommand upCursor;
        private DownCursorCommand downCursor;
        private SelectCommand selectOption;
        private BackCommand backOption;

        private QuitCommand quit;
        private ResetGameCommand reset;
        private PauseCommand pause;
        private PlayerJumpCommand jump;
        private PlayerDownCommand down;
        private PlayerMoveLeftCommand moveLeft;
        private PlayerMoveRightCommand moveRight;
        private PlayerIdleCommand idle;
        private PlayerUseWeaponCommand useWeapon;
        private PlayerSprintCommand sprint;
        private KeyboardOnCommand keyboardOn;
        private GamepadOnCommand gamepadOn;

        private IKeyChecker Q, R, P, Z, upArrow, downArrow, leftArrow, rightArrow, X, Enter, noArrowKeys, leftAndRightArrowKeys;
        private IButtonChecker A, B, Y, start, back, leftStick, leftStickLeft, leftStickRight, leftStickUp, leftStickDown, dPadLeft, dPadRight, dPadUp, dPadDown, noDirections;

        public CommandRegister($safeprojectname$ game)
        {
            this.game = game;
            player = game.player;

            keyboard = new KeyboardController();
            gamepad = new GamepadController();

            upCursor = new UpCursorCommand(game.menuController);
            downCursor = new DownCursorCommand(game.menuController);
            selectOption = new SelectCommand(game.menuController);
            backOption = new BackCommand(game.menuController);

            quit = new QuitCommand(game);
            reset = new ResetGameCommand(game);
            pause = new PauseCommand(game);
            jump = new PlayerJumpCommand(player);
            down = new PlayerDownCommand(player);
            moveLeft = new PlayerMoveLeftCommand(player);
            moveRight = new PlayerMoveRightCommand(player);
            idle = new PlayerIdleCommand(player);
            useWeapon = new PlayerUseWeaponCommand(player);
            sprint = new PlayerSprintCommand(player);
            keyboardOn = new KeyboardOnCommand(keyboard, gamepad);
            gamepadOn = new GamepadOnCommand(keyboard, gamepad);

            Q = new SingleKeyDownChecker(Keys.Q);
            R = new SingleKeyDownChecker(Keys.R);
            P = new SingleKeyDownChecker(Keys.P);
            Z = new SingleKeyDownChecker(Keys.Z);
            upArrow = new SingleKeyDownChecker(Keys.Up);
            downArrow = new SingleKeyDownChecker(Keys.Down);
            leftArrow = new SingleKeyDownChecker(Keys.Left);
            rightArrow = new SingleKeyDownChecker(Keys.Right);
            leftAndRightArrowKeys = new MultipleKeyDownChecker(new Keys[2] { Keys.Left, Keys.Right });
            X = new SingleKeyDownChecker(Keys.X);
            Enter = new SingleKeyDownChecker(Keys.Enter);
            noArrowKeys = new MultipleKeyUpChecker(new Keys[3] { Keys.Left, Keys.Right, Keys.Down});

            A = new SingleButtonDownChecker(Buttons.A);
            B = new SingleButtonDownChecker(Buttons.B);
            Y = new SingleButtonDownChecker(Buttons.Y);
            start = new SingleButtonDownChecker(Buttons.Start);
            back = new SingleButtonDownChecker(Buttons.Back);
            leftStick = new SingleButtonDownChecker(Buttons.LeftStick);
            leftStickLeft = new SingleButtonDownChecker(Buttons.LeftThumbstickLeft);
            leftStickRight = new SingleButtonDownChecker(Buttons.LeftThumbstickRight);
            leftStickUp = new SingleButtonDownChecker(Buttons.LeftThumbstickUp);
            leftStickDown = new SingleButtonDownChecker(Buttons.LeftThumbstickDown);
            dPadLeft = new SingleButtonDownChecker(Buttons.DPadLeft);
            dPadRight = new SingleButtonDownChecker(Buttons.DPadRight);
            dPadUp = new SingleButtonDownChecker(Buttons.DPadUp);
            dPadDown = new SingleButtonDownChecker(Buttons.DPadDown);
            noDirections = new MultipleButtonUpChecker(new Buttons[6] {Buttons.DPadLeft, Buttons.DPadRight, Buttons.DPadDown,
                                                        Buttons.LeftThumbstickLeft, Buttons.LeftThumbstickRight, Buttons.LeftThumbstickDown });
        }

        public void GetTitleScreenControls()
        {
            keyboard.ClearCallbacks();
            gamepad.ClearCallbacks();

            keyboard.RegisterCallback(upArrow, upCursor);
            keyboard.RegisterCallback(downArrow, downCursor);
            keyboard.RegisterCallback(Z, selectOption);
            keyboard.RegisterCallback(X, backOption);
            keyboard.RegisterCallback(Q, quit);
            keyboard.RegisterCallback(Enter, keyboardOn);

            gamepad.RegisterCallback(leftStickUp, upCursor);
            gamepad.RegisterCallback(leftStickDown, downCursor);
            gamepad.RegisterCallback(A, selectOption);
            gamepad.RegisterCallback(B, backOption);
            gamepad.RegisterCallback(dPadUp, upCursor);
            gamepad.RegisterCallback(dPadDown, downCursor);
            gamepad.RegisterCallback(leftStick, quit);
            gamepad.RegisterCallback(back, gamepadOn);
        }

        public void GetGameplayControls()
        {
            keyboard.ClearCallbacks();
            gamepad.ClearCallbacks();

            keyboard.RegisterCallback(Q, quit);
            keyboard.RegisterCallback(R, reset);
            keyboard.RegisterCallback(P, pause);
            keyboard.RegisterCallback(Z, jump);
            keyboard.RegisterCallback(downArrow, down);
            keyboard.RegisterCallback(leftArrow, moveLeft);
            keyboard.RegisterCallback(rightArrow, moveRight);
            keyboard.RegisterCallback(leftAndRightArrowKeys, idle);
            keyboard.RegisterCallback(noArrowKeys, idle);
            keyboard.RegisterCallback(X, useWeapon);
            keyboard.RegisterCallback(X, sprint);
            keyboard.RegisterCallback(Enter, keyboardOn);

            gamepad.RegisterCallback(leftStick, quit);
            gamepad.RegisterCallback(Y, reset);
            gamepad.RegisterCallback(start, pause);
            gamepad.RegisterCallback(dPadRight, moveRight);
            gamepad.RegisterCallback(dPadDown, down);
            gamepad.RegisterCallback(dPadLeft, moveLeft);
            gamepad.RegisterCallback(leftStickRight, moveRight);
            gamepad.RegisterCallback(leftStickDown, down);
            gamepad.RegisterCallback(leftStickLeft, moveLeft);
            gamepad.RegisterCallback(A, jump);
            gamepad.RegisterCallback(noDirections, idle);
            gamepad.RegisterCallback(B, useWeapon);
            gamepad.RegisterCallback(B, sprint);
            gamepad.RegisterCallback(back, gamepadOn);
        }

        public void GetPauseControls()
        {
            keyboard.ClearCallbacks();
            gamepad.ClearCallbacks();

            keyboard.RegisterCallback(Q, quit);
            keyboard.RegisterCallback(R, reset);
            keyboard.RegisterCallback(P, pause);
            keyboard.RegisterCallback(Enter, keyboardOn);

            gamepad.RegisterCallback(leftStick, quit);
            gamepad.RegisterCallback(Y, reset);
            gamepad.RegisterCallback(start, pause);
            gamepad.RegisterCallback(back, gamepadOn);
        }

        public void Update(GameTime gametime)
        {
            keyboard.Update(gametime);
            gamepad.Update(gametime);
        }
    }
}