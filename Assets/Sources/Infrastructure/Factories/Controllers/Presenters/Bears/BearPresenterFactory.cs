using System;
using Sources.Controllers.Presenters.Bears.Movements;
using Sources.Controllers.Presenters.Bears.Movements.States;
using Sources.Domain.Models.Bears;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.Bears;
using Sources.InfrastructureInterfaces.Services.Overlaps;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Bears
{
    public class BearPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly IOverlapService _overlapService;
        private readonly IBearMovementService _bearMovementService;

        public BearPresenterFactory(
            IUpdateRegister updateRegister,
            IOverlapService overlapService,
            IBearMovementService bearMovementService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
            _bearMovementService = bearMovementService ?? throw new ArgumentNullException(nameof(bearMovementService));
        }

        public BearPresenter Create(Bear bear, IBearView bearView, IBearAnimationView bearAnimationView)
        {
            BearIdleState idleState = new BearIdleState(
                bear.BearAttacker,bearView, bearAnimationView, _overlapService);
            BearFollowCharacterState followCharacterState = new BearFollowCharacterState(
                bear, bearAnimationView, bearView);
            BearMoveToEnemyState moveToEnemyState = new BearMoveToEnemyState(bear, bearAnimationView, bearView);
            BearAttackState attackState = new BearAttackState(
                bear, bear.BearAttacker, bearView, bearAnimationView, _bearMovementService, _overlapService);
            
            FiniteTransitionBase toFollowTransition = new FiniteTransitionBase(
                followCharacterState,
                () => Vector3.Distance(bearView.CharacterMovementView.Position, bearView.Position) > 5f);
            idleState.AddTransition(toFollowTransition);
            attackState.AddTransition(toFollowTransition);
            
            FiniteTransitionBase toIdleTransition = new FiniteTransitionBase(
                idleState, ()=> bearView.TargetEnemyHealth == null &&  Vector3.Distance(
                    bearView.CharacterMovementView.Position, bearView.Position) < 5f);
            followCharacterState.AddTransition(toIdleTransition);
            moveToEnemyState.AddTransition(toIdleTransition);
            attackState.AddTransition(toIdleTransition);
            
            FiniteTransitionBase toMoveToEnemyTransition = new FiniteTransitionBase(
                moveToEnemyState, 
                () => bearView.TargetEnemyHealth != null && 
                      Vector3.Distance(bearView.CharacterMovementView.Position, bearView.Position) < 5f &&
                      Vector3.Distance(bearView.TargetEnemyHealth.Position, bearView.Position) < 5f);
            idleState.AddTransition(toMoveToEnemyTransition);
            // followState.AddTransition(toMoveToEnemyTransition);
            
            FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
                attackState, 
                () => bearView.TargetEnemyHealth != null &&
                      Vector3.Distance(bearView.CharacterMovementView.Position,
                          bearView.Position) < 5f && 
                      Vector3.Distance(bearView.Position,
                          bearView.TargetEnemyHealth.Position) <= bearView.StoppingDistance);
            moveToEnemyState.AddTransition(toAttackTransition);
            
            return new BearPresenter(idleState, _updateRegister);
        }
    }
}