using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class ShowNewGameFormViewModelComponentFactory
    {
        private readonly ISceneService _sceneService;
        private readonly IDomainFormService _domainFormService;
        private readonly ILoadService _loadService;

        public ShowNewGameFormViewModelComponentFactory(
            ISceneService sceneService,
            IDomainFormService domainFormService,
            ILoadService loadService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public ShowNewGameFormViewModelComponent Create()
        {
            return new ShowNewGameFormViewModelComponent(_sceneService, _domainFormService, _loadService);
        }
    }
}