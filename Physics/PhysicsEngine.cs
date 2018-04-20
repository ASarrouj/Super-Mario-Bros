using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public class PhysicsEngine
    {
        public Vector2 Gravity { get; private set; }

        public PhysicsEngine()
        {
            Gravity = new Vector2(0, ConstantValues.PLAYER_ACCELERATION);
        }

        public void Update(GameTime gameTime, IPhysicsObject physicsObject)
        {
            float deltaT = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 acceleration = physicsObject.Acceleration + Gravity;

            physicsObject.Position += deltaT * physicsObject.Velocity;
            physicsObject.Velocity += deltaT * acceleration;
        }

    }
}
