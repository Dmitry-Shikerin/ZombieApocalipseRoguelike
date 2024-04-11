using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sources.Domain.Constants.LayerMasks;
using Sources.Domain.Enemies.Bosses;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using UnityEngine;

namespace Sources.Controllers.Enemies.Bosses.States
{
    public class BossEnemyAttackState : FiniteState
    {
        private readonly BossEnemy _enemy;
        private readonly IBossEnemyView _enemyView;
        private readonly IBossEnemyAnimation _enemyAnimation;
        private readonly OverlapService _overlapService;

        private CancellationTokenSource _cancellationTokenSource;

        public BossEnemyAttackState(
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

            _enemyAnimation.PlayAttack();
            _enemyAnimation.Attacking += OnAttack;
            StartTimer(_cancellationTokenSource.Token);
        }

        public override void Exit()
        {
            _cancellationTokenSource.Cancel();
            _enemyAnimation.Attacking -= OnAttack;
        }

        public override void Update(float deltaTime)
        {
        }

        private void OnAttack()
        {
            _enemyView.CharacterHealthView.TakeDamage(_enemy.EnemyAttacker.Damage);
        }

        private async void StartTimer(CancellationToken cancellationToken)
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
                    _enemyView.Position, 7f, Layer.Character, Layer.Default);

            if (characterHealthViews.Count == 0)
            {
                Debug.Log($"characterHealthView count = 0");
                return;
            }

            characterHealthViews.First().TakeDamage(10);
            Debug.Log($"Enemy boss give damage");
        }
    }
}