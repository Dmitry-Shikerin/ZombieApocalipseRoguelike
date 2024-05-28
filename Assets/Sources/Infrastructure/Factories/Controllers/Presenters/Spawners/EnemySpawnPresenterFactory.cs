using System;
using Sources.Controllers.Presenters.Spawners;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Spawners
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

        public EnemySpawnerPresenter Create(
            EnemySpawner enemySpawner, 
            KillEnemyCounter killEnemyCounter, 
            IEnemySpawnerView enemySpawnerView)
        {
            return new EnemySpawnerPresenter(
                killEnemyCounter,
                enemySpawner,
                enemySpawnerView,
                _enemySpawnService,
                _bossEnemySpawnService);
        }
    }
}