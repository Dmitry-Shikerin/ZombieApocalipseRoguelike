using System;
using Sources.Controllers.Presenters.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.Presentations.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class WarningNewGameFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;

        public WarningNewGameFormPresenterFactory(
            IMVPFormService imvpFormService,
            ILoadService loadService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public WarningNewGameFormPresenter Create(IWarningNewGameFormView view)
        {
            return new WarningNewGameFormPresenter(view, _imvpFormService, _loadService);
        }
    }
}