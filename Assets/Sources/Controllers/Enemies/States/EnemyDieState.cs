using System;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Controllers.Enemies.States
{
    public class EnemyDieState : FiniteState
    {
        private readonly IEnemyView _enemyView;
        private readonly IExplosionBodyBloodySpawnService _explosionBodyBloodySpawnService;

        public EnemyDieState(IEnemyView enemyView,IExplosionBodyBloodySpawnService explosionBodyBloodySpawnService)
        {
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _explosionBodyBloodySpawnService = explosionBodyBloodySpawnService ?? 
                                          throw new ArgumentNullException(nameof(explosionBodyBloodySpawnService));
        }

        public override void Enter()
        {
            Vector3 spawnPosition = _enemyView.Position;
            spawnPosition.y += 1f;
            
            _explosionBodyBloodySpawnService.Spawn(spawnPosition);
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