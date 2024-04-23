using System;
using Sources.Controllers.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Forms.MainMenu
{
    public class MainMenuSettingsFormPresenterFactory
    {
        private readonly IFormService _formService;

        public MainMenuSettingsFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public MainMenuSettingsFormPresenter Create(IMainMenuSettingsFormView settingsFormView)
        {
            if (settingsFormView == null)
                throw new ArgumentNullException(nameof(settingsFormView));

            return new MainMenuSettingsFormPresenter(_formService, settingsFormView);
        }
    }
}