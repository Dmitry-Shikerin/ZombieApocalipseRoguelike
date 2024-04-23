using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowUpgradeFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowUpgradeFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowUpgradeFormViewModelComponent Create()
        {
            return new ShowUpgradeFormViewModelComponent(_formService);
        }
    }
}