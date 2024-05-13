using System;
using Sources.Controllers.Presenters.Enemies.Base;
using Sources.Controllers.Presenters.Enemies.Base.States;
using Sources.Domain.Models.Enemies.Base;
using Sources.Domain.Models.Gameplay;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Enemies.Base
{
    public class EnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly IExplosionBodyBloodySpawnService _explosionBodyBloodySpawnService;
        private readonly IRewardItemSpawnService _rewardItemSpawnService;
        private readonly CustomCollection<IEnemyView> _enemyCollection;

        public EnemyPresenterFactory(
            IUpdateRegister updateRegister,
            IExplosionBodyBloodySpawnService explosionBodyBloodySpawnService,
            IRewardItemSpawnService rewardItemSpawnService,
            CustomCollection<IEnemyView> enemyCollection)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _explosionBodyBloodySpawnService = explosionBodyBloodySpawnService ?? 
                                          throw new ArgumentNullException(nameof(explosionBodyBloodySpawnService));
            _rewardItemSpawnService = rewardItemSpawnService ?? 
                                      throw new ArgumentNullException(nameof(rewardItemSpawnService));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
        }

        public EnemyPresenter Create(Enemy enemy, KillEnemyCounter killEnemyCounter, IEnemyView enemyView, IEnemyAnimation enemyAnimation)
        {
            EnemyInitializeState initializeState = new EnemyInitializeState(
                enemy, enemyAnimation, enemyView, _enemyCollection);
            EnemyMoveToPlayerState moveToPlayerState = new EnemyMoveToPlayerState(
                enemyView, enemyAnimation);
            EnemyAttackState attackState = new EnemyAttackState(enemy, enemyView, enemyAnimation);
            EnemyDieState dieState = new EnemyDieState(
                killEnemyCounter,
                enemyView, 
                _explosionBodyBloodySpawnService, 
                _rewardItemSpawnService,
                _enemyCollection);

            FiniteTransition toMoveToPlayerTransition = new FiniteTransitionBase(
                moveToPlayerState,
                () =>
                    enemy.IsInitialized &&
                    enemyView.CharacterMovementView != null &&
                    Vector3.Distance(
                        enemyView.Position,
                        enemyView.CharacterMovementView.Position) > enemyView.StoppingDistance);
            initializeState.AddTransition(toMoveToPlayerTransition);
            attackState.AddTransition(toMoveToPlayerTransition);
            
            FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
                attackState, () => Vector3.Distance(
                    enemyView.Position, enemyView.CharacterMovementView.Position) < enemyView.StoppingDistance);
            moveToPlayerState.AddTransition(toAttackTransition);
            initializeState.AddTransition(toAttackTransition);
            
            FiniteTransition toDieTransition = new FiniteTransitionBase(
                dieState, () => enemy.EnemyHealth.CurrentHealth <= 0);
            attackState.AddTransition(toDieTransition);
            moveToPlayerState.AddTransition(toDieTransition);
            
            return new EnemyPresenter(
                initializeState,
                _updateRegister
            );
        }
    }
}