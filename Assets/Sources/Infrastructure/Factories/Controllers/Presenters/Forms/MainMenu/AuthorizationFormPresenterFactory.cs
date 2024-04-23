using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Forms.MainMenu
{
    public class AuthorizationFormPresenterFactory
    {
        private readonly IViewFormService _viewFormService;

        public AuthorizationFormPresenterFactory(IViewFormService viewFormService)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
        }

        public AuthorizationFormPresenter Create(IAuthorizationFormView authorizationFormView)
        {
            if (authorizationFormView == null)
                throw new ArgumentNullException(nameof(authorizationFormView));

            return new AuthorizationFormPresenter(_viewFormService, authorizationFormView);
        }
    }
}