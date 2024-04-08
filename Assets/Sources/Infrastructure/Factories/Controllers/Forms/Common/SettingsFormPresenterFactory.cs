using System;
using Sources.Controllers.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Common;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Common
{
    public class SettingsFormPresenterFactory
    {
        private readonly IFormService _formService;

        public SettingsFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public SettingsFormPresenter Create(ISettingsFormView settingsFormView)
        {
            if (settingsFormView == null)
                throw new ArgumentNullException(nameof(settingsFormView));

            return new SettingsFormPresenter(_formService, settingsFormView);
        }
    }
}