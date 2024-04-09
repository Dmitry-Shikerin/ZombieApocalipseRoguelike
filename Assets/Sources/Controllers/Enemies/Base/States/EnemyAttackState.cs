using System;
using Sources.Domain.Enemies;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Controllers.Enemies.Base.States
{
    public class EnemyAttackState : FiniteState
    {
        private readonly Enemy _enemy;
        private readonly IEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;

        public EnemyAttackState()
        {
        }

        public EnemyAttackState(
            Enemy enemy, 
            IEnemyView enemyView, 
            IEnemyAnimation enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _enemyAnimation.PlayAttack();
            _enemyAnimation.Attacking += OnAttack;
        }

        public override void Exit()
        {
            _enemyAnimation.Attacking -= OnAttack;
        }

        public override void Update(float deltaTime)
        {
        }

        private void OnAttack()
        {
            _enemyView.CharacterHealthView.TakeDamage(_enemy.EnemyAttacker.Damage);
        }
    }
}