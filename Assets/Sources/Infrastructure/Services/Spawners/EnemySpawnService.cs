using System;
using Sources.Domain.Enemies;
using Sources.Domain.Enemies.Base;
using Sources.Domain.Gameplay;
using Sources.Infrastructure.Factories.Views.Enemies;
using Sources.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Enemies;
using Sources.Presentations.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Infrastructure.Services.Spawners
{
    public class EnemySpawnService : IEnemySpawnService
    {
        private readonly IObjectPool<EnemyView> _enemyPool;
        private readonly IEnemyViewFactory _enemyViewFactory;

        public EnemySpawnService(IObjectPool<EnemyView> enemyPool, IEnemyViewFactory enemyViewFactory)
        {
            _enemyPool = enemyPool ?? throw new ArgumentNullException(nameof(enemyPool));
            _enemyViewFactory = enemyViewFactory ?? throw new ArgumentNullException(nameof(enemyViewFactory));
        }

        public IEnemyView Spawn(KillEnemyCounter killEnemyCounter)
        {
            Enemy enemy = new Enemy(new EnemyHealth(50), new EnemyAttacker(5));
            
            return SpawnFromPool(enemy, killEnemyCounter) ?? _enemyViewFactory.Create(enemy, killEnemyCounter);
        }

        private IEnemyView SpawnFromPool(Enemy enemy, KillEnemyCounter killEnemyCounter)
        {
            EnemyView enemyView = _enemyPool.Get<EnemyView>();

            if (enemyView == null)
                return null;
            
            return _enemyViewFactory.Create(enemy, killEnemyCounter, enemyView);
        }
    }
}