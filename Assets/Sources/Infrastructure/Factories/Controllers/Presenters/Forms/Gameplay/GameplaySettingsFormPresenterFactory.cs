using System;
using Sources.Controllers.Common.Forms;
using Sources.Controllers.Presenters.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay
{
    public class GameplaySettingsFormPresenterFactory
    {
        private readonly IFormService _formService;

        public GameplaySettingsFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public GameplaySettingsFormPresenter Create(IGameplaySettingsFormView view)
        {
            return new GameplaySettingsFormPresenter(view, _formService);
        }
    }
}