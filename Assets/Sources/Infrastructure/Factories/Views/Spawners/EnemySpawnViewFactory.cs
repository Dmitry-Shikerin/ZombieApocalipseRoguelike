using System;
using Sources.Controllers.Presenters.Spawners;
using Sources.Controllers.Spawners;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.Infrastructure.Factories.Controllers.Spawners;
using Sources.Presentations.Views.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;

namespace Sources.Infrastructure.Factories.Views.Spawners
{
    public class EnemySpawnViewFactory
    {
        private readonly EnemySpawnPresenterFactory _enemySpawnPresenterFactory;

        public EnemySpawnViewFactory(EnemySpawnPresenterFactory enemySpawnPresenterFactory)
        {
            _enemySpawnPresenterFactory = enemySpawnPresenterFactory ?? 
                                          throw new ArgumentNullException(nameof(enemySpawnPresenterFactory));
        }

        public IEnemySpawnerView Create(
            EnemySpawner enemySpawner, 
            KillEnemyCounter killEnemyCounter, 
            EnemySpawnerView enemySpawnerView)
        {
            EnemySpawnerPresenter enemySpawnerPresenter =
                _enemySpawnPresenterFactory.Create(enemySpawner,killEnemyCounter, enemySpawnerView);
            
            enemySpawnerView.Construct(enemySpawnerPresenter);
            
            return enemySpawnerView;
        }
    }
}