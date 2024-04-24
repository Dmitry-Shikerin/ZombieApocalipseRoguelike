using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowLeaderboardFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowLeaderboardFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowLeaderboardFormViewModelComponent Create()
        {
            return new ShowLeaderboardFormViewModelComponent(_formService);
        }
    }
}