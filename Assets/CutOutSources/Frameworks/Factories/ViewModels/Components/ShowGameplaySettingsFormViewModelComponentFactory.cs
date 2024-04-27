using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowGameplaySettingsFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;

        public ShowGameplaySettingsFormViewModelComponentFactory(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }

        public ShowGameplaySettingsFormViewModelComponent Create()
        {
            return new ShowGameplaySettingsFormViewModelComponent(_domainFormService);
        }
    }
}