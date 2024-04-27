using System;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class NewGameFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;
        private readonly ISceneService _sceneService;

        public NewGameFormPresenterFactory(
            IMVPFormService imvpFormService,
            ILoadService loadService,
            ISceneService sceneService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public NewGameFormPresenter Create(INewGameFormView view)
        {
            return new NewGameFormPresenter(view, _imvpFormService, _loadService, _sceneService);
        }
    }
}