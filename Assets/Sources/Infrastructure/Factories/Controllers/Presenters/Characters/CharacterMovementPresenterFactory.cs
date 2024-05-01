using System;
using Sources.Controllers.Characters.Movements.States;
using Sources.Controllers.Presenters.Characters.Movements;
using Sources.Domain.Models.Characters;
using Sources.Domain.Models.Inputs;
using Sources.Infrastructure.StateMachines.ContextStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Characters
{
    public class CharacterMovementPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly IInputService _inputService;

        public CharacterMovementPresenterFactory(
            IUpdateRegister updateRegister,
            IInputService inputService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public CharacterMovementPresenter Create(
            CharacterMovement characterMovement,
            ICharacterMovementView characterMovementView,
            ICharacterAnimationView characterAnimationView)
        {
            if (characterMovement == null) 
                throw new ArgumentNullException(nameof(characterMovement));
            
            if (characterMovementView == null) 
                throw new ArgumentNullException(nameof(characterMovementView));
            
            if (characterAnimationView == null) 
                throw new ArgumentNullException(nameof(characterAnimationView));
            
            CharacterIdleState idleState = new CharacterIdleState(
                characterMovement, characterMovementView, characterAnimationView, _inputService);
            CharacterMovementState characterMovementState = new CharacterMovementState(
                characterMovement, characterAnimationView, characterMovementView, _inputService);
            
            FuncContextTransition toForwardTransition = new FuncContextTransition(
                characterMovementState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;

                    if (inputData.MoveDirection.magnitude < 0.01f)
                        return false;

                    return true;
                });
            idleState.AddTransition(toForwardTransition);
            
            FuncContextTransition toIdleTransition = new FuncContextTransition(
                idleState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;

                    if (inputData.MoveDirection.magnitude > 0.01f)
                        return false;

                    return true;
                });
            characterMovementState.AddTransition(toIdleTransition);
            
            return new CharacterMovementPresenter(
                characterMovement, 
                characterMovementView, 
                _updateRegister,
                _inputService,
                idleState);
        }
    }
}