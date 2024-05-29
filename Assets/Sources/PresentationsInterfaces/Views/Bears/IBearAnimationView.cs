using System;

namespace Sources.PresentationsInterfaces.Views.Bears
{
    public interface IBearAnimationView
    {
        event Action Attacking;

        void PlayWalk();

        void PlayIdle();

        void PlayAttack();
    }
}