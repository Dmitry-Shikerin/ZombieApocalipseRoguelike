using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowNewGameFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowNewGameFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowNewGameFormViewModelComponent Create()
        {
            return new ShowNewGameFormViewModelComponent(_formService);
        }
    }
}