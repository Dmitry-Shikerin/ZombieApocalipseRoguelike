using System;
using Sources.Controllers.Common.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class LevelCompletedFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;
        private readonly ISceneService _sceneService;

        public LevelCompletedFormPresenterFactory(IMVPFormService imvpFormService, ISceneService sceneService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public LevelCompletedFormPresenter Create(ILevelCompletedFormView view)
        {
            return new LevelCompletedFormPresenter(view, _imvpFormService, _sceneService);
        }
    }
}