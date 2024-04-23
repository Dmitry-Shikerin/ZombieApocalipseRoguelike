using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class LevelCompletedFormPresenterFactory
    {
        private readonly IViewFormService _viewFormService;
        private readonly ISceneService _sceneService;
        private readonly IPauseService _pauseService;

        public LevelCompletedFormPresenterFactory(
            IViewFormService viewFormService, 
            ISceneService sceneService,
            IPauseService pauseService)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public LevelCompletedFormPresenter Create(ILevelCompletedFormView levelCompletedFormView)
        {
            if (levelCompletedFormView == null)
                throw new ArgumentNullException(nameof(levelCompletedFormView));

            return new LevelCompletedFormPresenter(
                _viewFormService,
                levelCompletedFormView,
                _sceneService,
                _pauseService);
        }
    }
}