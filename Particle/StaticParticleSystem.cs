using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public class StaticParticleSystem : IParticleSystem
    {
        protected LinkedList<Particle> particles;

        protected StaticSprite sprite;

        protected int maxCount;

        public StaticParticleSystem(StaticSprite sprite, int maxCount = 64)
        {
            this.sprite = sprite;
            this.particles = new LinkedList<Particle>();
            this.maxCount = maxCount;
        }

        public void AddParticle(Particle particle)
        {
            if(particles.Count == maxCount){
                particles.RemoveLast();
            }
            particles.AddFirst(particle);
        }

        public void Update(GameTime gametime)
        {
            for(LinkedListNode<Particle> node = particles.First; node != null; node = node.Next)
            {
                Particle p = new Particle(
                node.Value.position + node.Value.velocity * (float)gametime.ElapsedGameTime.TotalSeconds,
                node.Value.velocity + node.Value.acceleration * (float)gametime.ElapsedGameTime.TotalSeconds,
                node.Value.acceleration,
                node.Value.life - (float)gametime.ElapsedGameTime.TotalSeconds,
                node.Value.color);

                node.Value = p;
            }
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            for (LinkedListNode<Particle> node = particles.First; node != null; node = node.Next)
            {
                if (node.Value.life < 0.0f)
                    return;

                sprite.Draw(batch, node.Value.position.ToPoint(), node.Value.color);
            }
        }
    }
}
