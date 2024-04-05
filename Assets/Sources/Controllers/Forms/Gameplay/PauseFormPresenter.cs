using System;
using Assets.Sources.InfastructureInterfaces.Services.Forms;
using JetBrains.Annotations;
using Sources.Controllers.Common;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Controllers.Forms.Gameplay
{
    public class PauseFormPresenter : PresenterBase
    {
        private readonly IFormService _formService;
        private readonly IPauseFormView _pauseFormView;

        public PauseFormPresenter(IFormService formService, IPauseFormView pauseFormView)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _pauseFormView = pauseFormView ?? throw new ArgumentNullException(nameof(pauseFormView));
        }
    }
}