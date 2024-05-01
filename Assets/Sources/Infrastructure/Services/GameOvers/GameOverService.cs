﻿using System;
using Sources.Domain.Models.Characters;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Services.GameOvers;

namespace Sources.Infrastructure.Services.GameOvers
{
    public class GameOverService : IGameOverService
    {
        private readonly IFormService _formService;
        private CharacterHealth _characterHealth;

        public GameOverService(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enter(object payload = null)
        {
            if (_characterHealth == null)
                throw new ArgumentNullException(nameof(_characterHealth));

            _characterHealth.HealthChanged += OnHealthChanged;
        }

        public void Exit()
        {
            _characterHealth.HealthChanged -= OnHealthChanged;
        }

        public void Register(CharacterHealth characterHealth) =>
            _characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));

        private void OnHealthChanged()
        {
            if(_characterHealth.CurrentHealth > 0)
                return;
            
            _formService.Show(FormId.GameOver);
        }
    }
}