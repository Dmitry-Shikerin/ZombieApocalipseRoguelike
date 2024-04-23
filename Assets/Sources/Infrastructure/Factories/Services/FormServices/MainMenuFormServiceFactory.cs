using System;
using Sources.Infrastructure.Services.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UI.Huds;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class MainMenuFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly MainMenuHud _mainMenuHud;

        public MainMenuFormServiceFactory(
            FormService formService,
            MainMenuHud mainMenuHud)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
        }

        public IFormService Create()
        {
            // Form<MainMenuHudFormView, MainMenuHudFormPresenter> mainMenuHudForm =
            //     new Form<MainMenuHudFormView, MainMenuHudFormPresenter>(
            //         _mainMenuHudFormPresenterFactory.Create, _mainMenuHud.MainMenuHudFormView);
            //
            // _formService.Add(mainMenuHudForm);
            //
            // Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter> settingsForm =
            //     new Form<MainMenuSettingsFormView, MainMenuSettingsFormPresenter>(
            //         _settingsFormPresenterFactory.Create, _mainMenuHud.SettingsFormView);
            //
            // _formService.Add(settingsForm);
            //
            // Form<LeaderBoardFormView, LeaderBoardFormPresenter> leaderBoardForm =
            //     new Form<LeaderBoardFormView, LeaderBoardFormPresenter>(
            //         _leaderBoardFormPresenterFactory.Create, _mainMenuHud.LeaderBoardFormView);
            //
            // _formService.Add(leaderBoardForm);

            return _formService;
        }
    }
}