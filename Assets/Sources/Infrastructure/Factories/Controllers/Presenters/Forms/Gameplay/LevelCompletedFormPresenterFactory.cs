using System;
using Sources.Controllers.Common.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class LevelCompletedFormPresenterFactory
    {
        private readonly IFormService _formService;
        private readonly ISceneService _sceneService;

        public LevelCompletedFormPresenterFactory(IFormService formService, ISceneService sceneService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public LevelCompletedFormPresenter Create(ILevelCompletedFormView view)
        {
            return new LevelCompletedFormPresenter(view, _formService, _sceneService);
        }
    }
}