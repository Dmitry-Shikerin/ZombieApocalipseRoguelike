using System;
using JetBrains.Annotations;
using Sources.DomainInterfaces.Models.Characters;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.LoadServices;

namespace Sources.Infrastructure.Services.GameOvers
{
    public class GameOverService : IGameOverService
    {
        private readonly IFormService _formService;
        private readonly ILoadService _loadService;
        private readonly IInterstitialAdService _interstitialAdService;
        private ICharacterHealth _characterHealth;
        private bool _isGameOver;

        public GameOverService(
            IFormService formService,
            ILoadService loadService,
            IInterstitialAdService interstitialAdService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _interstitialAdService = interstitialAdService ?? throw new ArgumentNullException(nameof(interstitialAdService));
        }

        public void Enter(object payload = null)
        {
            if (_characterHealth == null)
                throw new ArgumentNullException(nameof(_characterHealth));

            _characterHealth.CharacterDie += OnCharacterDie;
        }

        public void Exit() =>
            _characterHealth.CharacterDie -= OnCharacterDie;

        public void Register(ICharacterHealth characterHealth) =>
            _characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));

        private void OnCharacterDie()
        {
            if (_isGameOver)
                return;
            
            _isGameOver = true;
            _loadService.ClearAll();
            _formService.Show(FormId.GameOver);
            _interstitialAdService.ShowInterstitial();
        }
    }
}