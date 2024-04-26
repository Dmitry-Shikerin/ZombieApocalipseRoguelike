using System;
using Sources.Controllers.Common.Forms;
using Sources.Controllers.Presenters.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay;
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
        private readonly GameOverFormPresenterFactory _gameOverFormPresenterFactory;
        private readonly GameplaySettingsFormPresenterFactory _gameplaySettingsFormPresenterFactory;
        private readonly HudFormPresenterFactory _hudFormPresenterFactory;
        private readonly LevelCompletedFormPresenterFactory _levelCompletedFormPresenterFactory;
        private readonly PauseFormPresenterFactory _pauseFormPresenterFactory;
        private readonly TutorialFormPresenterFactory _tutorialFormPresenterFactory;
        private readonly UpgradeFormPresenterFactory _upgradeFormPresenterFactory;

        public GameplayFormServiceFactory(
            FormService formService,
            GameplayHud gameplayHud,
            GameOverFormPresenterFactory gameOverFormPresenterFactory,
            GameplaySettingsFormPresenterFactory gameplaySettingsFormPresenterFactory,
            HudFormPresenterFactory hudFormPresenterFactory,
            LevelCompletedFormPresenterFactory levelCompletedFormPresenterFactory,
            PauseFormPresenterFactory pauseFormPresenterFactory,
            TutorialFormPresenterFactory tutorialFormPresenterFactory,
            UpgradeFormPresenterFactory upgradeFormPresenterFactory)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _gameOverFormPresenterFactory = gameOverFormPresenterFactory ?? throw new ArgumentNullException(nameof(gameOverFormPresenterFactory));
            _gameplaySettingsFormPresenterFactory = gameplaySettingsFormPresenterFactory ?? throw new ArgumentNullException(nameof(gameplaySettingsFormPresenterFactory));
            _hudFormPresenterFactory = hudFormPresenterFactory ?? throw new ArgumentNullException(nameof(hudFormPresenterFactory));
            _levelCompletedFormPresenterFactory = levelCompletedFormPresenterFactory ?? throw new ArgumentNullException(nameof(levelCompletedFormPresenterFactory));
            _pauseFormPresenterFactory = pauseFormPresenterFactory ?? throw new ArgumentNullException(nameof(pauseFormPresenterFactory));
            _tutorialFormPresenterFactory = tutorialFormPresenterFactory ?? throw new ArgumentNullException(nameof(tutorialFormPresenterFactory));
            _upgradeFormPresenterFactory = upgradeFormPresenterFactory ?? throw new ArgumentNullException(nameof(upgradeFormPresenterFactory));
        }

        public IFormService Create()
        {
            Form<HudFormView, HudFormPresenter> hudForm = 
                new Form<HudFormView, HudFormPresenter>(
                _hudFormPresenterFactory.Create, _gameplayHud.HudFormView);
            _formService.Add(hudForm);
            
            Form<GameOverFormView, GameOverFormPresenter> gameOverForm =
                new Form<GameOverFormView, GameOverFormPresenter>(
                    _gameOverFormPresenterFactory.Create, _gameplayHud.GameOverFormView);
            _formService.Add(gameOverForm);
            
            Form<LevelCompletedFormView, LevelCompletedFormPresenter> levelCompletedForm =
                new Form<LevelCompletedFormView, LevelCompletedFormPresenter>(
                    _levelCompletedFormPresenterFactory.Create, _gameplayHud.LevelCompletedFormView);
            _formService.Add(levelCompletedForm);
            
            Form<GameplaySettingsFormView, GameplaySettingsFormPresenter> gameplaySettingsForm =
                new Form<GameplaySettingsFormView, GameplaySettingsFormPresenter>(
                    _gameplaySettingsFormPresenterFactory.Create, _gameplayHud.GameplaySettingsFormView);
            _formService.Add(gameplaySettingsForm);
            
            Form<PauseFormView, PauseFormPresenter> pauseForm =
                new Form<PauseFormView, PauseFormPresenter>(
                    _pauseFormPresenterFactory.Create, _gameplayHud.PauseFormView);
            _formService.Add(pauseForm);
            
            Form<TutorialFormView, TutorialFormPresenter> tutorialForm =
                new Form<TutorialFormView, TutorialFormPresenter>(
                    _tutorialFormPresenterFactory.Create, _gameplayHud.TutorialFormView);
            _formService.Add(tutorialForm);
            
            Form<UpgradeFormView, UpgradeFormPresenter> upgradeForm =
                new Form<UpgradeFormView, UpgradeFormPresenter>(
                    _upgradeFormPresenterFactory.Create, _gameplayHud.UpgradeFormView);
            _formService.Add(upgradeForm);
            
            return _formService;
        }
    }
}