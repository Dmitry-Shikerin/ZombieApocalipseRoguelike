using System;
using Sources.Controllers.Bears.Attacks;
using Sources.Domain.Models.Bears;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.Bears;
using Sources.PresentationsInterfaces.Views.Bears;

namespace Sources.Controllers.Presenters.Bears.Movements.States
{
    public class BearAttackState : FiniteState
    {
        private readonly Bear _bear;
        private readonly BearAttacker _bearAttacker;
        private readonly IBearView _bearView;
        private readonly IBearAnimationView _bearAnimationView;
        private readonly IBearMovementService _bearMovementService;

        public BearAttackState(
            Bear bear,
            BearAttacker bearAttacker,
            IBearView bearView,
            IBearAnimationView bearAnimationView,
            IBearMovementService bearMovementService)
        {
            _bear = bear ?? throw new ArgumentNullException(nameof(bear));
            _bearAttacker = bearAttacker ?? throw new ArgumentNullException(nameof(bearAttacker));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _bearMovementService = bearMovementService ?? throw new ArgumentNullException(nameof(bearMovementService));
        }

        public override void Enter()
        {
            _bearAnimationView.Attacking += OnAttack;

            _bearAnimationView.PlayAttack();
        }

        public override void Exit()
        {
            _bearAnimationView.Attacking -= OnAttack;
        }

        public override void Update(float deltaTime)
        {
            if (_bearView.TargetEnemyHealth.CurrentHealth <= 0)
                _bearView.SetTarget(null);
        }

        private void OnAttack()
        {
            ChangeLookDirection();
            _bearView.TargetEnemyHealth.TakeDamage(_bearAttacker.Damage);
        }

        private void ChangeLookDirection()
        {
            //TODO сделать плавный поворот к противнику
            float angle = _bearMovementService.GetAngleRotation(
                _bearView.TargetEnemyHealth.Position, _bearView.Position);
            _bearView.SetLookRotation(angle);
        }
    }
}