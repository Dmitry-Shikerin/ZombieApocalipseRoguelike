using System;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.PresentationsInterfaces.Views.Enemies.Bosses
{
    public interface IBossEnemyAnimation : IEnemyAnimation
    {
        event Action ScreamAnimationEnded;
        
        void PlayScream();
        void PlayRun();
    }
}