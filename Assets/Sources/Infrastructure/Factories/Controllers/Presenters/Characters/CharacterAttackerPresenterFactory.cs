using System;
using Sources.Controllers.Presenters.Characters.Attackers;
using Sources.Domain.Models.Characters.Attackers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Characters
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
            CharacterAttacker characterAttacker)
        {
            return new CharacterAttackerPresenter(
                characterAttacker, _inputService, _updateRegister);
        }
    }
}