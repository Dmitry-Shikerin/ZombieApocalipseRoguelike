using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowMainMenuSettingsFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowMainMenuSettingsFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowMainMenuSettingsFormViewModelComponent Create()
        {
            return new ShowMainMenuSettingsFormViewModelComponent(_formService);
        }
    }
}