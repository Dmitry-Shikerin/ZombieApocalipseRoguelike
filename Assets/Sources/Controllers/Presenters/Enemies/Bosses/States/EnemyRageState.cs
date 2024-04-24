using System;
using Sources.Domain.Models.Enemies.Bosses;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Controllers.Enemies.Bosses.States
{
    public class EnemyRageState : FiniteState
    {
        private readonly BossEnemy _bossEnemy;
        private readonly IBossEnemyAnimation _bossEnemyAnimation;

        public EnemyRageState(BossEnemy bossEnemy, IBossEnemyAnimation bossEnemyAnimation)
        {
            _bossEnemy = bossEnemy ?? throw new ArgumentNullException(nameof(bossEnemy));
            _bossEnemyAnimation = bossEnemyAnimation ?? throw new ArgumentNullException(nameof(bossEnemyAnimation));
        }

        public override void Enter()
        {
            _bossEnemyAnimation.PlayScream();
            
            _bossEnemyAnimation.ScreamAnimationEnded += OnScreamAnimationEnded;
        }

        public override void Exit()
        {
            _bossEnemyAnimation.ScreamAnimationEnded += OnScreamAnimationEnded;
        }

        public override void Update(float deltaTime)
        {
        }

        private void OnScreamAnimationEnded()
        {
            _bossEnemy.IsRage = false;
        }
    }
}