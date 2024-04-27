using System;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.Controllers.Presenters.Forms.MainMenu;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu;
using Sources.Infrastructure.Services.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.Common;
using Sources.Presentations.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class MVPMainMenuFormServiceFactory
    {
        private readonly ImvpFormService _imvpFormService;
        private readonly MainMenuHud _mainMenuHud;
        private readonly AuthorizationFormPresenterFactory _authorizationFormPresenterFactory;
        private readonly LeaderboardFormPresenterFactory _leaderboardFormPresenterFactory;
        private readonly MainMenuSettingFormPresenterFactory _leaderboardSettingFormPresenterFactory;
        private readonly MainMenuHudFormViewPresenterFactory _mainMenuHudFormViewPresenterFactory;
        private readonly NewGameFormPresenterFactory _newGameFormPresenterFactory;
        private readonly WarningNewGameFormPresenterFactory _warningNewGameFormPresenterFactory;

        public MVPMainMenuFormServiceFactory(
            ImvpFormService imvpFormService,
            MainMenuHud mainMenuHud,
            AuthorizationFormPresenterFactory authorizationFormPresenterFactory,
            LeaderboardFormPresenterFactory leaderboardFormPresenterFactory,
            MainMenuSettingFormPresenterFactory leaderboardSettingFormPresenterFactory,
            MainMenuHudFormViewPresenterFactory mainMenuHudFormViewPresenterFactory,
            NewGameFormPresenterFactory newGameFormPresenterFactory,
            WarningNewGameFormPresenterFactory warningNewGameFormPresenterFactory)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _authorizationFormPresenterFactory = authorizationFormPresenterFactory ?? throw new ArgumentNullException(nameof(authorizationFormPresenterFactory));
            _leaderboardFormPresenterFactory = leaderboardFormPresenterFactory ?? throw new ArgumentNullException(nameof(leaderboardFormPresenterFactory));
            _leaderboardSettingFormPresenterFactory = leaderboardSettingFormPresenterFactory ?? throw new ArgumentNullException(nameof(leaderboardSettingFormPresenterFactory));
            _mainMenuHudFormViewPresenterFactory = mainMenuHudFormViewPresenterFactory ?? throw new ArgumentNullException(nameof(mainMenuHudFormViewPresenterFactory));
            _newGameFormPresenterFactory = newGameFormPresenterFactory ?? throw new ArgumentNullException(nameof(newGameFormPresenterFactory));
            _warningNewGameFormPresenterFactory = warningNewGameFormPresenterFactory ?? throw new ArgumentNullException(nameof(warningNewGameFormPresenterFactory));
        }

        public IMVPFormService Create()
        {
            // Form<AuthorizationFormView, AuthorizationFormPresenter> authorizationForm =
            //     new Form<AuthorizationFormView, AuthorizationFormPresenter>(
            //         _authorizationFormPresenterFactory.Create, _mainMenuHud.AuthorizationFormView);
            // _imvpFormService.Add(authorizationForm);
            //
            // Form<LeaderboardFormView, LeaderboardFormPresenter> leaderboardForm =
            //     new Form<LeaderboardFormView, LeaderboardFormPresenter>(
            //         _leaderboardFormPresenterFactory.Create, _mainMenuHud.LeaderboardFormView);
            // _imvpFormService.Add(leaderboardForm);
            //
            // Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter> leaderboardSettingForm =
            //     new Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter>(
            //         _leaderboardSettingFormPresenterFactory.Create, _mainMenuHud.MainMenuSettingsFormView);
            // _imvpFormService.Add(leaderboardSettingForm);
            //
            // Form<MainMenuHudFormView, MainMenuHudFormPresenter> mainMenuHudForm =
            //     new Form<MainMenuHudFormView, MainMenuHudFormPresenter>(
            //         _mainMenuHudFormViewPresenterFactory.Create, _mainMenuHud.UICollector);
            // _imvpFormService.Add(mainMenuHudForm);
            //
            // Form<NewGameFormView, NewGameFormPresenter> newGameForm = 
            //     new Form<NewGameFormView, NewGameFormPresenter>(
            //     _newGameFormPresenterFactory.Create, _mainMenuHud.NewGameFormView);
            // _imvpFormService.Add(newGameForm);
            //
            // var warningNewGameForm = new Form<WarningNewGameFormView, WarningNewGameFormPresenter>(
            //     _warningNewGameFormPresenterFactory.Create, _mainMenuHud.WarningNewGameFormView);
            // _imvpFormService.Add(warningNewGameForm);
            
            return _imvpFormService;
        }
    }
}