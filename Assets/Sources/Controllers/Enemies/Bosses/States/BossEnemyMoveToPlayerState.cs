using System;
using Sources.Domain.Enemies.Bosses;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Controllers.Enemies.Bosses.States
{
    public class BossEnemyMoveToPlayerState : FiniteState
    {
        private readonly BossEnemy _enemy;
        private readonly IBossEnemyView _enemyView;
        private readonly IBossEnemyAnimation _enemyAnimation;
        
        public BossEnemyMoveToPlayerState(
            BossEnemy enemy, 
            IBossEnemyView enemyView, 
            IBossEnemyAnimation enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _enemyView.SetAgentSpeed(1.8f);
            _enemyAnimation.PlayWalk();
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            _enemyView.Move(_enemyView.CharacterMovementView.Position);
        }
    }
}