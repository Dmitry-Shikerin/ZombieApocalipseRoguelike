using System;
using Sources.Controllers.Presenters.Spawners;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.Spawners;
using Sources.Utils.CustomCollections;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Spawners
{
    public class EnemySpawnPresenterFactory
    {
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly IBossEnemySpawnService _bossEnemySpawnService;
        private readonly ICustomList<IEnemyView> _enemyCollection;
        private readonly IDomainFormService _domainFormService;

        public EnemySpawnPresenterFactory(
            IEnemySpawnService enemySpawnService,
            IBossEnemySpawnService bossEnemySpawnService,
            ICustomList<IEnemyView> enemyCollection)
        {
            _enemySpawnService = enemySpawnService ?? throw new ArgumentNullException(nameof(enemySpawnService));
            _bossEnemySpawnService = bossEnemySpawnService ?? 
                                     throw new ArgumentNullException(nameof(bossEnemySpawnService));
            _enemyCollection = enemyCollection ??
                                     throw new ArgumentNullException(nameof(enemyCollection));
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
                _enemyCollection);
        }
    }
}