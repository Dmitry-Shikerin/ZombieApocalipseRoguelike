using System;
using Sources.Controllers.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using Sources.PresentationsInterfaces.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class GameplaySettingsFormPresenterFactory
    {
        private readonly IFormService _formService;

        public GameplaySettingsFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public GameplaySettingsFormPresenter Create(IGameplaySettingsFormView settingsFormView)
        {
            if (settingsFormView == null)
                throw new ArgumentNullException(nameof(settingsFormView));

            return new GameplaySettingsFormPresenter(_formService, settingsFormView);
        }
    }
}