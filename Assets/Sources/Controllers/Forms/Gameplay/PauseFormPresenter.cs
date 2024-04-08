using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Common;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class PauseFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly IPauseFormView _pauseFormView;

        public PauseFormPresenter(IFormService formService, IPauseFormView pauseFormView)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _pauseFormView = pauseFormView ?? throw new ArgumentNullException(nameof(pauseFormView));
        }

        public override void Enable()
        {
            _pauseFormView.SettingsButtonView.AddClickListener(ShowSettingsForm);
            _pauseFormView.HudButtonView.AddClickListener(ShowHudForm);
            _pauseFormView.TutorialButtonView.AddClickListener(ShowTutorialForm);
        }

        public override void Disable()
        {
            _pauseFormView.SettingsButtonView.RemoveClickListener(ShowSettingsForm);
            _pauseFormView.TutorialButtonView.RemoveClickListener(ShowTutorialForm);
            _pauseFormView.HudButtonView.RemoveClickListener(ShowHudForm);
        }

        private void ShowHudForm() =>
            _formService.Show<HudFormView>();

        private void ShowTutorialForm() =>
            _formService.Show<TutorialFormView>();

        private void ShowSettingsForm() =>
            _formService.Show<SettingsFormView>();
    }
}