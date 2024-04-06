using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Controllers.Bears.Movements.States
{
    public class BearIdleState : FiniteState
    {
        private readonly IBearAnimationView _bearAnimationView;
        private readonly OverlapService _overlapService;
        private readonly IBearView _bearView;

        public BearIdleState(
            IBearView bearView,
            IBearAnimationView bearAnimationView,
            OverlapService overlapService)
        {
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
        }

        private IReadOnlyList<EnemyHealthView> _enemies;

        public override void Enter()
        {
            // Debug.Log($"Bear enter idle state");
            _bearAnimationView.PlayIdle();
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            FindEnemy();
        }

        private void FindEnemy()
        {
            if(_bearView.TargetEnemyHealth != null)
                return;
            
            var enemies = _overlapService.OverlapSphere<EnemyHealthView>(
                _bearView.CharacterMovementView.Position, 5f, 
                1 << LayerMask.NameToLayer("Enemy"),
                1 << LayerMask.NameToLayer("Obstacle"));

            EnemyHealthView enemy = enemies.FirstOrDefault();
            
            _bearView.SetTarget(enemy);
        }
    }
}