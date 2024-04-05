using System;
using Sources.Controllers.Characters.Attackers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Controllers.Characters
{
    public class CharacterAttackerPresenterFactory
    {
        private readonly IInputService _inputService;

        public CharacterAttackerPresenterFactory(IInputService inputService)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public CharacterAttackerPresenter Create(
            CharacterAttacker characterAttacker,
            ICharacterAttackerView characterAttackerView)
        {
            return new CharacterAttackerPresenter(characterAttacker, characterAttackerView, _inputService);
        }
    }
}