using System;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Gameplay;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;
using UnityEngine;

namespace Sources.Controllers.Presenters.Enemies.Base.States
{
    public class EnemyDieState : FiniteState
    {
        private readonly KillEnemyCounter _killEnemyCounter;
        private readonly IEnemyView _enemyView;
        private readonly IExplosionBodyBloodySpawnService _explosionBodyBloodySpawnService;
        private readonly IRewardItemSpawnService _rewardItemSpawnService;
        private readonly CustomCollection<IEnemyView> _enemyCollection;

        public EnemyDieState(
            KillEnemyCounter killEnemyCounter,
            IEnemyView enemyView,
            IExplosionBodyBloodySpawnService explosionBodyBloodySpawnService,
            IRewardItemSpawnService rewardItemSpawnService,
            CustomCollection<IEnemyView> enemyCollection)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _explosionBodyBloodySpawnService = explosionBodyBloodySpawnService ??
                                          throw new ArgumentNullException(nameof(explosionBodyBloodySpawnService));
            _rewardItemSpawnService = rewardItemSpawnService ??
                                      throw new ArgumentNullException(nameof(rewardItemSpawnService));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
        }

        public override void Enter()
        {
            if (_enemyView == null)
                return;

            Vector3 spawnPosition = _enemyView.Position;
            spawnPosition.y += 1f;

            _killEnemyCounter.IncreaseKillCount();
            _explosionBodyBloodySpawnService.Spawn(spawnPosition);
            _rewardItemSpawnService.Spawn(_enemyView.Position, RewardItemConst.Amount);
            _enemyCollection.Remove(_enemyView);
            _enemyView.Destroy();
        }
    }
}