using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public interface IEnemyState : ICollidable
    {
        void ChangeDirection();

        void BeStomped();

        void BeFlipped();

        void Bounce();

        bool IsFlipped { get; }

        bool IsShell { get; }

        bool Dead { get; }

        bool Gravity { get; }

        bool FacingLeft { get; }

        void FollowPlayer(IPlayer player);

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
