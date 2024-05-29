﻿using System;
using Sources.Controllers.Presenters.Enemies.Base;
using Sources.Controllers.Presenters.Enemies.Base.States;
using Sources.Controllers.Presenters.Enemies.Bosses.States;
using Sources.Domain.Models.Enemies.Bosses;
using Sources.Domain.Models.Gameplay;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.Enemies;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using Sources.Utils.CustomCollections;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Enemies.Bosses
{
    public class BossEnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly IExplosionBodyBloodySpawnService _explosionBodyBloodySpawnService;
        private readonly IRewardItemSpawnService _rewardItemSpawnService;
        private readonly CustomCollection<IEnemyView> _enemyCollection;
        private readonly IEnemyAttackService _enemyAttackService;

        public BossEnemyPresenterFactory(
            IUpdateRegister updateRegister,
            IExplosionBodyBloodySpawnService explosionBodyBloodySpawnService,
            IRewardItemSpawnService rewardItemSpawnService,
            CustomCollection<IEnemyView> enemyCollection,
            IEnemyAttackService enemyAttackService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _explosionBodyBloodySpawnService = explosionBodyBloodySpawnService ??
                                               throw new ArgumentNullException(nameof(explosionBodyBloodySpawnService));
            _rewardItemSpawnService = rewardItemSpawnService ??
                                      throw new ArgumentNullException(nameof(rewardItemSpawnService));
            _enemyCollection = enemyCollection ??
                               throw new ArgumentNullException(nameof(enemyCollection));
            _enemyAttackService = enemyAttackService ??
                                  throw new ArgumentNullException(nameof(enemyAttackService));
        }

        public EnemyPresenter Create(
            BossEnemy bossEnemy,
            KillEnemyCounter killEnemyCounter,
            IBossEnemyView bossEnemyView,
            IBossEnemyAnimation bossEnemyAnimation)
        {
            EnemyInitializeState initializeState = new EnemyInitializeState(
                bossEnemy, bossEnemyAnimation, bossEnemyView, _enemyCollection);
            BossEnemyMoveToPlayerState moveToPlayerState = new BossEnemyMoveToPlayerState(
                bossEnemy, bossEnemyView, bossEnemyAnimation, _enemyAttackService);
            BossEnemyAttackState attackState = new BossEnemyAttackState(
                bossEnemy, bossEnemyView, bossEnemyAnimation, _enemyAttackService);
            EnemyDieState dieState = new EnemyDieState(
                killEnemyCounter,
                bossEnemyView,
                _explosionBodyBloodySpawnService,
                _rewardItemSpawnService,
                _enemyCollection);
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