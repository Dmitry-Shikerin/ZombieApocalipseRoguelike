using System;
using Assets.Sources.InfastructureInterfaces.Services.Forms;
using JetBrains.Annotations;
using Sources.Controllers.Common;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Forms.MainMenu
{
    public class SettingsFormPresenter : PresenterBase
    {
        private readonly ISettingsFormView _settingsFormView;
        private readonly IFormService _formService;

        public SettingsFormPresenter(IFormService formService, ISettingsFormView settingsFormView)
        {
            _settingsFormView = settingsFormView ?? throw new ArgumentNullException(nameof(settingsFormView));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable() =>
            _settingsFormView.MainMenuHudFormButtonView.AddClickListener(ShowMainMenuHudForm);

        public override void Disable() =>
            _settingsFormView.MainMenuHudFormButtonView.RemoveClickListener(ShowMainMenuHudForm);

        private void ShowMainMenuHudForm() =>
            _formService.Show<MainMenuHudFormView>();
    }
}