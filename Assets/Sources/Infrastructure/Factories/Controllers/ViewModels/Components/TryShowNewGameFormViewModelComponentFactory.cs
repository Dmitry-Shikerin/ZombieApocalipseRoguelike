using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class TryShowNewGameFormViewModelComponentFactory
    {
        private readonly IFormService _formService;
        private readonly ILoadService _loadService;

        public TryShowNewGameFormViewModelComponentFactory(
            IFormService formService,
            ILoadService loadService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public TryShowNewGameFormViewModelComponent Create()
        {
            return new TryShowNewGameFormViewModelComponent(_formService, _loadService);
        }
    }
}