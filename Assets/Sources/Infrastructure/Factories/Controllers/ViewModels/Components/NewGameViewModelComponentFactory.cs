using System;
using Sources.Controllers.ModelViews.Components;
using Sources.InfrastructureInterfaces.Services.SceneServices;

namespace Sources.Infrastructure.Factories.Controllers.ViewModels.Components
{
    public class NewGameViewModelComponentFactory
    {
        private readonly ISceneService _sceneService;

        public NewGameViewModelComponentFactory(ISceneService sceneService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public NewGameViewModelComponent Create()
        {
            return new NewGameViewModelComponent(_sceneService);
        }
    }
}