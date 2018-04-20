using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public interface IParticleEmitter
    {
        bool Running { get; set; }

        void Update(GameTime gameTime);
    }
}
