using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Forms.MainMenu
{
    public class AuthorizationFormPresenterFactory
    {
        private readonly IFormService _formService;

        public AuthorizationFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public AuthorizationFormPresenter Create(IAuthorizationFormView authorizationFormView)
        {
            if (authorizationFormView == null)
                throw new ArgumentNullException(nameof(authorizationFormView));

            return new AuthorizationFormPresenter(_formService, authorizationFormView);
        }
    }
}