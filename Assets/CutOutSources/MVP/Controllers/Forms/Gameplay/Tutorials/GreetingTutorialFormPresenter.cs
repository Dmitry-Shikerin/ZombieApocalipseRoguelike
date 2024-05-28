using System;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials;

namespace Sources.Controllers.Presenters.Forms.Gameplay.Tutorials
{
    public class GreetingTutorialFormPresenter : PresenterBase
    {
        private readonly IGreetingTutorialFormView _view;
        private readonly IMVPFormService _imvpFormService;

        public GreetingTutorialFormPresenter(IGreetingTutorialFormView view, IMVPFormService imvpFormService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
        }

        public override void Enable()
        {
        }

        public override void Disable()
        {
        }
    }
}