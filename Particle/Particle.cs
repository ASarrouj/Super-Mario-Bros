using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public struct Particle
    {
        public readonly Vector2 position;
        public readonly Vector2 velocity;
        public readonly Vector2 acceleration;
        public readonly float   life;
        public readonly Color   color;

        public Particle(Vector2 position,
            Vector2 velocity,
            Vector2 acceleration,
            float life,
            Color color)
        {
            this.position = position;
            this.velocity = velocity;
            this.acceleration = acceleration;
            this.life = life;
            this.color = color;
        }
    }
}
