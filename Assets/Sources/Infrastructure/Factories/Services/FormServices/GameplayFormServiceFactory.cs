using System;
using Assets.Sources.InfastructureInterfaces.Services.Forms;
using Assets.Sources.Infrastructure.Services.Forms;
using JetBrains.Annotations;
using Sources.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Presentations.Views.Forms.Common;
using Sources.Presentations.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class GameplayFormServiceFactory
    {
        private readonly FormService _formService;
        private readonly PauseFormPresenterFactory _pauseFormPresenterFactory;

        public GameplayFormServiceFactory(
            FormService formService,
            PauseFormPresenterFactory pauseFormPresenterFactory)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _pauseFormPresenterFactory = pauseFormPresenterFactory ??
                                         throw new ArgumentNullException(nameof(pauseFormPresenterFactory));
        }

        public IFormService Create()
        {
            Form<PauseFormView, PauseFormPresenter> pauseForm = 
                new Form<PauseFormView, PauseFormPresenter>(_pauseFormPresenterFactory.Create, null);
            _formService.Add(pauseForm);
            
            return _formService;
        }
    }
}