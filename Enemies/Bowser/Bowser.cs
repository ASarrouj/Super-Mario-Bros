using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public class Bowser : IEnemy
    {
        private Random rand;
        private double fireTimer;
        private List<IProjectile> projectiles;

        public List<IProjectile> Projectiles { get { return projectiles; } }

        public IEnemyState State { get; set; }

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

        public Bowser(Point position)
        {
            Location = position;
            State = new StandingStillBowserState(this);
            rand = new Random();
            projectiles = new List<IProjectile>();
            for (int i = 0; i < 2; i++) projectiles.Add(new BowserFireball(this));
            fireTimer = 0.00;
        }

        public void BeStomped(string points)
        {
        }

        public void BeFlipped(string points)
        {
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Bounce()
        {
            if (rand.NextDouble() < 0.04) {
                Velocity = new Vector2(Velocity.X, -175.0f);
            }
        }

        public bool IsFlying()
        {
            return false;
        }

        public void FollowPlayer(IPlayer player)
        {
            State.FollowPlayer(player);
        }

        public void Stop()
        {
            State = new StandingStillBowserState(this);
        }

        public void Shoot()
        {
            if (fireTimer <= 0) {
                foreach (BowserFireball f in projectiles) {
                    if (f.State is InactiveBowserFireballState)
                    {
                        f.Create();
                        fireTimer = 0.5 + rand.NextDouble();
                        break;
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            fireTimer -= gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            State.Draw(gameTime, batch);
        }
    }
}
