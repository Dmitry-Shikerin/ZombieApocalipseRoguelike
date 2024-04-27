using System;
using Sources.Controllers.Common.Forms;
using Sources.Controllers.Presenters.Forms.Gameplay;
using Sources.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.Infrastructure.Services.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.Common;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.Forms.Gameplay.Tutorials;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class MVPGameplayFormServiceFactory
    {
        private readonly ImvpFormService _imvpFormService;
        private readonly GameplayHud _gameplayHud;
        private readonly GameOverFormPresenterFactory _gameOverFormPresenterFactory;
        private readonly GameplaySettingsFormPresenterFactory _gameplaySettingsFormPresenterFactory;
        private readonly HudFormPresenterFactory _hudFormPresenterFactory;
        private readonly LevelCompletedFormPresenterFactory _levelCompletedFormPresenterFactory;
        private readonly PauseFormPresenterFactory _pauseFormPresenterFactory;
        private readonly GreetingTutorialFormPresenterFactory _greetingTutorialFormPresenterFactory;
        private readonly UpgradeFormPresenterFactory _upgradeFormPresenterFactory;

        public MVPGameplayFormServiceFactory(
            ImvpFormService imvpFormService,
            GameplayHud gameplayHud,
            GameOverFormPresenterFactory gameOverFormPresenterFactory,
            GameplaySettingsFormPresenterFactory gameplaySettingsFormPresenterFactory,
            HudFormPresenterFactory hudFormPresenterFactory,
            LevelCompletedFormPresenterFactory levelCompletedFormPresenterFactory,
            PauseFormPresenterFactory pauseFormPresenterFactory,
            GreetingTutorialFormPresenterFactory greetingTutorialFormPresenterFactory,
            UpgradeFormPresenterFactory upgradeFormPresenterFactory)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _gameplayHud = gameplayHud ? gameplayHud : 
                throw new ArgumentNullException(nameof(gameplayHud));
            _gameOverFormPresenterFactory = gameOverFormPresenterFactory ??
                                            throw new ArgumentNullException(nameof(gameOverFormPresenterFactory));
            _gameplaySettingsFormPresenterFactory = 
                gameplaySettingsFormPresenterFactory ?? 
                throw new ArgumentNullException(nameof(gameplaySettingsFormPresenterFactory));
            _hudFormPresenterFactory = hudFormPresenterFactory ?? 
                                       throw new ArgumentNullException(nameof(hudFormPresenterFactory));
            _levelCompletedFormPresenterFactory = 
                levelCompletedFormPresenterFactory ?? 
                throw new ArgumentNullException(nameof(levelCompletedFormPresenterFactory));
            _pauseFormPresenterFactory = pauseFormPresenterFactory ?? 
                                         throw new ArgumentNullException(nameof(pauseFormPresenterFactory));
            _greetingTutorialFormPresenterFactory = greetingTutorialFormPresenterFactory ??
                                            throw new ArgumentNullException(nameof(greetingTutorialFormPresenterFactory));
            _upgradeFormPresenterFactory = upgradeFormPresenterFactory ?? 
                                           throw new ArgumentNullException(nameof(upgradeFormPresenterFactory));
        }

        public IMVPFormService Create()
        {
            // Form<HudFormView, HudFormPresenter> hudForm = 
            //     new Form<HudFormView, HudFormPresenter>(
            //     _hudFormPresenterFactory.Create, _gameplayHud.HudFormView);
            // _imvpFormService.Add(hudForm);
            //
            // Form<GameOverFormView, GameOverFormPresenter> gameOverForm =
            //     new Form<GameOverFormView, GameOverFormPresenter>(
            //         _gameOverFormPresenterFactory.Create, _gameplayHud.GameOverFormView);
            // _imvpFormService.Add(gameOverForm);
            //
            // Form<LevelCompletedFormView, LevelCompletedFormPresenter> levelCompletedForm =
            //     new Form<LevelCompletedFormView, LevelCompletedFormPresenter>(
            //         _levelCompletedFormPresenterFactory.Create, _gameplayHud.LevelCompletedFormView);
            // _imvpFormService.Add(levelCompletedForm);
            //
            // Form<GameplaySettingsFormView, GameplaySettingsFormPresenter> gameplaySettingsForm =
            //     new Form<GameplaySettingsFormView, GameplaySettingsFormPresenter>(
            //         _gameplaySettingsFormPresenterFactory.Create, _gameplayHud.GameplaySettingsFormView);
            // _imvpFormService.Add(gameplaySettingsForm);
            //
            // Form<PauseFormView, PauseFormPresenter> pauseForm =
            //     new Form<PauseFormView, PauseFormPresenter>(
            //         _pauseFormPresenterFactory.Create, _gameplayHud.PauseFormView);
            // _imvpFormService.Add(pauseForm);
            //
            // Form<GreetingGreetingTutorialFormView, GreetingTutorialFormPresenter> tutorialForm =
            //     new Form<GreetingGreetingTutorialFormView, GreetingTutorialFormPresenter>(
            //         _greetingTutorialFormPresenterFactory.Create, _gameplayHud.GreetingGreetingTutorialFormView);
            // _imvpFormService.Add(tutorialForm);
            //
            // Form<UpgradeFormView, UpgradeFormPresenter> upgradeForm =
            //     new Form<UpgradeFormView, UpgradeFormPresenter>(
            //         _upgradeFormPresenterFactory.Create, _gameplayHud.UpgradeFormView);
            // _imvpFormService.Add(upgradeForm);
            
            return _imvpFormService;
        }
    }
}