using System;
using Sources.Domain.Models.Data.Ids;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Common.Forms
{
    public class LevelCompletedFormPresenter : PresenterBase
    {
        private readonly ILevelCompletedFormView _view;
        private readonly IFormService _formService;
        private readonly ISceneService _sceneService;

        public LevelCompletedFormPresenter(
            ILevelCompletedFormView view,
            IFormService formService,
            ISceneService sceneService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public override void Enable()
        {
            _view.BackToMainMenuButtonView.AddClickListener(LoadMainMenuScene);
        }

        public override void Disable()
        {
            _view.BackToMainMenuButtonView.RemoveClickListener(LoadMainMenuScene);
        }

        private void LoadMainMenuScene()
        {
            _sceneService.ChangeSceneAsync(ModelId.MainMenu);
        }
    }
}