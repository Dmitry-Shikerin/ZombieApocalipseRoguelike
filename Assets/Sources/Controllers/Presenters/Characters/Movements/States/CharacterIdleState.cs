using System;
using Sources.Domain.Models.Characters;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.Characters;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Controllers.Presenters.Characters.Movements.States
{
    public class CharacterIdleState : ContextStateBase
    {
        private const float Speed = 0;

        private readonly CharacterMovement _characterMovement;
        private readonly ICharacterAnimationView _characterAnimationView;
        private readonly IInputService _inputService;
        private readonly ICharacterMovementService _movementService;
        private readonly ICharacterMovementView _characterMovementView;

        public CharacterIdleState(
            CharacterMovement characterMovement,
            ICharacterMovementView characterMovementView,
            ICharacterAnimationView characterAnimationView,
            IInputService inputService,
            ICharacterMovementService characterMovementService)
        {
            _characterMovement = characterMovement ?? throw new ArgumentNullException(nameof(characterMovement));
            _characterAnimationView = characterAnimationView ??
                                   throw new ArgumentNullException(nameof(characterAnimationView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _movementService = characterMovementService ??
                                        throw new ArgumentNullException(nameof(characterMovementService));
            _characterMovementView = characterMovementView ??
                                     throw new ArgumentNullException(nameof(characterMovementView));
        }

        public override void Update(float deltaTime)
        {
            try
            {
                _movementService.SetSpeed(_characterMovement, Speed, deltaTime);

                if (_inputService.InputData.LookPosition == Vector3.zero)
                    return;

                float angle = _movementService.GetAngleRotation(
                    _characterMovementView.Position, _inputService.InputData.LookPosition);
                _movementService.SetAnimationDirection(
                    _characterMovement, _inputService.InputData.MoveDirection, angle, deltaTime);
                _characterAnimationView.SetDirection(_characterMovement.AnimationDirection);
                _characterMovementView.SetLookRotation(angle);
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}