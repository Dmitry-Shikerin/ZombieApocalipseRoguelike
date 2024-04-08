using System;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class TutorialFormPresenterFactory
    {
        private readonly IFormService _formService;

        public TutorialFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public TutorialFormPresenter Create(ITutorialFormView tutorialFormView)
        {
            if (tutorialFormView == null)
                throw new ArgumentNullException(nameof(tutorialFormView));

            return new TutorialFormPresenter(_formService, tutorialFormView);
        }
    }
}