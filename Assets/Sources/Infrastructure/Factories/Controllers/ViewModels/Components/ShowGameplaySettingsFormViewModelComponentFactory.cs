using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowGameplaySettingsFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowGameplaySettingsFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowGameplaySettingsFormViewModelComponent Create()
        {
            return new ShowGameplaySettingsFormViewModelComponent(_formService);
        }
    }
}