using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Data.Ids;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.Forms.Gameplay.Tutorials;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Presenters.Forms.Gameplay
{
    public class PauseFormPresenter : PresenterBase
    {
        private readonly IPauseFormView _view;
        private readonly IMVPFormService _imvpFormService;
        private readonly ISceneService _sceneService;
        private readonly IPauseService _pauseService;

        public PauseFormPresenter(
            IPauseFormView view, 
            IMVPFormService imvpFormService,
            ISceneService sceneService,
            IPauseService pauseService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public override void Enable()
        {
            // _pauseService.Pause();
            // _pauseService.PauseSound();
            
            _view.HudButtonView.AddClickListener(ShowHudForm);
            _view.SettingsButtonView.AddClickListener(ShowSettingsForm);
            _view.TutorialButtonView.AddClickListener(ShowTutorialForm);
            _view.MainMenuButtonView.AddClickListener(LoadMainMenuScene);
        }

        public override void Disable()
        {
            // _pauseService.Continue();
            // _pauseService.ContinueSound();
            
            _view.HudButtonView.RemoveClickListener(ShowHudForm);
            _view.SettingsButtonView.RemoveClickListener(ShowSettingsForm);
            _view.TutorialButtonView.RemoveClickListener(ShowTutorialForm);
            _view.MainMenuButtonView.RemoveClickListener(LoadMainMenuScene);
        }

        private void ShowHudForm()
        {
            _imvpFormService.Show<HudFormView>();
        }

        private void ShowSettingsForm()
        {
            _imvpFormService.Show<GameplaySettingsFormView>();
        }

        private void ShowTutorialForm()
        {
            _imvpFormService.Show<GreetingGreetingTutorialFormView>();
        }

        private void LoadMainMenuScene()
        {
            _sceneService.ChangeSceneAsync(ModelId.MainMenu);
        }
    }
}