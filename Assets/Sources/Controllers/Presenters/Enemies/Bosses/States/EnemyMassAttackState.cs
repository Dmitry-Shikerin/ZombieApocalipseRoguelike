using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Enemies.Bosses;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Controllers.Presenters.Enemies.Bosses.States
{
    public class EnemyMassAttackState : FiniteState
    {
        private readonly BossEnemy _bossEnemy;
        private readonly IBossEnemyView _bossEnemyView;
        
        private CancellationTokenSource _cancellationTokenSource;

        public EnemyMassAttackState(BossEnemy bossEnemy, IBossEnemyView bossEnemyView)
        {
            _bossEnemy = bossEnemy ?? throw new ArgumentNullException(nameof(bossEnemy));
            _bossEnemyView = bossEnemyView ?? throw new ArgumentNullException(nameof(bossEnemyView));
        }

        public override void Enter()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _bossEnemyView.PlayMassAttackParticle();
            StartTimer(_cancellationTokenSource.Token);
        }

        public override void Exit() =>
            _cancellationTokenSource.Cancel();
        
        private async void StartTimer(CancellationToken cancellationToken)
        {
            try
            {
                float currentTime = 0;

                while (currentTime < _bossEnemy.StunTime)
                {
                    currentTime += Time.deltaTime;

                    await UniTask.Yield(cancellationToken);
                }

                _bossEnemy.IsMassAttack = false;
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}