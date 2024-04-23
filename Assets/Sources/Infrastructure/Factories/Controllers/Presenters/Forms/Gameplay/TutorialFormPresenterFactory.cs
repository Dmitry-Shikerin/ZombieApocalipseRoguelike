using System;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class TutorialFormPresenterFactory
    {
        private readonly IViewFormService _viewFormService;

        public TutorialFormPresenterFactory(IViewFormService viewFormService)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
        }

        public TutorialFormPresenter Create(ITutorialFormView tutorialFormView)
        {
            if (tutorialFormView == null)
                throw new ArgumentNullException(nameof(tutorialFormView));

            return new TutorialFormPresenter(_viewFormService, tutorialFormView);
        }
    }
}