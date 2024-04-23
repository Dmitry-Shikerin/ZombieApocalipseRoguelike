using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class TutorialFormPresenter : PresenterBase
    {
        private readonly IViewFormService _viewFormService;
        private readonly ITutorialFormView _tutorialFormView;

        public TutorialFormPresenter(IViewFormService viewFormService, ITutorialFormView tutorialFormView)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
            _tutorialFormView = tutorialFormView ??
                                throw new ArgumentNullException(nameof(tutorialFormView));
        }
        
        public override void Enable() =>
            _tutorialFormView.HudButtonView.AddClickListener(ShowHudForm);

        public override void Disable() =>
            _tutorialFormView.HudButtonView.RemoveClickListener(ShowHudForm);

        private void ShowHudForm() =>
            _viewFormService.Show<PauseFormView>();
    }
}