using System;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Presenters.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Domain.Models.Data.Ids;
using Sources.DomainInterfaces.Payloads;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.MainMenu;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Volumes;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Scenes
{
    public class MainMenuSceneFactory : ISceneFactory
    {
        private readonly CreateMainMenuSceneService _createMainMenuSceneService;
        private readonly LoadMainMenuSceneService _loadMainMenuSceneService;
        private readonly IVolumeService _volumeService;
        private readonly ILoadService _loadService;

        public MainMenuSceneFactory(
            CreateMainMenuSceneService createMainMenuSceneService,
            LoadMainMenuSceneService loadMainMenuSceneService,
            IVolumeService volumeService,
            ILoadService loadService)
        {
            _createMainMenuSceneService = createMainMenuSceneService ?? 
                                          throw new ArgumentNullException(nameof(createMainMenuSceneService));
            _loadMainMenuSceneService = loadMainMenuSceneService ?? 
                                        throw new ArgumentNullException(nameof(loadMainMenuSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }
        
        public async UniTask<IScene> Create(object payload)
        {
            return new MainMenuScene(
                CreateLoadSceneService(payload),
                _volumeService);
        }
        
        private ILoadSceneService CreateLoadSceneService(object payload)
        {
            if (_loadService.HasKey(ModelId.GameData) == false)
                return _createMainMenuSceneService;

            return _loadMainMenuSceneService;
        }
    }
}