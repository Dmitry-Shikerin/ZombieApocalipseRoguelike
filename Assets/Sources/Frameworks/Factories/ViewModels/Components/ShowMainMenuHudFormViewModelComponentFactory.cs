using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowMainMenuHudFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;

        public ShowMainMenuHudFormViewModelComponentFactory(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }

        public ShowMainMenuHudFormViewModelComponent Create()
        {
            return new ShowMainMenuHudFormViewModelComponent(_domainFormService);
        }
    }
}