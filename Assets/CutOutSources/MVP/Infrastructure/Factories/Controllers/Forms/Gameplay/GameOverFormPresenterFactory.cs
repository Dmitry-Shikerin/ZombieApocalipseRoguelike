using System;
using Sources.Controllers.Presenters.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class GameOverFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;
        private readonly ISceneService _sceneService;

        public GameOverFormPresenterFactory(
            IMVPFormService imvpFormService,
            ISceneService sceneService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public GameOverFormPresenter Create(IGameOverFormView view)
        {
            return new GameOverFormPresenter(view, _imvpFormService, _sceneService);
        } 
    }
}