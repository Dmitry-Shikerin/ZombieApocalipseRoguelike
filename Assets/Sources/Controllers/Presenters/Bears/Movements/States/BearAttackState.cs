using System;
using Sources.Controllers.Bears.Attacks;
using Sources.Domain.Bears;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Controllers.Bears.Movements.States
{
    public class BearAttackState : FiniteState
    {
        private readonly Bear _bear;
        private readonly BearAttacker _bearAttacker;
        private readonly IBearView _bearView;
        private readonly IBearAnimationView _bearAnimationView;

        public BearAttackState(
            Bear bear,
            BearAttacker bearAttacker,
            IBearView bearView,
            IBearAnimationView bearAnimationView)
        {
            _bear = bear ?? throw new ArgumentNullException(nameof(bear));
            _bearAttacker = bearAttacker ?? throw new ArgumentNullException(nameof(bearAttacker));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
        }

        public override void Enter()
        {
            // Debug.Log($"Bear enter attack state");
            _bearAnimationView.Attacking += OnAttack;

            _bearAnimationView.PlayAttack();
        }

        public override void Exit()
        {
            _bearAnimationView.Attacking -= OnAttack;
        }

        public override void Update(float deltaTime)
        {
            if(_bearView.TargetEnemyHealth.CurrentHealth <= 0)
                _bearView.SetTarget(null);
        }

        //TODO вынести в MVC и сервис или чисто в сервис
        private void OnAttack()
        {
            _bearView.TargetEnemyHealth.TakeDamage(_bearAttacker.Damage);
            var lookDirection = _bearView.TargetEnemyHealth.Position - _bearView.Position;
            lookDirection.y = _bearView.Position.y;
            float distance = lookDirection.magnitude;
            
            float angle = Vector3.SignedAngle(Vector3.forward, lookDirection, Vector3.up);
            
            if(distance < 0.7f)
                return;
            
            _bearView.SetLookRotation(angle);
        }

        private void ChangeForwardPosition()
        {
            Vector3 targetDirection = _bearView.TargetEnemyHealth.Position - _bearView.Position;

            if (_bearView.Forward == targetDirection)
                return;

            while (_bearView.Forward != targetDirection)
            {
                Vector3 direction = Vector3.MoveTowards(
                    _bearView.Forward, targetDirection, 0.1f);

                Quaternion look = Quaternion.LookRotation(direction);
            }
        }
    }
}