using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class GameOverFormPresenterFactory
    {
        private readonly IFormService _formService;
        private readonly ISceneService _sceneService;

        public GameOverFormPresenterFactory(IFormService formService, ISceneService sceneService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public GameOverFormPresenter Create(IGameOverFormView gameOverFormView)
        {
            if (gameOverFormView == null)
                throw new ArgumentNullException(nameof(gameOverFormView));

            return new GameOverFormPresenter(_formService, gameOverFormView, _sceneService);
        }
    }
}