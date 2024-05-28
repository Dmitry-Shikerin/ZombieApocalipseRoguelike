using System;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Enemies;
using Sources.Domain.Models.Enemies.Base;
using Sources.Domain.Models.Gameplay;
using Sources.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

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

        public IEnemyView Spawn(KillEnemyCounter killEnemyCounter, Vector3 position)
        {
            Enemy enemy = new Enemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.Damage));
            
            IEnemyView enemyView = SpawnFromPool(enemy, killEnemyCounter) ?? 
                                   _enemyViewFactory.Create(enemy, killEnemyCounter);
            
            enemyView.DisableNavmeshAgent();
            enemyView.SetPosition(position);
            enemyView.EnableNavmeshAgent();
            enemyView.Show();
            
            return enemyView;
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