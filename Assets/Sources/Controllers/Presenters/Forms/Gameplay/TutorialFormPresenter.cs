using System;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Common.Forms
{
    public class TutorialFormPresenter : PresenterBase
    {
        private readonly ITutorialFormView _view;
        private readonly IFormService _formService;

        public TutorialFormPresenter(ITutorialFormView view, IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
        }

        public override void Disable()
        {
        }
    }
}