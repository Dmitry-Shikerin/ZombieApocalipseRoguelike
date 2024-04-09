using System;
using Sources.Domain.Enemies;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Controllers.Enemies.States
{
    public class EnemyInitializeState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IEnemyAnimation _enemyAnimation;

        public EnemyInitializeState(Enemy enemy, IEnemyAnimation enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyAnimation = enemyAnimation;
        }

        public override void Enter()
        {
            _enemy.IsInitialized = true;
            _enemyAnimation.PlayIdle();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }
    }
}