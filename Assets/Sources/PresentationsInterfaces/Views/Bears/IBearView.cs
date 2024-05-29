using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.NawMeshAgents;

namespace Sources.PresentationsInterfaces.Views.Bears
{
    public interface IBearView : INavMeshAgent, ICharacterFollower
    {
        IEnemyHealthView TargetEnemyHealth { get; }

        void SetTarget(IEnemyHealthView enemyHealthView);

        void SetLookRotation(float angle);
    }
}