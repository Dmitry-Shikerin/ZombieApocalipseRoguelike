using System;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class AuthorizationFormPresenterFactory
    {
        private readonly IFormService _formService;

        public AuthorizationFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public AuthorizationFormPresenter Create(IAuthorizationFormView view)
        {
            return new AuthorizationFormPresenter(view, _formService);
        }
    }
}