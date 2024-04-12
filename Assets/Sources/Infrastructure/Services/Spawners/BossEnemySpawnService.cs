using System;
using Sources.Domain.Enemies;
using Sources.Domain.Enemies.Bosses;
using Sources.Domain.Gameplay;
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

        public IBossEnemyView Spawn(KillEnemyCounter killEnemyCounter, Vector3 position)
        {
            BossEnemy bossEnemy = new BossEnemy(
                new EnemyHealth(200), 
                new EnemyAttacker(10), 
                2f, 
                2f, 
                5f);
            IBossEnemyView bossEnemyView = SpawnFromPool(bossEnemy, killEnemyCounter) ?? 
                                           _bossEnemyViewFactory.Create(bossEnemy, killEnemyCounter);
            bossEnemyView.SetPosition(position);

            return bossEnemyView;
        }
        
        private IBossEnemyView SpawnFromPool(BossEnemy bossEnemy, KillEnemyCounter killEnemyCounter)
        {
            BossEnemyView enemyView = _bossEnemyPool.Get<BossEnemyView>();

            if (enemyView == null)
                return null;
            
            return _bossEnemyViewFactory.Create(bossEnemy, killEnemyCounter, enemyView);
        }
    }
}