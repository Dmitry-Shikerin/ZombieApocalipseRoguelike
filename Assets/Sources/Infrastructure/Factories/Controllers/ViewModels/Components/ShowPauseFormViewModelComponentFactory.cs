using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowPauseFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowPauseFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowPauseMenuFormViewModelComponent Create()
        {
            return new ShowPauseMenuFormViewModelComponent(_formService);
        }
    }
}