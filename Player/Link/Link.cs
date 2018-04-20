using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public class Link : IPlayer
    {
        public $safeprojectname$ game;
        public IPlayerState state;
        public StarPlayer starLink;
        public Sword sword;
        public List<IWeapon> weapons;
        protected Vector2 position, velocity, acceleration;
        public Vector2 terminalVelocity;
        public bool invincible, jumping, crouching, auto, frozen;
        protected float accelerationSnap = 1.50f;
        protected int lives, coins, points, jumpBonus, currentFrame;

        public Link($safeprojectname$ game)
        {
            this.game = game;
            state = new RightIdleGreenLinkState(this);
            sword = new Sword(this);
            weapons = new List<IWeapon>();
            weapons.Add(sword);
            invincible = false;
            frozen = false;
            auto = false;
            terminalVelocity = new Vector2(130.0f, 1000.0f);
            currentFrame = 0;
            lives = 3;
            coins = 0;
            points = 0;
        }

        public Point Location
        {
            get { return position.ToPoint(); }
            set { position = new Vector2(value.X, value.Y); }
        }

        public Vector2 Position { get { return position; } set { position = value; } }

        public Vector2 Velocity
        {
            get { return velocity; }
            set
            {
                velocity.X = MathHelper.Clamp(value.X, -terminalVelocity.X, terminalVelocity.X);
                velocity.Y = MathHelper.Clamp(value.Y, -terminalVelocity.Y, terminalVelocity.Y);
            }
        }

        protected float AccelerationSnap
        {
            get { return (velocity.X * acceleration.X < 0 ? accelerationSnap : 1.0f); }
        }

        public Vector2 Acceleration
        {
            get { return acceleration * AccelerationSnap; }
            set { acceleration = value; }
        }

        public StarPlayer Star { get { return starLink; } }
        public $safeprojectname$ Game { get { return game; } }
        public IPlayerState State { get { return state; } set { state = value; } }
        public List<IWeapon> Weapons { get { return weapons; } set { weapons = value; } }
        public Vector2 TerminalVelocity { get { return terminalVelocity; } set { terminalVelocity = value; } }
        public int Lives { get { return lives; } set { lives = value; } }
        public int Coins { get { return coins; } set { coins = value; } }
        public int Points { get { return points; } set { points = value; } }
        public int JumpBonus { get { return jumpBonus; } set { jumpBonus = value; } }
        public bool Jumping { get { return jumping; } set { jumping = value; } }
        public bool Crouching { get { return crouching; } set { crouching = value; } }
        public bool Invincible { get { return invincible; } set { invincible = value; } }
        public bool Auto { get { return auto; } set { auto = value; } }
        public bool Frozen { get { return frozen; } set { frozen = value; } }

        public void Reset()
        {
            state = new RightIdleGreenLinkState(this);
            velocity = Vector2.Zero;
            starLink = new StarPlayer(this);
            auto = false;
        }

        public void TransitionRight()
        {
            state.TransitionRight();
        }

        public void TransitionLeft()
        {
            state.TransitionLeft();
        }

        public void Jump()
        {
            state.Jump();
        }

        public void Crouch()
        {
            state.Crouch();
        }

        public void Land()
        {
            state.Land();
            jumpBonus = 0;
        }

        public void Idle()
        {
            state.Idle();
        }

        public void GetFireFlower()
        {
            state.GetFireFlower();
        }

        public void GetMushroom()
        {
            state.GetMushroom();
        }

        public void GetStar()
        {
            SoundFactory.Instance.CreateLinkPowerupSound().Play();
            starLink.Activate();
        }

        public void TakeDamage()
        {
            state.TakeDamage();
        }

        public void UseWeapon()
        {
            state.UseWeapon();
        }

        public void Kill()
        {
            state.Kill();
        }

        public void TouchFlagpole()
        {
            Location = new Point(Location.X + 6, Location.Y);
            state.TouchFlagpole();
        }

        public void TouchAxe()
        {
            state.TouchAxe();
            game.state.TouchAxe();
        }


        public void CheckInvincibility()
        {
            if (invincible == true)
            {
                currentFrame++;
                if (currentFrame == 90)
                {
                    invincible = false;
                    currentFrame = 0;
                }
            }
        }

        public Rectangle CollisionRectangle { get { return state.CollisionRectangle; } }
        public Point StartOffset { get { return state.StartOffset; } }

        public void Update(GameTime gametime)
        {
            if (!frozen) {
                state.Update(gametime);
                starLink.Update(gametime);
                sword.Update(gametime);
                CheckInvincibility();
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            if (!(invincible & (currentFrame % 2) == 0))
                state.Draw(gametime, batch);
            starLink.Draw(gametime, batch);
        }
    }
}