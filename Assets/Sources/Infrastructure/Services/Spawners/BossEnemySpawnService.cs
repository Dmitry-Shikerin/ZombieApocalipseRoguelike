using System;
using Sources.Domain.Enemies;
using Sources.Domain.Enemies.Bosses;
using Sources.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Infrastructure.Services.Spawners
{
    public class BossEnemySpawnService : IBossEnemySpawnService
    {
        private readonly IObjectPool<BossEnemyView> _bossEnemyPool;
        private readonly IBossEnemyViewFactory _bossEnemyViewFactory;

        public BossEnemySpawnService(
            IObjectPool<BossEnemyView> bossEnemyPool, 
            IBossEnemyViewFactory bossEnemyViewFactory)
        {
            _bossEnemyPool = bossEnemyPool ?? throw new ArgumentNullException(nameof(bossEnemyPool));
            _bossEnemyViewFactory = bossEnemyViewFactory 
                                    ?? throw new ArgumentNullException(nameof(bossEnemyViewFactory));
        }

        public IBossEnemyView Spawn(Vector3 position)
        {
            BossEnemy bossEnemy = new BossEnemy(
                new EnemyHealth(200), 
                new EnemyAttacker(10), 
                2f, 
                2f, 
                5f);
            IBossEnemyView bossEnemyView = SpawnFromPool(bossEnemy) ?? _bossEnemyViewFactory.Create(bossEnemy);
            bossEnemyView.SetPosition(position);

            return bossEnemyView;
        }
        
        private IBossEnemyView SpawnFromPool(BossEnemy bossEnemy)
        {
            BossEnemyView enemyView = _bossEnemyPool.Get<BossEnemyView>();

            if (enemyView == null)
                return null;
            
            return _bossEnemyViewFactory.Create(bossEnemy, enemyView);
        }
    }
}