using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowPauseFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;

        public ShowPauseFormViewModelComponentFactory(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }

        public ShowPauseMenuFormViewModelComponent Create()
        {
            return new ShowPauseMenuFormViewModelComponent(_domainFormService);
        }
    }
}