﻿using System;
using Sources.Domain.Models.Characters;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Controllers.Characters.Movements.States
{
    public class CharacterIdleState : ContextStateBase
    {
        private readonly CharacterMovement _characterMovement;
        private readonly ICharacterAnimationView _characterAnimationView;
        private readonly IInputService _inputService;
        private readonly ICharacterMovementView _characterMovementView;

        public CharacterIdleState(
            CharacterMovement characterMovement,
            ICharacterMovementView characterMovementView,
            ICharacterAnimationView characterAnimationView,
            IInputService inputService)
        {
            _characterMovement = characterMovement ?? throw new ArgumentNullException(nameof(characterMovement));
            _characterAnimationView = characterAnimationView ?? 
                                   throw new ArgumentNullException(nameof(characterAnimationView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _characterMovementView = characterMovementView ?? throw new ArgumentNullException(nameof(characterMovementView));
        }

        public override void Enter(object payload = null)
        {
        }

        public override void Update(float deltaTime)
        {
            _characterMovement.Speed = Mathf.MoveTowards(
                _characterMovement.Speed, 0, 0.01f);
            
            float targetSpeed = _inputService.InputData.Speed > 0 
                ? _inputService.InputData.Speed 
                : 0.7f;

            _characterMovement.Speed = Mathf.MoveTowards(
                _characterMovement.Speed, targetSpeed, 0.01f);
            
            if(_inputService.InputData.LookPosition == Vector3.zero)
                return;

            var lookDirection = _inputService.InputData.LookPosition - _characterMovementView.Position;
            lookDirection.y = _characterMovementView.Position.y;
            float distance = lookDirection.magnitude;
            
            float angle = Vector3.SignedAngle(Vector3.forward, lookDirection, Vector3.up);
            
            Vector3 direction = Quaternion.Euler(0, -angle, 0) * _inputService.InputData.MoveDirection;
            
            Vector2 direction2 = new Vector2(direction.x, direction.z).normalized;
            _characterMovement.AnimationDirection = 
                Vector2.MoveTowards(
                    _characterMovement.AnimationDirection,
                    direction2, 
                    _characterMovement.AnimationDirectionSpeed * deltaTime);
            
            _characterAnimationView.SetDirection(_characterMovement.AnimationDirection);
            // _characterMovementView.Move(_characterMovement.Direction);
            
            if(distance < 0.7f)
                return;

            _characterMovementView.SetLookRotation(angle);
        }

    }
}