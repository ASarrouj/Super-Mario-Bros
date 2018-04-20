using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftCrouchingSwordState : IWeaponState
    {
        private Link link;
        private Sword sword;
        private Point position, collizionSize;

        public LeftCrouchingSwordState(Sword sword)
        {
            this.sword = sword;
            link = sword.link;
            position = new Point(link.Location.X-20, link.Location.Y + 14);
            collizionSize = new Point(20, 4);
            SoundFactory.Instance.CreateSwordSlashSound().Play();
        }
        public Rectangle CollisionRectangle
        {
            get { return new Rectangle(position, collizionSize); }
        }

        public void Create()
        {

        }

        public void Delete()
        {
            sword.state = new InactiveSwordState(sword);
        }
        public void CollideWithFloor()
        {

        }

        public void Update(GameTime gametime)
        {
            position = new Point(link.Location.X, link.Location.Y + 14);
        }

        public void Draw(GameTime gametime, SpriteBatch batch)
        {

        }
    }
}