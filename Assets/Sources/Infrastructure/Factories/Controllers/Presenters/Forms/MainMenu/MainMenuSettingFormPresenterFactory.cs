using System;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class MainMenuSettingFormPresenterFactory
    {
        private readonly IFormService _formService;

        public MainMenuSettingFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public MainMenuSettingsFormPresenter Create(IMainMenuSettingsFormView view)
        {
            return new MainMenuSettingsFormPresenter(view, _formService);
        }
    }
}