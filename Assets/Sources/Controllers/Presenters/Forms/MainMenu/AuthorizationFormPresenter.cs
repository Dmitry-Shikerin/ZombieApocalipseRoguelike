using System;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Common.Forms.MainMenu
{
    public class AuthorizationFormPresenter : PresenterBase
    {
        private readonly IAuthorizationFormView _view;
        private readonly IFormService _formService;

        public AuthorizationFormPresenter(
            IAuthorizationFormView view, 
            IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            _view.MainMenuHudButtonView.AddClickListener(ShowMainMenuHudForm);
        }

        public override void Disable()
        {
            _view.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuHudForm);
        }

        private void ShowMainMenuHudForm()
        {
            _formService.Show<MainMenuHudFormView>();
        }
    }
}