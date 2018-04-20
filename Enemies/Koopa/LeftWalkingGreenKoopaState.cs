﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    class LeftWalkingGreenKoopaState : KoopaState, IEnemyState
    {
        private AnimatedSprite sprite;

        public LeftWalkingGreenKoopaState(Koopa koopa) : base(koopa, new Point(0x10, 0x18))
        {
            this.sprite = EnemySpriteFactory.Instance.CreateLeftWalkingGreenKoopa();
            koopa.Velocity = new Vector2(-50.0f, koopa.Velocity.Y);
        }

        public bool IsFlipped { get { return false; } }

        public bool IsShell { get { return false; } }

        public bool Dead {  get { return false; } }

        public bool Gravity { get { return true; } }

        public bool FacingLeft { get { return true; } }

        public void BeStomped()
        {
            koopa.State = new StaticGreenKoopaShellState(koopa);
        }

        public void BeFlipped()
        {
            koopa.State = new FlippedGreenKoopaState(koopa);
        }

        public void ChangeDirection()
        {
            koopa.State = new RightWalkingGreenKoopaState(koopa);
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
