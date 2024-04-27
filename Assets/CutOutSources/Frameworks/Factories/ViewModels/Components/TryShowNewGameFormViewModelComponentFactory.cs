using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class TryShowNewGameFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;
        private readonly ILoadService _loadService;

        public TryShowNewGameFormViewModelComponentFactory(
            IDomainFormService domainFormService,
            ILoadService loadService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public TryShowNewGameFormViewModelComponent Create()
        {
            return new TryShowNewGameFormViewModelComponent(_domainFormService, _loadService);
        }
    }
}