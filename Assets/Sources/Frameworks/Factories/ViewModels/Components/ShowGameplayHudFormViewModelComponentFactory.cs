using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowGameplayHudFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;

        public ShowGameplayHudFormViewModelComponentFactory(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }

        public ShowGameplayHudFormViewModelComponent Create()
        {
            return new ShowGameplayHudFormViewModelComponent(_domainFormService);
        }

    }
}