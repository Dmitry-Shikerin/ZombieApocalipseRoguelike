using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowGameplayHudFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowGameplayHudFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowGameplayHudFormViewModelComponent Create()
        {
            return new ShowGameplayHudFormViewModelComponent(_formService);
        }

    }
}