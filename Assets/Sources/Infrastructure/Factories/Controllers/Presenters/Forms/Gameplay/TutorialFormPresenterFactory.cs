using System;
using Sources.Controllers.Common.Forms;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class TutorialFormPresenterFactory
    {
        private readonly IFormService _formService;

        public TutorialFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public TutorialFormPresenter Create(ITutorialFormView view)
        {
            return new TutorialFormPresenter(view, _formService);
        }
    }
}