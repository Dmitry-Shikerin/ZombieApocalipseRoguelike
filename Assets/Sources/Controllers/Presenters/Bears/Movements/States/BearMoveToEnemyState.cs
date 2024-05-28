using System;
using Sources.Domain.Models.Bears;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Bears;

namespace Sources.Controllers.Presenters.Bears.Movements.States
{
    public class BearMoveToEnemyState : FiniteState
    {
        private readonly IBearAnimationView _bearAnimationView;
        private readonly IBearView _bearView;

        public BearMoveToEnemyState(
            IBearAnimationView bearAnimationView,
            IBearView bearView)
        {
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
        }

        public override void Enter()
        {
            _bearView.SetStoppingDistance(2f);
            _bearAnimationView.PlayWalk();
        }

        public override void Update(float deltaTime) =>
            _bearView.Move(_bearView.TargetEnemyHealth.Position);
    }
}