using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Presenters.Enemies.Base.States;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Enemies.Bosses;
using Sources.InfrastructureInterfaces.Services.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;

namespace Sources.Controllers.Presenters.Enemies.Bosses.States
{
    public class BossEnemyAttackState : EnemyAttackState
    {
        private readonly BossEnemy _enemy;
        private readonly IBossEnemyView _enemyView;
        private readonly IEnemyAttackService _enemyAttackService;

        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _massAttackDelay;

        public BossEnemyAttackState(
            BossEnemy enemy,
            IBossEnemyView enemyView,
            IBossEnemyAnimation enemyAnimation,
            IEnemyAttackService enemyAttackService) : 
            base(
                enemy, 
                enemyView, 
                enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAttackService = enemyAttackService ?? throw new ArgumentNullException(nameof(enemyAttackService));
        }

        public override void Enter()
        {
            base.Enter();
            
            _cancellationTokenSource = new CancellationTokenSource();
            _massAttackDelay = TimeSpan.FromSeconds(EnemyConst.MassAttackAbilityDelay);

            CheckIsRun();
            StartMassAttackTimer(_cancellationTokenSource.Token);
        }

        public override void Exit()
        {
            base.Exit();
            _cancellationTokenSource.Cancel();
        }

        private async void StartMassAttackTimer(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    await UniTask.Delay(_massAttackDelay, cancellationToken: cancellationToken);
                    
                    ApplyMassAttack();
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void ApplyMassAttack()
        {
            _enemyView.PlayMassAttackParticle();
            _enemyAttackService.TryAttack(_enemyView.Position, EnemyConst.MassAttackDamage);
        }

        private void CheckIsRun()
        {
            if (_enemy.IsRun == false)
                return;

            ApplyMassAttack();
            _enemy.IsRun = false;
        }
    }
}