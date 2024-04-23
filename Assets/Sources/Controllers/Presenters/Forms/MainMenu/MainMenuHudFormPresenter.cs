using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Forms.MainMenu
{
    public class MainMenuHudFormPresenter : PresenterBase
    {
        private readonly IViewFormService _viewFormService;
        private readonly IMainMenuHudFormView _mainMenuHudFormView;

        public MainMenuHudFormPresenter(IViewFormService viewFormService, IMainMenuHudFormView mainMenuHudFormView)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
            _mainMenuHudFormView = mainMenuHudFormView ?? throw new ArgumentNullException(nameof(mainMenuHudFormView));
        }

        public override void Enable()
        {
            _mainMenuHudFormView.SettingsButtonView.AddClickListener(ShowSettingsForm);
            _mainMenuHudFormView.AuthorizationButtonView.AddClickListener(ShowAuthorizationForm);
            _mainMenuHudFormView.LeaderBoardButtonView.AddClickListener(ShowLeaderBoardForm);
        }

        public override void Disable()
        {
            _mainMenuHudFormView.SettingsButtonView.RemoveClickListener(ShowSettingsForm);
            _mainMenuHudFormView.AuthorizationButtonView.RemoveClickListener(ShowAuthorizationForm);
            _mainMenuHudFormView.LeaderBoardButtonView.RemoveClickListener(ShowLeaderBoardForm);
        }

        private void ShowSettingsForm() =>
            _viewFormService.Show<MainMenuSettingsFormView>();

        private void ShowAuthorizationForm() =>
            _viewFormService.Show<AuthorizationFormView>();

        private void ShowLeaderBoardForm() =>
            _viewFormService.Show<LeaderBoardFormView>();
    }
}