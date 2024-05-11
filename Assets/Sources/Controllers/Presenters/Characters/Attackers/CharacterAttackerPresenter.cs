using System;
using System.Threading;
using Sources.Controllers.Common;
using Sources.Domain.Models.Characters.Attackers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Controllers.Presenters.Characters.Attackers
{
    public class CharacterAttackerPresenter : PresenterBase
    {
        private readonly CharacterAttacker _characterAttacker;
        private readonly ICharacterAttackerView _characterAttackerView;
        private readonly IInputService _inputService;
        private readonly IUpdateRegister _updateRegister;

        private CancellationTokenSource _cancellationTokenSource;

        public CharacterAttackerPresenter(
            CharacterAttacker characterAttacker,
            ICharacterAttackerView characterAttackerView,
            IInputService inputService,
            IUpdateRegister updateRegister)
        {
            _characterAttacker = characterAttacker ?? throw new ArgumentNullException(nameof(characterAttacker));
            _characterAttackerView = characterAttackerView ??
                                     throw new ArgumentNullException(nameof(characterAttackerView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _updateRegister.Register(OnUpdate);
        }

        public override void Disable()
        {
            _cancellationTokenSource.Cancel();
            _updateRegister.UnRegister(OnUpdate);
        }

        private void OnUpdate(float deltaTime)
        {
            if (_inputService.InputData.IsAttacking)
                _characterAttacker.Attack(_cancellationTokenSource.Token);
            else
                _characterAttacker.EndAttack();
        }
    }
}