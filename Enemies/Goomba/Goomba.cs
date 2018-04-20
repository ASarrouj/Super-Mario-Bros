using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public class Goomba : IEnemy
    {
        private Vector2 textPos;
        private float textTimer;
        private SpriteFont font;
        private string text;
        private List<IProjectile> projectiles;

        public IEnemyState State { get; set; }

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
        public Vector2 Acceleration
        {
            get { return Vector2.Zero; }
            set { }
        }

        public bool IsFlipped { get { return State.IsFlipped; } }

        public bool IsShell { get { return false; } }

        public bool Dead {
            get { return State.Dead; }
        }

        public Rectangle CollisionRectangle {
            get { return State.CollisionRectangle; }
        }

        public Goomba(Point position)
        {
            Location = position;
            font = SpriteFontFactory.Instance.CreatePointsFont();
            State = new LeftMovingGoombaState(this);
            projectiles = new List<IProjectile>();
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Bounce()
        {
        }

        public void BeStomped(string points)
        {
            State.BeStomped();
            text = points;
            textTimer = 1.0f;
            textPos = Position;
            textPos.Y -= 0x16;
        }

        public void BeFlipped(string points)
        {
            State.BeFlipped();
            text = points;
            textTimer = 1.0f;
            textPos = Position;
            textPos.Y -= 0x16;
        }

        public bool IsFlying()
        {
            return false;
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
