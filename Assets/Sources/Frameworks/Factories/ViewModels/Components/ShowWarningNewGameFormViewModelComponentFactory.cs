using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowWarningNewGameFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;

        public ShowWarningNewGameFormViewModelComponentFactory(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }

        public ShowWarningNewGameFormViewModelComponent Create()
        {
            return new ShowWarningNewGameFormViewModelComponent(_domainFormService);
        }
    }
}