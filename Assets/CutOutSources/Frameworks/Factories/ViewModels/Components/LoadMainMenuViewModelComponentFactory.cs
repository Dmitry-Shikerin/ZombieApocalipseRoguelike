using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.SceneServices;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class LoadMainMenuViewModelComponentFactory
    {
        private readonly ISceneService _sceneService;

        public LoadMainMenuViewModelComponentFactory(ISceneService sceneService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public LoadMainMenuViewModelComponent Create()
        {
            return new LoadMainMenuViewModelComponent(_sceneService);
        }
    }
}