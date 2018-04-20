using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public class Axe : IGameObject, ICollidable
    {
        private Point position;
        private AnimatedSprite sprite;
        private Point collisionSize;

        public Rectangle CollisionRectangle { get { return new Rectangle(position, collisionSize); } }

        public Axe(Point position)
        {
            this.position = position;
            sprite = EndObjectSpriteFactory.Instance.CreateAxe();
            sprite.AnimationPlayer.Play();
            collisionSize = new Point(0x10, 0x10);
        }

        public void Drop()
        {
            collisionSize = Point.Zero;
        }

        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {
            sprite.Draw(batch, position);
        }
    }
}
