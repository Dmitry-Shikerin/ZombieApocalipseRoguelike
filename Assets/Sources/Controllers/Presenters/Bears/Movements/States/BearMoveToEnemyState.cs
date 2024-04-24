using System;
using Sources.Domain.Models.Bears;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Bears;

namespace Sources.Controllers.Bears.Movements.States
{
    public class BearMoveToEnemyState : FiniteState
    {
        private readonly Bear _bear;
        private readonly IBearAnimationView _bearAnimationView;
        private readonly IBearView _bearView;

        public BearMoveToEnemyState(
            Bear bear,
            IBearAnimationView bearAnimationView,
            IBearView bearView)
        {
            _bear = bear ?? throw new ArgumentNullException(nameof(bear));
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
        }

        public override void Enter()
        {
            // Debug.Log($"Bear enter moveToEnemy state");
            
            _bearView.SetStoppingDistance(2f);
            _bearAnimationView.PlayWalk();
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            _bearView.Move(_bearView.TargetEnemyHealth.Position);
        }
    }
}