using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace $safeprojectname$
{
    public class StarPlayer
    {
        protected const int starDuration = 10;

        protected TimeSpan timer;

        protected IParticleSystem   particles;

        protected IParticleEmitter  emitter;

        protected IPlayer player;

        public StarPlayer(IPlayer player)
        {
            this.player = player;
            timer = TimeSpan.Zero;
            particles = new StaticParticleSystem(SmallMarioSpriteFactory.Instance.CreateSparkle());
            emitter = new PlayerStarEmitter(particles, this.player, false);
        }

        public bool Active { get { return timer >= TimeSpan.Zero; } }

        public void Activate()
        {
            timer = new TimeSpan(0, 0, starDuration);
        }

        public void Update(GameTime gametime)
        {
            particles.Update(gametime);

            timer = timer.Subtract(gametime.ElapsedGameTime);

            emitter.Running = Active;
            emitter.Update(gametime);           
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            particles.Draw(gametime, batch);
        }
    }
}
