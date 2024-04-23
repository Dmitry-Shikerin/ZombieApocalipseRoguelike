using System;
using Sources.Controllers.Spawners;
using Sources.Domain.Gameplay;
using Sources.Domain.Spawners;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;

namespace Sources.Infrastructure.Factories.Controllers.Spawners
{
    public class EnemySpawnPresenterFactory
    {
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly IBossEnemySpawnService _bossEnemySpawnService;
        private readonly IEnemyCollectorService _enemyCollectorService;
        private readonly IFormService _formService;

        public EnemySpawnPresenterFactory(
            IEnemySpawnService enemySpawnService,
            IBossEnemySpawnService bossEnemySpawnService,
            IEnemyCollectorService enemyCollectorService)
        {
            _enemySpawnService = enemySpawnService ?? throw new ArgumentNullException(nameof(enemySpawnService));
            _bossEnemySpawnService = bossEnemySpawnService ?? 
                                     throw new ArgumentNullException(nameof(bossEnemySpawnService));
            _enemyCollectorService = enemyCollectorService ??
                                     throw new ArgumentNullException(nameof(enemyCollectorService));
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
                _bossEnemySpawnService,
                _enemyCollectorService);
        }
    }
}