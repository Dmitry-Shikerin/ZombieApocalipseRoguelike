using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowHudFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;

        public ShowHudFormViewModelComponentFactory(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }

        public ShowHudFormViewModelComponent Create()
        {
            return new ShowHudFormViewModelComponent(_domainFormService);
        }

    }
}