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
        private readonly IFormService _formService;
        private readonly ILevelCompletedFormView _levelCompletedFormView;
        private readonly ISceneService _sceneService;
        private readonly IPauseService _pauseService;

        public LevelCompletedFormPresenter(
            IFormService formService, 
            ILevelCompletedFormView levelCompletedFormView,
            ISceneService sceneService,
            IPauseService pauseService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
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