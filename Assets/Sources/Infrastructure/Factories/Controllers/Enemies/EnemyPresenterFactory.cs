using System;
using Sources.Controllers.Enemies;
using Sources.Controllers.Enemies.States;
using Sources.Domain.Enemies;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.Enemies
{
    public class EnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;

        public EnemyPresenterFactory(IUpdateRegister updateRegister)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public EnemyPresenter Create(Enemy enemy, IEnemyView enemyView, IEnemyAnimation enemyAnimation)
        {
            EnemyInitializeState initializeState = new EnemyInitializeState(enemy, enemyAnimation);
            EnemyMoveToPlayerState moveToPlayerState = new EnemyMoveToPlayerState(enemy, enemyView, enemyAnimation);
            EnemyAttackState attackState = new EnemyAttackState(enemy, enemyView, enemyAnimation);
            EnemyDieState dieState = new EnemyDieState();

            FiniteTransition toMoveToPlayerTransition = new FiniteTransitionBase(
                moveToPlayerState,
                () =>
                    enemy.IsInitialized &&
                    Vector3.Distance(
                        enemyView.Position,
                        enemyView.CharacterMovementView.Position) > enemyView.StoppingDistance);
            initializeState.AddTransition(toMoveToPlayerTransition);
            attackState.AddTransition(toMoveToPlayerTransition);
            
            FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
                attackState, () => Vector3.Distance(
                    enemyView.Position, enemyView.CharacterMovementView.Position) < enemyView.StoppingDistance);
            moveToPlayerState.AddTransition(toAttackTransition);
            
            return new EnemyPresenter(
                initializeState,
                enemy,
                enemyView,
                _updateRegister
            );
        }
    }
}