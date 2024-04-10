using System;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Controllers.Enemies.Base.States
{
    public class EnemyDieState : FiniteState
    {
        private readonly IEnemyView _enemyView;
        private readonly IExplosionBodyBloodySpawnService _explosionBodyBloodySpawnService;
        private readonly IRewardItemSpawnService _rewardItemSpawnService;

        public EnemyDieState(
            IEnemyView enemyView, 
            IExplosionBodyBloodySpawnService explosionBodyBloodySpawnService,
            IRewardItemSpawnService rewardItemSpawnService)
        {
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _explosionBodyBloodySpawnService = explosionBodyBloodySpawnService ?? 
                                          throw new ArgumentNullException(nameof(explosionBodyBloodySpawnService));
            _rewardItemSpawnService = rewardItemSpawnService ?? 
                                      throw new ArgumentNullException(nameof(rewardItemSpawnService));
        }

        public override void Enter()
        {
            Vector3 spawnPosition = _enemyView.Position;
            spawnPosition.y += 1f;
            
            _explosionBodyBloodySpawnService.Spawn(spawnPosition);
            _rewardItemSpawnService.Spawn(_enemyView.Position, 3);
            _enemyView.Destroy();
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
        }
    }
}