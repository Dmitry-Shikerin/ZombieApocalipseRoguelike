using Sources.Controllers.Gameplay;
using Sources.Domain.Gameplay;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Spawners;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Gameplay
{
    public class KillEnemyCounterPresenterFactory
    {
        public KillEnemyCounterPresenter Create(
            KillEnemyCounter killEnemyCounter,
            EnemySpawner enemySpawner,
            IKillEnemyCounterView killEnemyCounterView)
        {
            return new KillEnemyCounterPresenter(killEnemyCounter, enemySpawner, killEnemyCounterView);
        }
    }
}