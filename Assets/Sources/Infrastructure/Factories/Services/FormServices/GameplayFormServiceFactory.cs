using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.Controllers.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.Forms.Common;
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
        private readonly SettingsFormPresenterFactory _settingsFormPresenterFactory;

        public GameplayFormServiceFactory(
            FormService formService,
            GameplayHud gameplayHud,
            PauseFormPresenterFactory pauseFormPresenterFactory,
            HudFormPresenterFactory hudFormPresenterFactory,
            UpgradeFormPresenterFactory upgradeFormPresenterFactory,
            TutorialFormPresenterFactory tutorialFormPresenterFactory,
            SettingsFormPresenterFactory settingsFormPresenterFactory)
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

            Form<SettingsFormView, SettingsFormPresenter> settingsForm =
                new Form<SettingsFormView, SettingsFormPresenter>(
                    _settingsFormPresenterFactory.Create, _gameplayHud.SettingsFormView);
            
            _formService.Add(settingsForm);
            
            return _formService;
        }
    }
}