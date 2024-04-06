using System;
using Sources.Controllers.Bears.Movements;
using Sources.Controllers.Bears.Movements.States;
using Sources.Domain.Bears;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.Bears
{
    public class BearPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly OverlapService _overlapService;

        public BearPresenterFactory(
            IUpdateRegister updateRegister,
            OverlapService overlapService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
        }

        public BearPresenter Create(Bear bear, IBearView bearView, IBearAnimationView bearAnimationView)
        {
            BearIdleState idleState = new BearIdleState(bearView, bearAnimationView, _overlapService);
            BearFollowCharacterState followCharacterState = new BearFollowCharacterState(
                bear, bearAnimationView, bearView);
            BearMoveToEnemyState moveToEnemyState = new BearMoveToEnemyState(bear, bearAnimationView, bearView);
            BearAttackState attackState = new BearAttackState(bear, bear.BearAttacker, bearView, bearAnimationView);
            
            FiniteTransitionBase toFollowTransition = new FiniteTransitionBase(
                followCharacterState,
                () => Vector3.Distance(bearView.CharacterMovementView.Position, bearView.Position) > 4f);
            idleState.AddTransition(toFollowTransition);
            attackState.AddTransition(toFollowTransition);
            
            FiniteTransitionBase toIdleTransition = new FiniteTransitionBase(
                idleState, ()=> bearView.TargetEnemyHealth == null &&  Vector3.Distance(
                    bearView.CharacterMovementView.Position, bearView.Position) < 4f);
            followCharacterState.AddTransition(toIdleTransition);
            moveToEnemyState.AddTransition(toIdleTransition);
            
            FiniteTransitionBase toMoveToEnemyTransition = new FiniteTransitionBase(
                moveToEnemyState, 
                () => bearView.TargetEnemyHealth != null && 
                      Vector3.Distance(bearView.CharacterMovementView.Position, bearView.Position) < 4f);
            idleState.AddTransition(toMoveToEnemyTransition);
            // followState.AddTransition(toMoveToEnemyTransition);
            
            FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
                attackState, 
                () => bearView.TargetEnemyHealth != null &&
                      Vector3.Distance(bearView.CharacterMovementView.Position,
                          bearView.Position) < 4f && 
                      Vector3.Distance(bearView.Position,
                          bearView.TargetEnemyHealth.Position) <= bearView.StoppingDistance);
            moveToEnemyState.AddTransition(toAttackTransition);
            
            return new BearPresenter(idleState, _updateRegister);
        }
    }
}