using System;
using Sources.Domain.Models.Gameplay;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Controllers.Enemies.Base.States
{
    public class EnemyDieState : FiniteState
    {
        private readonly KillEnemyCounter _killEnemyCounter;
        private readonly IEnemyView _enemyView;
        private readonly IExplosionBodyBloodySpawnService _explosionBodyBloodySpawnService;
        private readonly IRewardItemSpawnService _rewardItemSpawnService;
        private readonly IEnemyCollectorService _enemyCollectorService;

        public EnemyDieState(
            KillEnemyCounter killEnemyCounter,
            IEnemyView enemyView, 
            IExplosionBodyBloodySpawnService explosionBodyBloodySpawnService,
            IRewardItemSpawnService rewardItemSpawnService,
            IEnemyCollectorService enemyCollectorService)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _explosionBodyBloodySpawnService = explosionBodyBloodySpawnService ?? 
                                          throw new ArgumentNullException(nameof(explosionBodyBloodySpawnService));
            _rewardItemSpawnService = rewardItemSpawnService ?? 
                                      throw new ArgumentNullException(nameof(rewardItemSpawnService));
            _enemyCollectorService = enemyCollectorService ?? throw new ArgumentNullException(nameof(enemyCollectorService));
        }

        public override void Enter()
        {
            Vector3 spawnPosition = _enemyView.Position;
            spawnPosition.y += 1f;
            
            _killEnemyCounter.IncreaseKillCount();
            _explosionBodyBloodySpawnService.Spawn(spawnPosition);
            _rewardItemSpawnService.Spawn(_enemyView.Position, 3);
            _enemyCollectorService.Remove(_enemyView);
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