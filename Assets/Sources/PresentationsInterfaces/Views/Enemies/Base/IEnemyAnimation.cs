using System;

namespace Sources.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyAnimation
    {
        event Action Attacking;
        
        void PlayWalk();
        void PlayIdle();
        // void PlayDie();
        void PlayAttack();
    }
}