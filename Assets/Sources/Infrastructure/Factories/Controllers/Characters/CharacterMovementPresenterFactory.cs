using System;
using Sources.Controllers.Characters.Movements;
using Sources.Controllers.Characters.Movements.States;
using Sources.Domain.Characters;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Character;

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
            ICharacterMovementView view,
            ICharacterAnimationView characterAnimationView)
        {
            CharacterIdleState idleState = new CharacterIdleState(
                characterMovement, view, characterAnimationView, _inputService);
            
            
            return new CharacterMovementPresenter(characterMovement, view, _updateRegister, idleState);
        }
    }
}