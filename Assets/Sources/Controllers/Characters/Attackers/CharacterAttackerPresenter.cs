using System;
using System.Threading;
using Sources.Controllers.Common;
using Sources.Domain.Characters.Attackers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Controllers.Characters.Attackers
{
    public class CharacterAttackerPresenter : PresenterBase
    {
        private readonly CharacterAttacker _characterAttacker;
        private readonly ICharacterAttackerView _characterAttackerView;
        private readonly IInputService _inputService;

        public CharacterAttackerPresenter(
            CharacterAttacker characterAttacker,
            ICharacterAttackerView characterAttackerView,
            IInputService inputService)
        {
            _characterAttacker = characterAttacker ?? throw new ArgumentNullException(nameof(characterAttacker));
            _characterAttackerView = characterAttackerView ?? 
                                     throw new ArgumentNullException(nameof(characterAttackerView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public override void Enable()
        {
             _inputService.Attacked += OnAttack;
        }

        public override void Disable()
        {
            _inputService.Attacked -= OnAttack;
        }

        private void OnAttack()
        {
            //TODO поменять эту заглушку
            _characterAttacker.Attack(new CancellationToken());
        }
    }
}