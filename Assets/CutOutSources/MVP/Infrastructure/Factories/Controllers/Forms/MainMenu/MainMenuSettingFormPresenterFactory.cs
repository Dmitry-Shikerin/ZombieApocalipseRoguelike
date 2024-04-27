using System;
using Sources.Controllers.Common.Forms.MainMenu;
using Sources.Controllers.Presenters.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class MainMenuSettingFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;

        public MainMenuSettingFormPresenterFactory(
            IMVPFormService imvpFormService,
            ILoadService loadService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public MainMenuSettingsFormPresenter Create(IMainMenuSettingsFormView view)
        {
            return new MainMenuSettingsFormPresenter(view, _imvpFormService, _loadService);
        }
    }
}