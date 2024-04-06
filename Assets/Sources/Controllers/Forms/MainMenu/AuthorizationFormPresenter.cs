using System;
using Assets.Sources.InfastructureInterfaces.Services.Forms;
using JetBrains.Annotations;
using Sources.Controllers.Common;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Controllers.Forms.MainMenu
{
    public class AuthorizationFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly IAuthorizationFormView _authorizationFormView;

        public AuthorizationFormPresenter(IFormService formService, IAuthorizationFormView authorizationFormView)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _authorizationFormView = authorizationFormView ??
                                     throw new ArgumentNullException(nameof(authorizationFormView));
        }

        public override void Enable() =>
            _authorizationFormView.MainMenuHudButtonView.AddClickListener(ShowMainMenuHudForm);

        public override void Disable() =>
            _authorizationFormView.MainMenuHudButtonView.RemoveClickListener(ShowMainMenuHudForm);

        private void ShowMainMenuHudForm() =>
            _formService.Show<MainMenuHudFormView>();
    }
}