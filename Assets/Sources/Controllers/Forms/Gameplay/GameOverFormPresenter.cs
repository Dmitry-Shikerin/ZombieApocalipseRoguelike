using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class GameOverFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly IGameOverFormView _gameOverFormView;
        private readonly ISceneService _sceneService;

        public GameOverFormPresenter(IFormService formService, IGameOverFormView gameOverFormView,
            ISceneService sceneService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _gameOverFormView = gameOverFormView ?? throw new ArgumentNullException(nameof(gameOverFormView));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public void OnEnable() =>
            _gameOverFormView.BackToMainMenuButtonView.AddClickListener(OnBackMainMenuButtonClick);

        public void OnDisable() =>
            _gameOverFormView.BackToMainMenuButtonView.RemoveClickListener(OnBackMainMenuButtonClick);

        private void OnBackMainMenuButtonClick() =>
            _sceneService.ChangeSceneAsync("MainMenu");
    }
}