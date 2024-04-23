using System;
using JetBrains.Annotations;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Forms.MainMenu
{
    public class AuthorizationFormPresenter : PresenterBase
    {
        private readonly IViewFormService _viewFormService;
        private readonly IAuthorizationFormView _authorizationFormView;

        public AuthorizationFormPresenter(IViewFormService viewFormService, IAuthorizationFormView authorizationFormView)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
            _authorizationFormView = authorizationFormView ??
                                     throw new ArgumentNullException(nameof(authorizationFormView));
        }

        public override void Enable() =>
            _authorizationFormView.MainMenuHudButtonView.AddClickListener(ShowMainMenuHudForm);

        public override void Disable() =>
            _authorizationFormView.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuHudForm);

        private void ShowMainMenuHudForm() =>
            _viewFormService.Show<MainMenuHudFormView>();
    }
}