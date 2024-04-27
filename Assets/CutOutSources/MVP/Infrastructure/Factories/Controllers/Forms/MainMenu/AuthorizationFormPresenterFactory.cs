using System;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class AuthorizationFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;

        public AuthorizationFormPresenterFactory(IMVPFormService imvpFormService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
        }

        public AuthorizationFormPresenter Create(IAuthorizationFormView view)
        {
            return new AuthorizationFormPresenter(view, _imvpFormService);
        }
    }
}