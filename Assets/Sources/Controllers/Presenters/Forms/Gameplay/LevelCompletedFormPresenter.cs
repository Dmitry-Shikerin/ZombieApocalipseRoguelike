using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class LevelCompletedFormPresenter : PresenterBase
    {
        private readonly IViewFormService _viewFormService;
        private readonly ILevelCompletedFormView _levelCompletedFormView;
        private readonly ISceneService _sceneService;
        private readonly IPauseService _pauseService;

        public LevelCompletedFormPresenter(
            IViewFormService viewFormService, 
            ILevelCompletedFormView levelCompletedFormView,
            ISceneService sceneService,
            IPauseService pauseService)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
            _levelCompletedFormView = levelCompletedFormView ?? throw new ArgumentNullException(nameof(levelCompletedFormView));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public override void Enable()
        {
            _levelCompletedFormView.BackToMainMenuButtonView.AddClickListener(OnBackMainMenuButtonClick);
            _pauseService.Pause();
        }

        public override void Disable()
        {
            _pauseService.Continue();
            _levelCompletedFormView.BackToMainMenuButtonView.RemoveClickListener(OnBackMainMenuButtonClick);
        }

        private void OnBackMainMenuButtonClick() =>
            _sceneService.ChangeSceneAsync("MainMenu");
    }
}