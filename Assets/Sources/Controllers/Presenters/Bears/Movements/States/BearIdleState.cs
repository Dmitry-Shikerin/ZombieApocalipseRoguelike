using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Models.Constants.LayerMasks;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Presentations.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Bears;

namespace Sources.Controllers.Presenters.Bears.Movements.States
{
    public class BearIdleState : FiniteState
    {
        private const float FindRadius = 5f;
        
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
            _bearAnimationView.PlayIdle();
            _bearView.SetTarget(null);
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
            //TODO порефакторить попозже когда доделается логика
            if (_bearView.TargetEnemyHealth != null)
                return;

            IReadOnlyList<EnemyHealthView> enemies = _overlapService.OverlapSphere<EnemyHealthView>(
                _bearView.CharacterMovementView.Position, FindRadius, Layer.Enemy, Layer.Obstacle);

            EnemyHealthView enemy = enemies.FirstOrDefault();
            
            if(enemy != null && enemy.enabled == false)
                enemy = null;

            _bearView.SetTarget(enemy);
        }
    }
}