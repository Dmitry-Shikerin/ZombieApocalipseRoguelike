using System;
using Sources.Controllers.Common.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class PauseFormPresenterFactory
    {
        private readonly IFormService _formService;
        private readonly ISceneService _sceneService;

        public PauseFormPresenterFactory(IFormService formService, ISceneService sceneService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public PauseFormPresenter Create(IPauseFormView view)
        {
            return new PauseFormPresenter(view, _formService, _sceneService);
        }
    }
}