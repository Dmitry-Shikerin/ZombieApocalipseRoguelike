using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Constants.LayerMasks;
using Sources.Domain.Enemies.Bosses;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Controllers.Enemies.Bosses.States
{
    public class BossEnemyMoveToPlayerState : FiniteState
    {
        private readonly BossEnemy _enemy;
        private readonly IBossEnemyView _enemyView;
        private readonly IBossEnemyAnimation _enemyAnimation;
        private readonly OverlapService _overlapService;

        private CancellationTokenSource _cancellationTokenSource;
        
        public BossEnemyMoveToPlayerState(
            BossEnemy enemy, 
            IBossEnemyView enemyView, 
            IBossEnemyAnimation enemyAnimation,
            OverlapService overlapService)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
        }

        public override void Enter()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            _enemy.IsRun = false;
            _enemyView.SetAgentSpeed(1.8f);
            _enemyAnimation.PlayWalk();
            StartMassAttackTimer(_cancellationTokenSource.Token);
            StartRunTimer(_cancellationTokenSource.Token);
        }

        public override void Exit()
        {
            _cancellationTokenSource.Cancel();
        }

        public override void Update(float deltaTime)
        {
            _enemyView.Move(_enemyView.CharacterMovementView.Position);
        }

        private async void StartMassAttackTimer(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    while (_enemy.CurrentTimeRunning <= 5)
                    {
                        _enemy.CurrentTimeRunning += Time.deltaTime;
                        await UniTask.Yield(cancellationToken);
                    }

                    _enemy.CurrentTimeRunning = 0;
                    _enemy.IsRun = true;
                    Debug.Log($"Is run = {_enemy.IsRun}");
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
        
        private async void StartRunTimer(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    while (_enemy.CurrentTimeAbility <= 5)
                    {
                        _enemy.CurrentTimeAbility += Time.deltaTime;
                        await UniTask.Yield(cancellationToken);
                    }

                    _enemy.CurrentTimeAbility = 0;
                    _enemyView.PlayMassAttackParticle();
                    TryAttack();
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
        
        private void TryAttack()
        {
            var characterHealthViews =
                _overlapService.OverlapSphere<CharacterHealthView>(
                    _enemyView.Position, 5f, Layer.Character, Layer.Default);

            if (characterHealthViews.Count == 0)
                return;

            characterHealthViews.First().TakeDamage(10);
        }
    }
}