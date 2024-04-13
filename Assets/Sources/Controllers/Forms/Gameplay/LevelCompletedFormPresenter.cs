using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class LevelCompletedFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly ILevelCompletedFormView _levelCompletedFormView;
        private readonly ISceneService _sceneService;

        public LevelCompletedFormPresenter(IFormService formService, ILevelCompletedFormView levelCompletedFormView,
            ISceneService sceneService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _levelCompletedFormView = levelCompletedFormView ?? throw new ArgumentNullException(nameof(levelCompletedFormView));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public void OnEnable() =>
            _levelCompletedFormView.BackToMainMenuButtonView.AddClickListener(OnBackMainMenuButtonClick);

        public void OnDisable() =>
            _levelCompletedFormView.BackToMainMenuButtonView.RemoveClickListener(OnBackMainMenuButtonClick);

        private void OnBackMainMenuButtonClick() =>
            _sceneService.ChangeSceneAsync("MainMenu");
    }
}