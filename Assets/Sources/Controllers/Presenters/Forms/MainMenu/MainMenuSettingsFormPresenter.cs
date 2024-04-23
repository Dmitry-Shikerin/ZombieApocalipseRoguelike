using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Forms.MainMenu
{
    public class MainMenuSettingsFormPresenter : PresenterBase
    {
        private readonly IMainMenuSettingsFormView _mainMenuSettingsFormView;
        private readonly IViewFormService _viewFormService;

        public MainMenuSettingsFormPresenter(IViewFormService viewFormService,
            IMainMenuSettingsFormView mainMenuSettingsFormView)
        {
            _mainMenuSettingsFormView = mainMenuSettingsFormView ??
                                        throw new ArgumentNullException(nameof(mainMenuSettingsFormView));
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
        }

        public override void Enable() =>
            _mainMenuSettingsFormView.MainMenuHudButtonView.AddClickListener(ShowMainMenuHudForm);

        public override void Disable() =>
            _mainMenuSettingsFormView.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuHudForm);

        private void ShowMainMenuHudForm() =>
            _viewFormService.Show<MainMenuHudFormView>();
    }
}