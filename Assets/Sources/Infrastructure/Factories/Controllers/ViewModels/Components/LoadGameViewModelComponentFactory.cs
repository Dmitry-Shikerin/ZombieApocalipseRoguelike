using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.SceneServices;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class LoadGameViewModelComponentFactory
    {
        private readonly ISceneService _sceneService;

        public LoadGameViewModelComponentFactory(ISceneService sceneService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public LoadGameViewModelComponent Create()
        {
            return new LoadGameViewModelComponent(_sceneService);
        }
    }
}