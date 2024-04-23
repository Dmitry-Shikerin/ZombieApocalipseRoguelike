using System;
using Sources.Controllers.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Forms.MainMenu
{
    public class MainMenuSettingsFormPresenterFactory
    {
        private readonly IViewFormService _viewFormService;

        public MainMenuSettingsFormPresenterFactory(IViewFormService viewFormService)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
        }

        public MainMenuSettingsFormPresenter Create(IMainMenuSettingsFormView settingsFormView)
        {
            if (settingsFormView == null)
                throw new ArgumentNullException(nameof(settingsFormView));

            return new MainMenuSettingsFormPresenter(_viewFormService, settingsFormView);
        }
    }
}