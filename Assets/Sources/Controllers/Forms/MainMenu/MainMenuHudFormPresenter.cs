using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Forms.MainMenu
{
    public class MainMenuHudFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly IMainMenuHudFormView _mainMenuHudFormView;

        public MainMenuHudFormPresenter(IFormService formService, IMainMenuHudFormView mainMenuHudFormView)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _mainMenuHudFormView = mainMenuHudFormView ?? throw new ArgumentNullException(nameof(mainMenuHudFormView));
        }

        public override void Enable()
        {
            _mainMenuHudFormView.SettingsButtonView.AddClickListener(ShowSettingsForm);
            _mainMenuHudFormView.LeaderBoardButtonView.AddClickListener(ShowLeaderBoardForm);
        }

        public override void Disable()
        {
            _mainMenuHudFormView.SettingsButtonView.RemoveClickListener(ShowSettingsForm);
            _mainMenuHudFormView.LeaderBoardButtonView.RemoveClickListener(ShowLeaderBoardForm);
        }

        private void ShowSettingsForm() =>
            _formService.Show<MainMenuSettingsFormView>();

        private void ShowAuthorizationForm() =>
            _formService.Show<AuthorizationFormView>();

        private void ShowLeaderBoardForm() =>
            _formService.Show<LeaderBoardFormView>();
    }
}