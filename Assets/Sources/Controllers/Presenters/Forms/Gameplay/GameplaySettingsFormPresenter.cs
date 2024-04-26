using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Presenters.Forms.Gameplay
{
    public class GameplaySettingsFormPresenter : PresenterBase
    {
        private readonly IGameplaySettingsFormView _view;
        private readonly IFormService _formService;

        public GameplaySettingsFormPresenter(
            IGameplaySettingsFormView view, 
            IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            _view.PauseFormButtonView.AddClickListener(ShowPauseForm);
        }

        public override void Disable()
        {
            _view.PauseFormButtonView.RemoveClickListener(ShowPauseForm);
        }

        private void ShowPauseForm()
        {
            _formService.Show<PauseFormView>();
        }
    }
}