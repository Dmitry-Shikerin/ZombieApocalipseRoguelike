using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowMainMenuSettingsFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;

        public ShowMainMenuSettingsFormViewModelComponentFactory(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }

        public ShowMainMenuSettingsFormViewModelComponent Create()
        {
            return new ShowMainMenuSettingsFormViewModelComponent(_domainFormService);
        }
    }
}