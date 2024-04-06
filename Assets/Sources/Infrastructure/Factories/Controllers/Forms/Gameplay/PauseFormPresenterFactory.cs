using System;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class PauseFormPresenterFactory
    {
        private readonly IFormService _formService;

        public PauseFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public PauseFormPresenter Create(IPauseFormView pauseFormView)
        {
            if (pauseFormView == null)
                throw new ArgumentNullException(nameof(pauseFormView));

            return new PauseFormPresenter(_formService, pauseFormView);
        }
    }
}