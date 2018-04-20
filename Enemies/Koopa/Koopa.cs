using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace $safeprojectname$
{
    public class Koopa : IEnemy
    {
        private Vector2 textPos;
        private float textTimer;
        private SpriteFont font;
        private string text;
        private List<IProjectile> projectiles;

        public IEnemyState State { get; set;}

        public List<IProjectile> Projectiles { get { return projectiles; } }

        public Point Location {
            get { return position.ToPoint(); }
            set { position = new Vector2(value.X, value.Y); }
        }

        protected Vector2 position;

        public Vector2 Position {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration {
            get { return Vector2.Zero; }
            set { }
        }

        public bool IsFlipped { get { return State.IsFlipped; } }

        public bool IsShell { get { return State.IsShell; } }

        public bool Dead {
            get { return State.Dead; }
        }

        public Rectangle CollisionRectangle {
            get { return State.CollisionRectangle; }
        }

        protected Koopa(Point position)
        {
            Location = position;
            font = SpriteFontFactory.Instance.CreatePointsFont();
            projectiles = new List<IProjectile>();
        }

        public void BeStomped(string points)
        {
            State.BeStomped();
            text = points;
            textTimer = 1.0f;
            textPos = Position;
            textPos.Y -= 0x20;
        }

        public void BeFlipped(string points)
        {
            State.BeFlipped();
            text = points;
            textTimer = 1.0f;
            textPos = Position;
            textPos.Y -= 0x20;
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Bounce()
        {
            State.Bounce();
        }

        public bool IsFlying()
        {
            return State is LeftFlyingKoopaState || State is RightFlyingKoopaState;
        }

        public static Koopa CreateWalkingGreenKoopa(Point position)
        {
            Koopa koopa = new Koopa(position);
            koopa.State = new LeftWalkingGreenKoopaState(koopa);
            return koopa;
        }

        public static Koopa CreateWalkingRedKoopa(Point position)
        {
            Koopa koopa = new Koopa(position);
            koopa.State = new LeftWalkingRedKoopaState(koopa);
            return koopa;
        }

        public static Koopa CreateBouncingParakoopa(Point position)
        {
            Koopa koopa = new Koopa(position);
            koopa.State = new LeftBouncingKoopaState(koopa);
            return koopa;
        }

        public static Koopa CreateVerticalParakoopa(Point position)
        {
            Koopa koopa = new Koopa(position);
            koopa.State = new VerticalFlyingKoopaState(koopa);
            return koopa;
        }

        public static Koopa CreateHorizontalParakoopa(Point position)
        {
            Koopa koopa = new Koopa(position);
            koopa.State = new LeftFlyingKoopaState(koopa);
            return koopa;
        }

        public void FollowPlayer(IPlayer player)
        {
        }

        public void Shoot()
        {
        }


        public void Stop()
        {
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            State.Draw(gameTime, batch);
            if (textTimer > 0.0f)
            {
                batch.DrawString(font, text, textPos, ConstantValues.HUD_COLOR);
                textTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
