using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Models.Bears.Attacks;
using Sources.Domain.Models.Constants.LayerMasks;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.Bears;
using Sources.InfrastructureInterfaces.Services.Overlaps;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Bears;

namespace Sources.Controllers.Presenters.Bears.Movements.States
{
    public class BearAttackState : FiniteState
    {
        private const float FindRadius = 2f;

        private readonly BearAttacker _bearAttacker;
        private readonly IBearView _bearView;
        private readonly IBearAnimationView _bearAnimationView;
        private readonly IBearMovementService _bearMovementService;
        private readonly IOverlapService _overlapService;

        public BearAttackState(
            BearAttacker bearAttacker,
            IBearView bearView,
            IBearAnimationView bearAnimationView,
            IBearMovementService bearMovementService,
            IOverlapService overlapService)
        {
            _bearAttacker = bearAttacker ?? throw new ArgumentNullException(nameof(bearAttacker));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _bearMovementService = bearMovementService ?? throw new ArgumentNullException(nameof(bearMovementService));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
        }

        public override void Enter()
        {
            _bearAnimationView.Attacking += OnAttack;
            _bearAnimationView.PlayAttack();
        }

        public override void Exit() =>
            _bearAnimationView.Attacking -= OnAttack;

        public override void Update(float deltaTime) =>
            ChangeLookDirection();

        private void OnAttack()
        {
            IReadOnlyList<EnemyHealthView> enemies = _overlapService.OverlapSphere<EnemyHealthView>(
                _bearView.TargetEnemyHealth.Position, FindRadius, Layer.Enemy, Layer.Obstacle);

            enemies
                .Take(_bearAttacker.UnitsPerAttack)
                .ToList()
                .ForEach(health => health.TakeDamage(_bearAttacker.Damage));

            if (_bearView.TargetEnemyHealth.CurrentHealth <= 0)
                _bearView.SetTarget(null);
        }

        private void ChangeLookDirection()
        {
            if (_bearView.TargetEnemyHealth == null)
                return;

            float angle = _bearMovementService.GetAngleRotation(
                _bearView.TargetEnemyHealth.Position, _bearView.Position);
            _bearView.SetLookRotation(angle);
        }
    }
}