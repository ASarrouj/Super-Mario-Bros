using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class SpinnyFireball : IHazard
    {
        private AnimatedSprite sprite;

        private float angle;

        private float angularVelocity;

        private float distance;

        protected Point center;

        protected Vector2 Direction { get { return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)); } }
      
        protected Point Location { get { return center + (distance * Direction).ToPoint(); } }

        public Rectangle CollisionRectangle { get { return new Rectangle(Location, ConstantValues.FIREBALL_SIZE); } }

        public bool InstantDeath {  get { return false; } }
        
        public SpinnyFireball(Point center, float distance, float angle, float angularVelocity)
        {
            this.sprite = FireballSpriteFactory.Instance.CreateActiveFireball();
            this.center = center;
            this.distance = distance;
            this.angle = angle;
            this.angularVelocity = angularVelocity;
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, Location);
        }

        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
            angle = MathHelper.WrapAngle(angle + (float)gametime.ElapsedGameTime.TotalSeconds * this.angularVelocity);
        }
    }
}
