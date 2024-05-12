using System;
using Sources.Controllers.Presenters.Enemies.Base.States;
using Sources.Domain.Models.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Controllers.Presenters.Enemies.Bosses.States
{
    public class EnemyRunState : EnemyMoveToPlayerState
    {
        private readonly BossEnemy _bossEnemy;
        private readonly IBossEnemyView _bossEnemyView;
        private readonly IBossEnemyAnimation _bossEnemyAnimation;

        public EnemyRunState(
            BossEnemy enemy, 
            IBossEnemyView enemyView, 
            IBossEnemyAnimation enemyAnimation) 
            : base( 
                enemyView, 
                enemyAnimation)
        {
            _bossEnemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _bossEnemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _bossEnemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            base.Enter();
            
            _bossEnemyView.SetAgentSpeed(_bossEnemy.RunSpeed);
            _bossEnemyAnimation.PlayRun();
        }
    }
}