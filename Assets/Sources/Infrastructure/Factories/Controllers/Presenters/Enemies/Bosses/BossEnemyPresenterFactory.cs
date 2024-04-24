using System;
using JetBrains.Annotations;
using Sources.Controllers.Enemies.Base;
using Sources.Controllers.Enemies.Base.States;
using Sources.Controllers.Enemies.Bosses.States;
using Sources.Domain.Models.Enemies.Bosses;
using Sources.Domain.Models.Gameplay;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.Enemies.Bosses
{
    public class BossEnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly IExplosionBodyBloodySpawnService _explosionBodyBloodySpawnService;
        private readonly IRewardItemSpawnService _rewardItemSpawnService;
        private readonly OverlapService _overlapService;
        private readonly IEnemyCollectorService _enemyCollectorService;

        public BossEnemyPresenterFactory(
            IUpdateRegister updateRegister,
            IExplosionBodyBloodySpawnService explosionBodyBloodySpawnService,
            IRewardItemSpawnService rewardItemSpawnService,
            OverlapService overlapService,
            IEnemyCollectorService enemyCollectorService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _explosionBodyBloodySpawnService = explosionBodyBloodySpawnService ?? 
                                               throw new ArgumentNullException(nameof(explosionBodyBloodySpawnService));
            _rewardItemSpawnService = rewardItemSpawnService ?? 
                                      throw new ArgumentNullException(nameof(rewardItemSpawnService));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
            _enemyCollectorService = enemyCollectorService ?? throw new ArgumentNullException(nameof(enemyCollectorService));
        }

        public EnemyPresenter Create(
            BossEnemy bossEnemy,
            KillEnemyCounter killEnemyCounter,
            IBossEnemyView bossEnemyView,
            IBossEnemyAnimation bossEnemyAnimation)
        {
            EnemyIdleState idleState = new EnemyIdleState(bossEnemy, bossEnemyAnimation);
            EnemyInitializeState initializeState = new EnemyInitializeState(
                bossEnemy, bossEnemyAnimation, bossEnemyView, _enemyCollectorService);
            // BossEnemyMoveToPlayerState bossEnemyMoveToPlayerState = new BossEnemyMoveToPlayerState(
            //     bossEnemy, bossEnemyView, bossEnemyAnimation);
            BossEnemyMoveToPlayerState moveToPlayerState = new BossEnemyMoveToPlayerState(
                bossEnemy, bossEnemyView, bossEnemyAnimation, _overlapService);
            BossEnemyAttackState attackState = new BossEnemyAttackState(
                bossEnemy, bossEnemyView, bossEnemyAnimation, _overlapService);
            EnemyDieState dieState = new EnemyDieState(
                killEnemyCounter, 
                bossEnemyView, 
                _explosionBodyBloodySpawnService, 
                _rewardItemSpawnService,
                _enemyCollectorService);
            EnemyRunState enemyRunState = new EnemyRunState(bossEnemy, bossEnemyView, bossEnemyAnimation);
            
            FiniteTransition toMoveToPlayerTransition = new FiniteTransitionBase(
                moveToPlayerState,
                () =>
                    bossEnemy.IsInitialized &&
                    bossEnemyView.CharacterMovementView != null &&
                    Vector3.Distance(
                        bossEnemyView.Position, 
                        bossEnemyView.CharacterMovementView.Position) > bossEnemyView.StoppingDistance 
                    && bossEnemy.IsRun == false);
            initializeState.AddTransition(toMoveToPlayerTransition);
            attackState.AddTransition(toMoveToPlayerTransition);
            enemyRunState.AddTransition(toMoveToPlayerTransition);
            
            FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
                attackState, () => Vector3.Distance(
                    bossEnemyView.Position, 
                    bossEnemyView.CharacterMovementView.Position) 
                                   < bossEnemyView.StoppingDistance);
            moveToPlayerState.AddTransition(toAttackTransition);
            initializeState.AddTransition(toAttackTransition);
            enemyRunState.AddTransition(toAttackTransition);

            FiniteTransition toRunTransition = new FiniteTransitionBase(enemyRunState, () => bossEnemy.IsRun);
            moveToPlayerState.AddTransition(toRunTransition);
            
            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => bossEnemy.EnemyHealth.CurrentHealth <= 0);
            attackState.AddTransition(toDieTransition);
            moveToPlayerState.AddTransition(toDieTransition);
            
            return new EnemyPresenter(initializeState, _updateRegister);
        }
    }
}