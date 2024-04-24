using System;
using Sources.Controllers.Characters.Attackers;
using Sources.Domain.Models.Characters.Attackers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Controllers.Characters
{
    public class CharacterAttackerPresenterFactory
    {
        private readonly IInputService _inputService;
        private readonly IUpdateRegister _updateRegister;

        public CharacterAttackerPresenterFactory(
            IInputService inputService,
            IUpdateRegister updateRegister)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public CharacterAttackerPresenter Create(
            CharacterAttacker characterAttacker,
            ICharacterAttackerView characterAttackerView)
        {
            return new CharacterAttackerPresenter(
                characterAttacker, characterAttackerView, _inputService, _updateRegister);
        }
    }
}