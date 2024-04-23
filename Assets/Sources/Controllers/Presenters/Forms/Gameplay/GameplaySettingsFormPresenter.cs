using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class GameplaySettingsFormPresenter : PresenterBase
    {
        private readonly IGameplaySettingsFormView _gameplaySettingsFormView;
        private readonly IViewFormService _viewFormService;

        public GameplaySettingsFormPresenter(IViewFormService viewFormService, IGameplaySettingsFormView settingsFormView)
        {
            _gameplaySettingsFormView = settingsFormView ?? throw new ArgumentNullException(nameof(settingsFormView));
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
        }

        public override void Enable() =>
            _gameplaySettingsFormView.PauseFormButtonView.AddClickListener(ShowPauseForm);

        public override void Disable() =>
            _gameplaySettingsFormView.PauseFormButtonView.RemoveClickListener(ShowPauseForm);

        private void ShowPauseForm() =>
            _viewFormService.Show<PauseFormView>();
    }
}