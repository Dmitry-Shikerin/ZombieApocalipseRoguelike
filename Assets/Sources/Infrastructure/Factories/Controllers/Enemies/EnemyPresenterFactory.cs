using System;
using Sources.Controllers.Enemies;
using Sources.Controllers.Enemies.States;
using Sources.Domain.Enemies;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Infrastructure.Factories.Controllers.Enemies
{
    public class EnemyPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;

        public EnemyPresenterFactory(IUpdateRegister updateRegister)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public EnemyPresenter Create(Enemy enemy, IEnemyView enemyView)
        {
            EnemyInitializeState initializeState = new EnemyInitializeState(enemy);
            EnemyMoveToPlayerState moveToPlayerState = new EnemyMoveToPlayerState();
            EnemyAttackState attackState = new EnemyAttackState();
            EnemyDieState dieState = new EnemyDieState();
            
            FiniteTransition toMoveToPlayerTransition = new FiniteTransitionBase(
                moveToPlayerState, () => enemy.IsInitialized);
            initializeState.AddTransition(toMoveToPlayerTransition);

            return new EnemyPresenter(
                initializeState,
                enemy,
                enemyView,
                _updateRegister
            );
        }
    }
}