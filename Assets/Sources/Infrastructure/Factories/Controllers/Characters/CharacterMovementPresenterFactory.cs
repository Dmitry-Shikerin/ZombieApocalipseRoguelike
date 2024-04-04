using System;
using Sources.Controllers.Characters.Movements;
using Sources.Controllers.Characters.Movements.States;
using Sources.Domain.Characters;
using Sources.Domain.Inputs;
using Sources.Infrastructure.StateMachines.ContextStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Infrastructure.Factories.Controllers.Characters
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
            CharacterForwardState forwardState = new CharacterForwardState(
                characterMovement, characterAnimationView, characterMovementView, _inputService);
            CharacterLeftwardState leftwardState = new CharacterLeftwardState(
                characterMovement, characterAnimationView, characterMovementView, _inputService);
            CharacterRightwardState rightwardState = new CharacterRightwardState(
                characterMovement, characterAnimationView, characterMovementView, _inputService);
            CharacterForwardLeftState forwardLeftState = new CharacterForwardLeftState(
                characterMovement, characterAnimationView, characterMovementView, _inputService);
            CharacterForwardRightState forwardRightState = new CharacterForwardRightState(
                characterMovement, characterAnimationView, characterMovementView, _inputService);
            CharacterBackwardState backwardState = new CharacterBackwardState(
                characterMovement, characterAnimationView, characterMovementView, _inputService);
            CharacterBackwardLeftState backwardLeftState = new CharacterBackwardLeftState(
                characterMovement, characterAnimationView, characterMovementView, _inputService);
            CharacterBackwardRightState backwardRightState = new CharacterBackwardRightState(
                characterMovement, characterAnimationView, characterMovementView, _inputService);
            
            FuncContextTransition toForwardTransition = new FuncContextTransition(
                forwardState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;

                    if (inputData.MoveDirection.magnitude < 0.01f)
                        return false;

                    float angle = Vector3.SignedAngle(
                        inputData.MoveDirection, characterMovementView.Forward, Vector3.up);
                    
                    if (angle > 30 || angle < -30)
                        return false;
                    
                    return true;
                });
            idleState.AddTransition(toForwardTransition);
            forwardRightState.AddTransition(toForwardTransition);
            forwardLeftState.AddTransition(toForwardTransition);
            leftwardState.AddTransition(toForwardTransition);
            rightwardState.AddTransition(toForwardTransition);
            backwardState.AddTransition(toForwardTransition);
            backwardLeftState.AddTransition(toForwardTransition);
            backwardRightState.AddTransition(toForwardTransition);

            FuncContextTransition toForwardRightTransition = new FuncContextTransition(
                forwardRightState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;
                    
                    if (inputData.MoveDirection.magnitude < 0.01f)
                        return false;
                    
                    float angle = Vector3.SignedAngle(
                        inputData.MoveDirection, characterMovementView.Forward, Vector3.up);
                    
                    if (angle > -30 || angle < -60)
                        return false;

                    return true;
                });
            idleState.AddTransition(toForwardRightTransition);
            forwardState.AddTransition(toForwardRightTransition);
            forwardLeftState.AddTransition(toForwardRightTransition);
            leftwardState.AddTransition(toForwardRightTransition);
            rightwardState.AddTransition(toForwardRightTransition);
            backwardState.AddTransition(toForwardRightTransition);
            backwardLeftState.AddTransition(toForwardRightTransition);
            backwardRightState.AddTransition(toForwardRightTransition);

            FuncContextTransition toForwardLeftTransition = new FuncContextTransition(
                forwardLeftState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;
                    
                    if (inputData.MoveDirection.magnitude < 0.01f)
                        return false;
                    
                    float angle = Vector3.SignedAngle(
                        inputData.MoveDirection, characterMovementView.Forward, Vector3.up);

                    if (angle < 30 || angle > 60)
                        return false;

                    return true;
                });
            idleState.AddTransition(toForwardLeftTransition);
            forwardState.AddTransition(toForwardLeftTransition);
            forwardRightState.AddTransition(toForwardLeftTransition);
            leftwardState.AddTransition(toForwardLeftTransition);
            rightwardState.AddTransition(toForwardLeftTransition);
            backwardState.AddTransition(toForwardLeftTransition);
            backwardLeftState.AddTransition(toForwardLeftTransition);
            backwardRightState.AddTransition(toForwardLeftTransition);

            FuncContextTransition toLeftwardTransition = new FuncContextTransition(
                leftwardState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;
                    
                    if (inputData.MoveDirection.magnitude < 0.01f)
                        return false;
                    
                    float angle = Vector3.SignedAngle(
                        inputData.MoveDirection, characterMovementView.Forward, Vector3.up);

                    if (angle < 60 || angle > 120)
                        return false;

                    return true;
                });
            idleState.AddTransition(toLeftwardTransition);
            forwardState.AddTransition(toLeftwardTransition);
            forwardRightState.AddTransition(toLeftwardTransition);
            forwardLeftState.AddTransition(toLeftwardTransition);
            rightwardState.AddTransition(toLeftwardTransition);
            backwardState.AddTransition(toLeftwardTransition);
            backwardLeftState.AddTransition(toLeftwardTransition);
            backwardRightState.AddTransition(toLeftwardTransition);

            FuncContextTransition toRightwardTransition = new FuncContextTransition(
                rightwardState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;
                    
                    if (inputData.MoveDirection.magnitude < 0.01f)
                        return false;
                    
                    float angle = Vector3.SignedAngle(
                        inputData.MoveDirection, characterMovementView.Forward, Vector3.up);

                    if (angle > -60 || angle < -120)
                        return false;

                    return true;
                });
            idleState.AddTransition(toRightwardTransition);
            forwardState.AddTransition(toRightwardTransition);
            forwardRightState.AddTransition(toRightwardTransition);
            forwardLeftState.AddTransition(toRightwardTransition);
            leftwardState.AddTransition(toRightwardTransition);
            backwardState.AddTransition(toRightwardTransition);
            backwardLeftState.AddTransition(toRightwardTransition);
            backwardRightState.AddTransition(toRightwardTransition);

            FuncContextTransition toBackwardLeftTransition = new FuncContextTransition(
                backwardLeftState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;
                    
                    if (inputData.MoveDirection.magnitude < 0.01f)
                        return false;
                    
                    float angle = Vector3.SignedAngle(
                        inputData.MoveDirection, characterMovementView.Forward, Vector3.up);

                    if (angle < 120 || angle > 150)
                        return false;

                    return true;
                });
            idleState.AddTransition(toBackwardLeftTransition);
            forwardState.AddTransition(toBackwardLeftTransition);
            forwardRightState.AddTransition(toBackwardLeftTransition);
            forwardLeftState.AddTransition(toBackwardLeftTransition);
            leftwardState.AddTransition(toBackwardLeftTransition);
            rightwardState.AddTransition(toBackwardLeftTransition);
            backwardState.AddTransition(toBackwardLeftTransition);
            backwardRightState.AddTransition(toBackwardLeftTransition);

            FuncContextTransition toBackwardRightTransition = new FuncContextTransition(
                backwardRightState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;
                    
                    if (inputData.MoveDirection.magnitude < 0.01f)
                        return false;
                    
                    float angle = Vector3.SignedAngle(
                        inputData.MoveDirection, characterMovementView.Forward, Vector3.up);

                    if (angle > -120 || angle < -150)
                        return false;

                    return true;
                });
            idleState.AddTransition(toBackwardRightTransition);
            forwardState.AddTransition(toBackwardRightTransition);
            forwardRightState.AddTransition(toBackwardRightTransition);
            forwardLeftState.AddTransition(toBackwardRightTransition);
            leftwardState.AddTransition(toBackwardRightTransition);
            rightwardState.AddTransition(toBackwardRightTransition);
            backwardState.AddTransition(toBackwardRightTransition);
            backwardLeftState.AddTransition(toBackwardRightTransition);

            FuncContextTransition toBackwardTransition = new FuncContextTransition(
                backwardState,
                context =>
                {
                    if (context is not InputData inputData)
                        return false;

                    if (inputData.MoveDirection.magnitude < 0.01f)
                        return false;
                    
                    float angle = Vector3.SignedAngle(
                        inputData.MoveDirection, characterMovementView.Forward, Vector3.up);

                    //TODO как это работает?
                    if (angle < 150 && angle > -150)
                    {
                        // Debug.Log($"Backward angle: {angle}");
                        return false;
                    }

                    return true;
                });
            idleState.AddTransition(toBackwardTransition);
            forwardState.AddTransition(toBackwardTransition);
            forwardRightState.AddTransition(toBackwardTransition);
            forwardLeftState.AddTransition(toBackwardTransition);
            leftwardState.AddTransition(toBackwardTransition);
            rightwardState.AddTransition(toBackwardTransition);
            backwardRightState.AddTransition(toBackwardTransition);
            backwardLeftState.AddTransition(toBackwardTransition);

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
            forwardState.AddTransition(toIdleTransition);
            forwardRightState.AddTransition(toIdleTransition);
            forwardLeftState.AddTransition(toIdleTransition);
            leftwardState.AddTransition(toIdleTransition);
            rightwardState.AddTransition(toIdleTransition);
            backwardState.AddTransition(toIdleTransition);
            backwardRightState.AddTransition(toIdleTransition);
            backwardLeftState.AddTransition(toIdleTransition);

            
            return new CharacterMovementPresenter(characterMovement, characterMovementView, _updateRegister, idleState);
        }
    }
}