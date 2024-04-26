using System;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu;
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
        private readonly AuthorizationFormPresenterFactory _authorizationFormPresenterFactory;
        private readonly LeaderboardFormPresenterFactory _leaderboardFormPresenterFactory;
        private readonly MainMenuSettingFormPresenterFactory _leaderboardSettingFormPresenterFactory;
        private readonly MainMenuHudFormViewPresenterFactory _mainMenuHudFormViewPresenterFactory;

        public MainMenuFormServiceFactory(
            FormService formService,
            MainMenuHud mainMenuHud,
            AuthorizationFormPresenterFactory authorizationFormPresenterFactory,
            LeaderboardFormPresenterFactory leaderboardFormPresenterFactory,
            MainMenuSettingFormPresenterFactory leaderboardSettingFormPresenterFactory,
            MainMenuHudFormViewPresenterFactory mainMenuHudFormViewPresenterFactory)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _authorizationFormPresenterFactory = authorizationFormPresenterFactory ?? throw new ArgumentNullException(nameof(authorizationFormPresenterFactory));
            _leaderboardFormPresenterFactory = leaderboardFormPresenterFactory ?? throw new ArgumentNullException(nameof(leaderboardFormPresenterFactory));
            _leaderboardSettingFormPresenterFactory = leaderboardSettingFormPresenterFactory ?? throw new ArgumentNullException(nameof(leaderboardSettingFormPresenterFactory));
            _mainMenuHudFormViewPresenterFactory = mainMenuHudFormViewPresenterFactory ?? throw new ArgumentNullException(nameof(mainMenuHudFormViewPresenterFactory));
        }

        public IFormService Create()
        {
            Form<AuthorizationFormView, AuthorizationFormPresenter> authorizationForm =
                new Form<AuthorizationFormView, AuthorizationFormPresenter>(
                    _authorizationFormPresenterFactory.Create, _mainMenuHud.AuthorizationFormView);
            _formService.Add(authorizationForm);
            
            Form<LeaderboardFormView, LeaderboardFormPresenter> leaderboardForm =
                new Form<LeaderboardFormView, LeaderboardFormPresenter>(
                    _leaderboardFormPresenterFactory.Create, _mainMenuHud.LeaderboardFormView);
            _formService.Add(leaderboardForm);
            
            Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter> leaderboardSettingForm =
                new Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter>(
                    _leaderboardSettingFormPresenterFactory.Create, _mainMenuHud.MainMenuSettingsFormView);
            _formService.Add(leaderboardSettingForm);
            
            Form<MainMenuHudFormView, MainMenuHudFormPresenter> mainMenuHudForm =
                new Form<MainMenuHudFormView, MainMenuHudFormPresenter>(
                    _mainMenuHudFormViewPresenterFactory.Create, _mainMenuHud.MainMenuHudFormView);
            _formService.Add(mainMenuHudForm);
            
            return _formService;
        }
    }
}