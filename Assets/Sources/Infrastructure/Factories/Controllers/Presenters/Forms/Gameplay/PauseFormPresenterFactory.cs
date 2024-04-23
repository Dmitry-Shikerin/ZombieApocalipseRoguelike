using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class PauseFormPresenterFactory
    {
        private readonly IViewFormService _viewFormService;

        public PauseFormPresenterFactory(IViewFormService viewFormService)
        {
            _viewFormService = viewFormService ?? throw new ArgumentNullException(nameof(viewFormService));
        }

        public PauseFormPresenter Create(IPauseFormView pauseFormView)
        {
            if (pauseFormView == null)
                throw new ArgumentNullException(nameof(pauseFormView));

            return new PauseFormPresenter(_viewFormService, pauseFormView);
        }
    }
}