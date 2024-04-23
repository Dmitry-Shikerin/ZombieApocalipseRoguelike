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
        private readonly ViewViewFormService _viewViewFormService;
        private readonly MainMenuHud _mainMenuHud;
        private readonly MainMenuHudFormPresenterFactory _mainMenuHudFormPresenterFactory;
        private readonly MainMenuSettingsFormPresenterFactory _settingsFormPresenterFactory;
        private readonly AuthorizationFormPresenterFactory _authorizationFormPresenterFactory;
        private readonly LeaderBoardFormPresenterFactory _leaderBoardFormPresenterFactory;

        public MainMenuFormServiceFactory(
            ViewViewFormService viewViewFormService,
            MainMenuHud mainMenuHud,
            MainMenuHudFormPresenterFactory mainMenuHudFormPresenterFactory,
            MainMenuSettingsFormPresenterFactory settingsFormPresenterFactory,
            AuthorizationFormPresenterFactory authorizationFormPresenterFactory,
            LeaderBoardFormPresenterFactory leaderBoardFormPresenterFactory)
        {
            _viewViewFormService = viewViewFormService ?? throw new ArgumentNullException(nameof(viewViewFormService));
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

        public IViewFormService Create()
        {
            Form<MainMenuHudFormView, MainMenuHudFormPresenter> mainMenuHudForm =
                new Form<MainMenuHudFormView, MainMenuHudFormPresenter>(
                    _mainMenuHudFormPresenterFactory.Create, _mainMenuHud.MainMenuHudFormView);
            
            _viewViewFormService.Add(mainMenuHudForm);

            Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter> settingsForm =
                new Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter>(
                    _settingsFormPresenterFactory.Create, _mainMenuHud.SettingsFormView);
            
            _viewViewFormService.Add(settingsForm);

            Form<AuthorizationFormView, AuthorizationFormPresenter> authorizationForm =
                new Form<AuthorizationFormView, AuthorizationFormPresenter>(
                    _authorizationFormPresenterFactory.Create, _mainMenuHud.AuthorizationFormView);
            
            _viewViewFormService.Add(authorizationForm);

            Form<LeaderBoardFormView, LeaderBoardFormPresenter> leaderBoardForm =
                new Form<LeaderBoardFormView, LeaderBoardFormPresenter>(
                    _leaderBoardFormPresenterFactory.Create, _mainMenuHud.LeaderBoardFormView);
            
            _viewViewFormService.Add(leaderBoardForm);

            return _viewViewFormService;
        }
    }
}