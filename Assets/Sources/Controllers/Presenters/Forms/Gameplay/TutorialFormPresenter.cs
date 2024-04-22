using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class TutorialFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly ITutorialFormView _tutorialFormView;

        public TutorialFormPresenter(IFormService formService, ITutorialFormView tutorialFormView)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _tutorialFormView = tutorialFormView ??
                                throw new ArgumentNullException(nameof(tutorialFormView));
        }
        
        public override void Enable() =>
            _tutorialFormView.HudButtonView.AddClickListener(ShowHudForm);

        public override void Disable() =>
            _tutorialFormView.HudButtonView.RemoveClickListener(ShowHudForm);

        private void ShowHudForm() =>
            _formService.Show<PauseFormView>();
    }
}