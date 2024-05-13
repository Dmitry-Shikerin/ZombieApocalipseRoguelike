using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.PresentationsInterfaces.Views.Enemies.Bosses
{
    public interface IBossEnemyView : IEnemyView
    {
        void PlayMassAttackParticle();
        void SetAgentSpeed(float speed);
    }
}