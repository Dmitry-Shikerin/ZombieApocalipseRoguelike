using System;
using Sources.Controllers.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.Forms.MainMenu;
using Sources.Infrastructure.Services.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.Common;
using Sources.Presentations.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class MainMenuFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly MainMenuHud _mainMenuHud;
        private readonly MainMenuHudFormPresenterFactory _mainMenuHudFormPresenterFactory;
        private readonly MainMenuSettingsFormPresenterFactory _settingsFormPresenterFactory;
        private readonly AuthorizationFormPresenterFactory _authorizationFormPresenterFactory;
        private readonly LeaderBoardFormPresenterFactory _leaderBoardFormPresenterFactory;

        public MainMenuFormServiceFactory(
            FormService formService,
            MainMenuHud mainMenuHud,
            MainMenuHudFormPresenterFactory mainMenuHudFormPresenterFactory,
            MainMenuSettingsFormPresenterFactory settingsFormPresenterFactory,
            AuthorizationFormPresenterFactory authorizationFormPresenterFactory,
            LeaderBoardFormPresenterFactory leaderBoardFormPresenterFactory)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _mainMenuHudFormPresenterFactory = mainMenuHudFormPresenterFactory ??
                                               throw new ArgumentNullException(nameof(mainMenuHudFormPresenterFactory));
            _settingsFormPresenterFactory = settingsFormPresenterFactory ??
                                            throw new ArgumentNullException(nameof(settingsFormPresenterFactory));
            _authorizationFormPresenterFactory = authorizationFormPresenterFactory ??
                                                 throw new ArgumentNullException(nameof(authorizationFormPresenterFactory));
            _leaderBoardFormPresenterFactory = leaderBoardFormPresenterFactory ??
                                               throw new ArgumentNullException(nameof(leaderBoardFormPresenterFactory));
        }

        public IFormService Create()
        {
            Form<MainMenuHudFormView, MainMenuHudFormPresenter> mainMenuHudForm =
                new Form<MainMenuHudFormView, MainMenuHudFormPresenter>(
                    _mainMenuHudFormPresenterFactory.Create, _mainMenuHud.MainMenuHudFormView);
            
            _formService.Add(mainMenuHudForm);

            Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter> settingsForm =
                new Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter>(
                    _settingsFormPresenterFactory.Create, _mainMenuHud.SettingsFormView);
            
            _formService.Add(settingsForm);

            Form<LeaderBoardFormView, LeaderBoardFormPresenter> leaderBoardForm =
                new Form<LeaderBoardFormView, LeaderBoardFormPresenter>(
                    _leaderBoardFormPresenterFactory.Create, _mainMenuHud.LeaderBoardFormView);
            
            _formService.Add(leaderBoardForm);

            return _formService;
        }
    }
}