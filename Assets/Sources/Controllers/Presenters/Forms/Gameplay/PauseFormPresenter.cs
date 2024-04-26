using System;
using Sources.Domain.Models.Data.Ids;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Common.Forms
{
    public class PauseFormPresenter : PresenterBase
    {
        private readonly IPauseFormView _view;
        private readonly IFormService _formService;
        private readonly ISceneService _sceneService;

        public PauseFormPresenter(
            IPauseFormView view, 
            IFormService formService,
            ISceneService sceneService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public override void Enable()
        {
            _view.HudButtonView.AddClickListener(ShowHudForm);
            _view.SettingsButtonView.AddClickListener(ShowSettingsForm);
            _view.TutorialButtonView.AddClickListener(ShowTutorialForm);
            _view.MainMenuButtonView.AddClickListener(LoadMainMenuScene);
        }

        public override void Disable()
        {
            _view.HudButtonView.RemoveClickListener(ShowHudForm);
            _view.SettingsButtonView.RemoveClickListener(ShowSettingsForm);
            _view.TutorialButtonView.RemoveClickListener(ShowTutorialForm);
            _view.MainMenuButtonView.RemoveClickListener(LoadMainMenuScene);
        }

        private void ShowHudForm()
        {
            _formService.Show<HudFormView>();
        }

        private void ShowSettingsForm()
        {
            _formService.Show<GameplaySettingsFormView>();
        }

        private void ShowTutorialForm()
        {
            _formService.Show<TutorialFormView>();
        }

        private void LoadMainMenuScene()
        {
            _sceneService.ChangeSceneAsync(ModelId.MainMenu);
        }
    }
}