using System;
using Sources.Controllers.Presenters.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class MainMenuHudFormViewPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;

        public MainMenuHudFormViewPresenterFactory(
            IMVPFormService imvpFormService,
            ILoadService loadService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public MainMenuHudFormPresenter Create(IMainMenuHudFormView view)
        {
            return new MainMenuHudFormPresenter(view, _imvpFormService, _loadService);
        }
    }
}