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
    public class BossEnemyMoveToPlayerState : EnemyMoveToPlayerState
    {
        private readonly BossEnemy _enemy;
        private readonly IBossEnemyView _enemyView;
        private readonly IEnemyAttackService _enemyAttackService;

        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _runDelay;
        private TimeSpan _massAttackDelay;

        public BossEnemyMoveToPlayerState(
            BossEnemy enemy,
            IBossEnemyView enemyView,
            IBossEnemyAnimation enemyAnimation,
            IEnemyAttackService enemyAttackService)
            : base(
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
            _runDelay = TimeSpan.FromSeconds(EnemyConst.RunDelay);
            _massAttackDelay = TimeSpan.FromSeconds(EnemyConst.MassAttackAbilityDelay);

            _enemy.IsRun = false;
            _enemyView.SetAgentSpeed(_enemy.WalkSpeed);
            StartRunTimer(_cancellationTokenSource.Token);
            StartMassAttackTimer(_cancellationTokenSource.Token);
        }

        public override void Exit() =>
            _cancellationTokenSource.Cancel();

        private async void StartRunTimer(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    await UniTask.Delay(_runDelay, cancellationToken: cancellationToken);

                    _enemy.IsRun = true;
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async void StartMassAttackTimer(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    await UniTask.Delay(_massAttackDelay, cancellationToken: cancellationToken);

                    _enemyView.PlayMassAttackParticle();
                    _enemyAttackService.TryAttack(_enemyView.Position, EnemyConst.MassAttackDamage);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}