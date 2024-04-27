using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using Sources.InfrastructureInterfaces.Services.SceneServices;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class LoadGameViewModelComponentFactory
    {
        private readonly ISceneService _sceneService;
        private readonly IDataService _dataService;

        public LoadGameViewModelComponentFactory(
            ISceneService sceneService,
            IDataService dataService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public LoadGameViewModelComponent Create()
        {
            return new LoadGameViewModelComponent(_sceneService, _dataService);
        }
    }
}