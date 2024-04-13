using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Services.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.Common;
using Sources.Presentations.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class GameplayFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly GameplayHud _gameplayHud;
        private readonly PauseFormPresenterFactory _pauseFormPresenterFactory;
        private readonly HudFormPresenterFactory _hudFormPresenterFactory;
        private readonly UpgradeFormPresenterFactory _upgradeFormPresenterFactory;
        private readonly TutorialFormPresenterFactory _tutorialFormPresenterFactory;
        private readonly GameplaySettingsFormPresenterFactory _settingsFormPresenterFactory;
        private readonly GameOverFormPresenterFactory _gameOverFormPresenterFactory;
        private readonly LevelCompletedFormPresenterFactory _levelCompletedFormPresenterFactory;

        public GameplayFormServiceFactory(
            FormService formService,
            GameplayHud gameplayHud,
            PauseFormPresenterFactory pauseFormPresenterFactory,
            HudFormPresenterFactory hudFormPresenterFactory,
            UpgradeFormPresenterFactory upgradeFormPresenterFactory,
            TutorialFormPresenterFactory tutorialFormPresenterFactory,
            GameplaySettingsFormPresenterFactory settingsFormPresenterFactory,
            GameOverFormPresenterFactory gameOverFormPresenterFactory,
            LevelCompletedFormPresenterFactory levelCompletedFormPresenterFactory)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _pauseFormPresenterFactory = pauseFormPresenterFactory ?? 
                                         throw new ArgumentNullException(nameof(pauseFormPresenterFactory));
            _hudFormPresenterFactory = hudFormPresenterFactory ?? 
                                       throw new ArgumentNullException(nameof(hudFormPresenterFactory));
            _upgradeFormPresenterFactory = upgradeFormPresenterFactory ??
                                           throw new ArgumentNullException(nameof(upgradeFormPresenterFactory));
            _tutorialFormPresenterFactory = tutorialFormPresenterFactory ??
                                            throw new ArgumentNullException(nameof(tutorialFormPresenterFactory));
            _settingsFormPresenterFactory = settingsFormPresenterFactory ??
                                            throw new ArgumentNullException(nameof(settingsFormPresenterFactory));
            _gameOverFormPresenterFactory = gameOverFormPresenterFactory ??
                                            throw new ArgumentNullException(nameof(gameOverFormPresenterFactory));
            _levelCompletedFormPresenterFactory = levelCompletedFormPresenterFactory ??
                                                  throw new ArgumentNullException(nameof(levelCompletedFormPresenterFactory));
        }

        public IFormService Create()
        {
            Form<PauseFormView, PauseFormPresenter> pauseForm = 
                new Form<PauseFormView, PauseFormPresenter>(
                    _pauseFormPresenterFactory.Create, _gameplayHud.PauseFormView);
            
            _formService.Add(pauseForm);

            Form<HudFormView, HudFormPresenter> hudForm =
                new Form<HudFormView, HudFormPresenter>(
                    _hudFormPresenterFactory.Create, _gameplayHud.HudFormView);
            
            _formService.Add(hudForm);

            Form<UpgradeFormView, UpgradeFormPresenter> upgradeForm =
                new Form<UpgradeFormView, UpgradeFormPresenter>(
                    _upgradeFormPresenterFactory.Create, _gameplayHud.UpgradeFormView);
            
            _formService.Add(upgradeForm);

            Form<TutorialFormView, TutorialFormPresenter> tutorialForm =
                new Form<TutorialFormView, TutorialFormPresenter>(
                    _tutorialFormPresenterFactory.Create, _gameplayHud.TutorialFormView);
            
            _formService.Add(tutorialForm);

            Form<GameplaySettingsFormView, GameplaySettingsFormPresenter> settingsForm =
                new Form<GameplaySettingsFormView, GameplaySettingsFormPresenter>(
                    _settingsFormPresenterFactory.Create, _gameplayHud.SettingsFormView);
            
            _formService.Add(settingsForm);

            Form<GameOverFormView, GameOverFormPresenter> gameOverForm =
                new Form<GameOverFormView, GameOverFormPresenter>(_gameOverFormPresenterFactory.Create,
                    _gameplayHud.GameOverFormView);
            
            _formService.Add(gameOverForm);

            Form<LevelCompletedFormView, LevelCompletedFormPresenter> levelCompletedForm =
                new Form<LevelCompletedFormView, LevelCompletedFormPresenter>(
                    _levelCompletedFormPresenterFactory.Create,
                    _gameplayHud.LevelCompletedFormView);
            
            _formService.Add(levelCompletedForm);
            
            return _formService;
        }
    }
}