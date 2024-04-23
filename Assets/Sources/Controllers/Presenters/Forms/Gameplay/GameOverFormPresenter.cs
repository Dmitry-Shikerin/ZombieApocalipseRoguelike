using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class GameOverFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly IGameOverFormView _gameOverFormView;
        private readonly ISceneService _sceneService;
        private readonly IPauseService _pauseService;

        public GameOverFormPresenter(
            IFormService formService, 
            IGameOverFormView gameOverFormView,
            ISceneService sceneService,
            IPauseService pauseService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _gameOverFormView = gameOverFormView ?? throw new ArgumentNullException(nameof(gameOverFormView));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public override void Enable()
        {
            _pauseService.Pause();
            _gameOverFormView.BackToMainMenuButtonView.AddClickListener(OnBackMainMenuButtonClick);
        }

        public override void Disable()
        {
            _pauseService.Continue();
            _gameOverFormView.BackToMainMenuButtonView.RemoveClickListener(OnBackMainMenuButtonClick);
        }

        private void OnBackMainMenuButtonClick() =>
            _sceneService.ChangeSceneAsync("MainMenu");
    }
}