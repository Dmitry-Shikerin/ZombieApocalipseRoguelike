using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class GameplaySettingsFormPresenter : PresenterBase
    {
        private readonly IGameplaySettingsFormView _gameplaySettingsFormView;
        private readonly IFormService _formService;

        public GameplaySettingsFormPresenter(IFormService formService, IGameplaySettingsFormView settingsFormView)
        {
            _gameplaySettingsFormView = settingsFormView ?? throw new ArgumentNullException(nameof(settingsFormView));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable() =>
            _gameplaySettingsFormView.PauseFormButtonView.AddClickListener(ShowPauseForm);

        public override void Disable() =>
            _gameplaySettingsFormView.PauseFormButtonView.RemoveClickListener(ShowPauseForm);

        private void ShowPauseForm() =>
            _formService.Show<PauseFormView>();
    }
}