using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowHudFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowHudFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowHudFormViewModelComponent Create()
        {
            return new ShowHudFormViewModelComponent(_formService);
        }

    }
}