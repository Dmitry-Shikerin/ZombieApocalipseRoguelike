using System;
using JetBrains.Annotations;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;
using UnityEngine;

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

        public override void Enable() =>
            _mainMenuHudFormView.SettingsButtonView.AddClickListener(ShowSettingsForm);

        public override void Disable() =>
            _mainMenuHudFormView.SettingsButtonView.RemoveClickListener(ShowSettingsForm);

        private void ShowSettingsForm()
        {
            Debug.Log("showSettingFormView");
            _formService.Show<SettingsFormView>();
        }
    }
}