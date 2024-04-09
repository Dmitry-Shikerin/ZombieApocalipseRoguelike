using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.PresentationsInterfaces.Views.Enemies.Bosses
{
    public interface IBossEnemyAnimation : IEnemyAnimation
    {
        void PlayRage();
        void PlayRun();
    }
}