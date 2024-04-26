using System;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Common.Forms.MainMenu
{
    public class MainMenuSettingsFormPresenter : PresenterBase
    {
        private readonly IMainMenuSettingsFormView _view;
        private readonly IFormService _formService;

        public MainMenuSettingsFormPresenter(
            IMainMenuSettingsFormView view, 
            IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }
        
        public override void Enable()
        {
            _view.MainMenuHudButtonView.AddClickListener(ShowMainMenuForm);
        }

        public override void Disable()
        {
            _view.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuForm);
        }

        private void ShowMainMenuForm()
        {
            _formService.Show<MainMenuHudFormView>();
        }
    }
}