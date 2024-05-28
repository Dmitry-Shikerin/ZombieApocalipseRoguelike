using System;
using Sources.Controllers.Presenters.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class PauseFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;
        private readonly ISceneService _sceneService;
        private readonly IPauseService _pauseService;

        public PauseFormPresenterFactory(
            IMVPFormService imvpFormService, 
            ISceneService sceneService,
            IPauseService pauseService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public PauseFormPresenter Create(IPauseFormView view)
        {
            return new PauseFormPresenter(view, _imvpFormService, _sceneService, _pauseService);
        }
    }
}