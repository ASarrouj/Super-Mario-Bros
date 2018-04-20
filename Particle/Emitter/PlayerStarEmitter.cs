
using Microsoft.Xna.Framework;
using System;

namespace $safeprojectname$
{
    class PlayerStarEmitter : SimpleEmmiter, IParticleEmitter
    {
        protected IPlayer player;

        protected float timer;

        protected Random random;

        protected const float particleLife = 1.5f;

        protected const float particlesPerSecond = 30;

        protected const float secondPerParticle = 1.0f / particlesPerSecond;

        protected Color[] colors = new Color[4];

        protected const float speed = -2.0f;

        protected const float acceleration = -50.0f;

        protected int colorIndex = 0;

        public PlayerStarEmitter(IParticleSystem system, IPlayer player, bool running = true) : base(system, running)
        {
            this.player = player;
            this.random = new Random();

            colors[0] = Color.White;
            colors[1] = Color.LightYellow;
            colors[2] = Color.Cyan;
            colors[3] = Color.LightPink;
        }

        protected Vector2 CalcParticleVelocity()
        {
            // Maybe use this ?
            //const double pi_3 = Math.PI / 3.0;
            //double randAngle = pi_3 + random.NextDouble() * pi_3;
            //Vector2 direction = new Vector2((float)Math.Cos(randAngle), -(float)Math.Sin(randAngle));
            //return speed * direction;

            return new Vector2(0, -speed);
        }

        protected Vector2 CalcParticlePosition()
        {
            float x = player.CollisionRectangle.X + (random.Next() % Math.Max(player.CollisionRectangle.Width, 16));
            float y = player.CollisionRectangle.Y + (random.Next() % Math.Max(player.CollisionRectangle.Height, 16));
            return new Vector2(x, y);
        }

        protected void AddParticle()
        {
            Particle p = new Particle(
                CalcParticlePosition(),
                CalcParticleVelocity(),
                new Vector2(0, acceleration),
                particleLife,
                colors[colorIndex]);

            system.AddParticle(p);

            colorIndex = (colorIndex + 1) % colors.Length;
            timer -= secondPerParticle;
        }


        public void Update(GameTime gameTime)
        {
            if (!Running)
                return;

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while(timer > secondPerParticle)
            {
                AddParticle();
            }       
        }
    }
}
