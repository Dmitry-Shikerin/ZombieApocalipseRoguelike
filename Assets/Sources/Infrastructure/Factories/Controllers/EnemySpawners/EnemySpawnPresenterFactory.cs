using System;
using Sources.Controllers.EnemeSpawners;
using Sources.Domain.Spawners;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;

namespace Sources.Infrastructure.Factories.Controllers.EnemySpawners
{
    public class EnemySpawnPresenterFactory
    {
        private readonly IEnemySpawnService _enemySpawnService;

        public EnemySpawnPresenterFactory(IEnemySpawnService enemySpawnService)
        {
            _enemySpawnService = enemySpawnService ?? throw new ArgumentNullException(nameof(enemySpawnService));
        }

        public EnemySpawnerPresenter Create(EnemySpawner enemySpawner, IEnemySpawnerView enemySpawnerView)
        {
            return new EnemySpawnerPresenter(enemySpawner, enemySpawnerView, _enemySpawnService);
        }
    }
}