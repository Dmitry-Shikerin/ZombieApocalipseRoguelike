using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Enemies.Bosses;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Controllers.Enemies.Bosses.States
{
    public class EnemyIdleState : FiniteState
    {
        private readonly BossEnemy _bossEnemy;
        private readonly IBossEnemyAnimation _bossEnemyAnimation;
        
        private CancellationTokenSource _cancellationTokenSource;

        public EnemyIdleState(BossEnemy bossEnemy, IBossEnemyAnimation bossEnemyAnimation)
        {
            _bossEnemy = bossEnemy ?? throw new ArgumentNullException(nameof(bossEnemy));
            _bossEnemyAnimation = bossEnemyAnimation ?? throw new ArgumentNullException(nameof(bossEnemyAnimation));
        }

        public override void Enter()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            _bossEnemyAnimation.PlayIdle();
            
            StartTimer(_cancellationTokenSource.Token);
        }

        public override void Exit()
        {
            _cancellationTokenSource.Cancel();
        }

        public override void Update(float deltaTime)
        {
            
        }

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

                _bossEnemy.IsIdle = false;
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}