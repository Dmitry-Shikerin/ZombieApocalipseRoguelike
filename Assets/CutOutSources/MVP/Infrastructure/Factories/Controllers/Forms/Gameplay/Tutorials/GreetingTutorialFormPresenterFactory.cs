using System;
using Sources.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay.Tutorials
{
    public class GreetingTutorialFormPresenterFactory
    {
        private readonly IMVPFormService _imvpFormService;

        public GreetingTutorialFormPresenterFactory(IMVPFormService imvpFormService)
        {
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
        }

        public GreetingTutorialFormPresenter Create(IGreetingTutorialFormView view)
        {
            return new GreetingTutorialFormPresenter(view, _imvpFormService);
        }
    }
}