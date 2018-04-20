using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public abstract class Item : IGameObject, ICollidable, IPhysicsObject
    {
        protected bool visible, boxed;

        public abstract void Unbox(IPlayer player);

        public bool Boxed { get { return boxed; } set { boxed = value; } }

        public bool Gravity { get; set; }

        public IItemState State { get; set; }

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

        public Rectangle CollisionRectangle {
            get { if (visible) return new Rectangle(Location.X, Location.Y, 0x10, 0x10);
                else return new Rectangle(Location.X, Location.Y, 0x0, 0x0);
            }
        }

        public bool IsVisible()
        {
            return visible;
        }

        public void BeConsumed(IPlayer player)
        {
            visible = false;
            State.BeConsumed(player);
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            State.Draw(gameTime, spriteBatch);
        }
    }
}
