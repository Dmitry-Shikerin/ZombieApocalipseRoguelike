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
        private readonly IFormService _formService;

        public MainMenuSettingsFormPresenter(IFormService formService,
            IMainMenuSettingsFormView mainMenuSettingsFormView)
        {
            _mainMenuSettingsFormView = mainMenuSettingsFormView ??
                                        throw new ArgumentNullException(nameof(mainMenuSettingsFormView));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable() =>
            _mainMenuSettingsFormView.MainMenuHudButtonView.AddClickListener(ShowMainMenuHudForm);

        public override void Disable() =>
            _mainMenuSettingsFormView.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuHudForm);

        private void ShowMainMenuHudForm() =>
            _formService.Show<MainMenuHudFormView>();
    }
}