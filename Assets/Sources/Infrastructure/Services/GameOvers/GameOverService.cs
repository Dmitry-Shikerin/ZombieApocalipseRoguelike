using System;
using Sources.Domain.Models.Characters;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.LoadServices;

namespace Sources.Infrastructure.Services.GameOvers
{
    public class GameOverService : IGameOverService
    {
        private readonly IFormService _formService;
        private readonly ILoadService _loadService;
        private CharacterHealth _characterHealth;

        private bool _isGameOver;

        public GameOverService(
            IFormService formService,
            ILoadService loadService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public void Enter(object payload = null)
        {
            if (_characterHealth == null)
                throw new ArgumentNullException(nameof(_characterHealth));

            _characterHealth.HealthChanged += OnHealthChanged;
        }

        public void Exit() =>
            _characterHealth.HealthChanged -= OnHealthChanged;

        public void Register(CharacterHealth characterHealth) =>
            _characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));

        private void OnHealthChanged()
        {
            if (_characterHealth.CurrentHealth > 0)
                return;

            if (_isGameOver)
                return;

            _loadService.ClearAll();
            _formService.Show(FormId.GameOver);
            _isGameOver = true;
        }
    }
}