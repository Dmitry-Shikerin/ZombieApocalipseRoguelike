using System;
using Sources.Controllers.Spawners;
using Sources.Domain.Spawners;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;

namespace Sources.Infrastructure.Factories.Controllers.Spawners
{
    public class EnemySpawnPresenterFactory
    {
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly IBossEnemySpawnService _bossEnemySpawnService;

        public EnemySpawnPresenterFactory(
            IEnemySpawnService enemySpawnService,
            IBossEnemySpawnService bossEnemySpawnService)
        {
            _enemySpawnService = enemySpawnService ?? throw new ArgumentNullException(nameof(enemySpawnService));
            _bossEnemySpawnService = bossEnemySpawnService ?? 
                                     throw new ArgumentNullException(nameof(bossEnemySpawnService));
        }

        public EnemySpawnerPresenter Create(EnemySpawner enemySpawner, IEnemySpawnerView enemySpawnerView)
        {
            return new EnemySpawnerPresenter(
                enemySpawner, 
                enemySpawnerView, 
                _enemySpawnService,
                _bossEnemySpawnService);
        }
    }
}