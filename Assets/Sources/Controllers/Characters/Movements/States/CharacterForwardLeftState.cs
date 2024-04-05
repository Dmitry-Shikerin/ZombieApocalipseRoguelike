using System;
using Sources.Domain.Characters;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Controllers.Characters.Movements.States
{
    public class CharacterForwardLeftState : ContextStateBase
    {
        private readonly CharacterMovement _characterMovement;
        private readonly ICharacterAnimationView _characterAnimationView;
        private readonly ICharacterMovementView _characterMovementView;
        private readonly IInputService _inputService;

        public CharacterForwardLeftState(
            CharacterMovement characterMovement,
            ICharacterAnimationView characterAnimationView,
            ICharacterMovementView characterMovementView,
            IInputService inputService)
        {
            _characterMovement = characterMovement ?? throw new ArgumentNullException(nameof(characterMovement));
            _characterAnimationView = characterAnimationView ?? throw new ArgumentNullException(nameof(characterAnimationView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _characterMovementView = characterMovementView ?? throw new ArgumentNullException(nameof(characterMovementView));
        }

        public override void Enter(object payload = null)
        {
            // _characterAnimationView.PlayForwardLeft();
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            float targetSpeed = _inputService.InputData.Speed > 0 
                ? _inputService.InputData.Speed 
                : 0.7f;

            _characterMovement.Speed = Mathf.MoveTowards(
                _characterMovement.Speed, targetSpeed, 0.01f);
            
            _characterMovement.Direction = _characterMovement.Speed * 2 *
                                           deltaTime * _inputService.InputData.MoveDirection.normalized;
            
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


            if(distance < 0.7f)
                return;
            
            _characterMovementView.SetLookRotation(angle);
        }

    }
}