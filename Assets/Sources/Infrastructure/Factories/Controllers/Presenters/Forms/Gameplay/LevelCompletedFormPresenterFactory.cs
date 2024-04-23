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
        private readonly IFormService _formService;
        private readonly ISceneService _sceneService;
        private readonly IPauseService _pauseService;

        public LevelCompletedFormPresenterFactory(
            IFormService formService, 
            ISceneService sceneService,
            IPauseService pauseService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public LevelCompletedFormPresenter Create(ILevelCompletedFormView levelCompletedFormView)
        {
            if (levelCompletedFormView == null)
                throw new ArgumentNullException(nameof(levelCompletedFormView));

            return new LevelCompletedFormPresenter(
                _formService,
                levelCompletedFormView,
                _sceneService,
                _pauseService);
        }
    }
}