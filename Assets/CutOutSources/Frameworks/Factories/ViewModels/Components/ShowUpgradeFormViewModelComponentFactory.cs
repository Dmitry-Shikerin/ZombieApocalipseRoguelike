using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowUpgradeFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;

        public ShowUpgradeFormViewModelComponentFactory(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }

        public ShowUpgradeFormViewModelComponent Create()
        {
            return new ShowUpgradeFormViewModelComponent(_domainFormService);
        }
    }
}