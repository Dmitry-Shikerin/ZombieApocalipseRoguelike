using System;

namespace Sources.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyAnimation
    {
        event Action Attacking;
        
        void PlayWalk();
        void PlayIdle();
        void PlayDie();
        void PlayAttack();
    }
}