﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class RightWalkingRedKoopaState : KoopaState, IEnemyState
    {
        private AnimatedSprite sprite;

        public RightWalkingRedKoopaState(Koopa koopa) : base(koopa, new Point(0x10, 0x18))
        {
            this.sprite = EnemySpriteFactory.Instance.CreateRightWalkingRedKoopa();
            koopa.Velocity = new Vector2(50.0f, koopa.Velocity.Y);
        }

        public bool IsFlipped { get { return false; } }

        public bool IsShell { get { return false; } }

        public bool Dead {  get { return false; } }

        public bool Gravity { get { return true; } }

        public bool FacingLeft { get { return false; } }

        public void BeStomped()
        {
            koopa.State = new StaticRedKoopaShellState(koopa);
        }

        public void BeFlipped()
        {
            koopa.State = new FlippedRedKoopaState(koopa);
        }

        public void ChangeDirection()
        {
            koopa.State = new LeftWalkingRedKoopaState(koopa);
        }

        public void Bounce()
        {
        }

        public void FollowPlayer(IPlayer player) { }

        public void Update(GameTime gameTime )
        {
            sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, koopa.Location);
        }

    }
}
