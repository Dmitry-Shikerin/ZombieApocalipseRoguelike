﻿using System;
using Sources.Controllers.ModelViews.Forms.Gameplay;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Infrastructure.Factories.Domain.Forms.Gameplay;
using Sources.Infrastructure.Services.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UI.Huds;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class GameplayFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly GameOverFormFactory _gameOverFormFactory;
        private readonly GameplayHudFormFactory _gameplayHudFormFactory;
        private readonly GameplaySettingFormFactory _gameplaySettingFormFactory;
        private readonly LevelCompletedFormFactory _levelCompletedFormFactory;
        private readonly PauseFormFactory _pauseFormFactory;
        private readonly TutorialFormFactory _tutorialFormFactory;
        private readonly UpgradeFormFactory _upgradeFormFactory;
        private readonly IBindableViewBuilder<GameplayHudFormViewModel, GameplayHudForm> _gameplayHudFormBuilder;
        private readonly IBindableViewBuilder<PauseFormViewModel, PauseForm> _pauseFormBuilder;
        private readonly IBindableViewBuilder<GameplaySettingsFormViewModel, GameplaySettingsForm> _gameplaySettingsFormBuilder;
        private readonly IBindableViewBuilder<UpgradeFormViewModel, UpgradeForm> _upgradeFormBuilder;
        private readonly GameplayHud _gameplayHud;

        public GameplayFormServiceFactory(
            FormService formService,
            GameplayHud gameplayHud,
            GameOverFormFactory gameOverFormFactory,
            GameplayHudFormFactory gameplayHudFormFactory,
            GameplaySettingFormFactory gameplaySettingFormFactory,
            LevelCompletedFormFactory levelCompletedFormFactory,
            PauseFormFactory pauseFormFactory,
            TutorialFormFactory tutorialFormFactory,
            UpgradeFormFactory upgradeFormFactory,
            IBindableViewBuilder<GameplayHudFormViewModel, GameplayHudForm> gameplayHudFormBuilder,
            IBindableViewBuilder<PauseFormViewModel, PauseForm> pauseFormBuilder,
            IBindableViewBuilder<GameplaySettingsFormViewModel, GameplaySettingsForm> gameplaySettingsFormBuilder,
            IBindableViewBuilder<UpgradeFormViewModel, UpgradeForm> upgradeFormBuilder)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _gameOverFormFactory = gameOverFormFactory ?? throw new ArgumentNullException(nameof(gameOverFormFactory));
            _gameplayHudFormFactory = gameplayHudFormFactory ?? throw new ArgumentNullException(nameof(gameplayHudFormFactory));
            _gameplaySettingFormFactory = gameplaySettingFormFactory ?? throw new ArgumentNullException(nameof(gameplaySettingFormFactory));
            _levelCompletedFormFactory = levelCompletedFormFactory ?? throw new ArgumentNullException(nameof(levelCompletedFormFactory));
            _pauseFormFactory = pauseFormFactory ?? throw new ArgumentNullException(nameof(pauseFormFactory));
            _tutorialFormFactory = tutorialFormFactory ?? throw new ArgumentNullException(nameof(tutorialFormFactory));
            _upgradeFormFactory = upgradeFormFactory ?? throw new ArgumentNullException(nameof(upgradeFormFactory));
            _gameplayHudFormBuilder = gameplayHudFormBuilder ?? throw new ArgumentNullException(nameof(gameplayHudFormBuilder));
            _pauseFormBuilder = pauseFormBuilder ?? throw new ArgumentNullException(nameof(pauseFormBuilder));
            _gameplaySettingsFormBuilder = gameplaySettingsFormBuilder ?? throw new ArgumentNullException(nameof(gameplaySettingsFormBuilder));
            _upgradeFormBuilder = upgradeFormBuilder ?? throw new ArgumentNullException(nameof(upgradeFormBuilder));
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
        }

        public IFormService Create()
        {
            GameOverForm gameOverForm = _gameOverFormFactory.Create();
            
            GameplayHudForm gameplayHudForm = _gameplayHudFormFactory.Create();
            _gameplayHudFormBuilder.Build(gameplayHudForm, _gameplayHud.GameplayHudFormBindableView);
            _formService.Register<GameplayHudForm>(gameplayHudForm);
            
            GameplaySettingsForm gameplaySettingForm = _gameplaySettingFormFactory.Create();
            _gameplaySettingsFormBuilder.Build(gameplaySettingForm, _gameplayHud.GameplaySettingsFormBindableView);
            _formService.Register<GameplaySettingsForm>(gameplaySettingForm);
            
            LevelCompletedForm levelCompletedForm = _levelCompletedFormFactory.Create();
            
            PauseForm pauseForm = _pauseFormFactory.Create();
            _pauseFormBuilder.Build(pauseForm, _gameplayHud.PauseFormBindableView);
            _formService.Register<PauseForm>(pauseForm);
            
            TutorialForm tutorialForm = _tutorialFormFactory.Create();
            
            UpgradeForm upgradeForm = _upgradeFormFactory.Create();
            _upgradeFormBuilder.Build(upgradeForm, _gameplayHud.UpgradeFormBindableView);
            _formService.Register<UpgradeForm>(upgradeForm);
            
            return _formService;
        }
    }
}