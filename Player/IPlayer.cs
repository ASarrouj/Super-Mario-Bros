using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace $safeprojectname$
{
    public interface IPlayer : IGameObject, ICollidable, IPhysicsObject
    {
        int Lives { get; set; }
        int Coins { get; set; }
        int Points { get; set; }
        int JumpBonus { get; set; }
        bool Jumping { get; set; }
        bool Crouching { get; set; }
        bool Invincible { get; set; }
        bool Frozen { get; set; }
        bool Auto { get; set; }
        Point Location { get; set; }
        Point StartOffset { get;}
        Vector2 TerminalVelocity { get; set; }
        StarPlayer Star { get; }
        $safeprojectname$ Game { get; }
        IPlayerState State { get; set; }
        List<IWeapon> Weapons { get; set; }

        void Reset();
        void TransitionRight();
        void TransitionLeft();
        void Jump();  
        void Crouch();
        void Land();
        void Idle();
        void GetFireFlower();
        void GetMushroom();
        void GetStar();
        void TakeDamage();
        void UseWeapon();
        void Kill();
        void TouchFlagpole();
        void TouchAxe();
    }
}
