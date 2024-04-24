using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowMainMenuHudFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowMainMenuHudFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowMainMenuHudFormViewModelComponent Create()
        {
            return new ShowMainMenuHudFormViewModelComponent(_formService);
        }
    }
}