using System;
using Sources.Domain.Enemies.Bosses;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Controllers.Enemies.Bosses.States
{
    public class EnemyRunState : FiniteState
    {
        private readonly BossEnemy _bossEnemy;
        private readonly IBossEnemyView _bossEnemyView;
        private readonly IBossEnemyAnimation _bossEnemyAnimation;

        public EnemyRunState(
            BossEnemy bossEnemy, 
            IBossEnemyView bossEnemyView, 
            IBossEnemyAnimation bossEnemyAnimation)
        {
            _bossEnemy = bossEnemy ?? throw new ArgumentNullException(nameof(bossEnemy));
            _bossEnemyView = bossEnemyView ?? throw new ArgumentNullException(nameof(bossEnemyView));
            _bossEnemyAnimation = bossEnemyAnimation ?? throw new ArgumentNullException(nameof(bossEnemyAnimation));
        }

        public override void Enter()
        {
            Debug.Log($"Boss run state");
            _bossEnemyView.SetAgentSpeed(_bossEnemy.RunSpeed);
            _bossEnemyAnimation.PlayRun();
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            _bossEnemyView.Move(_bossEnemyView.CharacterMovementView.Position);
        }
    }
}