using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowWarningNewGameFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowWarningNewGameFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowWarningNewGameFormViewModelComponent Create()
        {
            return new ShowWarningNewGameFormViewModelComponent(_formService);
        }
    }
}