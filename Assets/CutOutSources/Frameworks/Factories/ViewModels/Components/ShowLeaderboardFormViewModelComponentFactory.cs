using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowLeaderboardFormViewModelComponentFactory
    {
        private readonly IDomainFormService _domainFormService;

        public ShowLeaderboardFormViewModelComponentFactory(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }

        public ShowLeaderboardFormViewModelComponent Create()
        {
            return new ShowLeaderboardFormViewModelComponent(_domainFormService);
        }
    }
}