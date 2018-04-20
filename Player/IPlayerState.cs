using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace $safeprojectname$
{
    public interface IPlayerState : ICollidable, IGameObject
    {
        Point StartOffset { get; }
        void TransitionRight();
        void TransitionLeft();
        void Jump();
        void Crouch();
        void Idle();
        void Land();
        void GetFireFlower();
        void GetMushroom();
        void TakeDamage();
        void UseWeapon();
        void TouchFlagpole();
        void TouchAxe();
        void Kill();
    }
}