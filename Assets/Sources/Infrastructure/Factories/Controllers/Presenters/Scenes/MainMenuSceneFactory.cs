using System;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Presenters.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Domain.Models.Data.Ids;
using Sources.DomainInterfaces.Payloads;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.MainMenu;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Curtains;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Scenes
{
    public class MainMenuSceneFactory : ISceneFactory
    {
        private readonly CreateMainMenuSceneService _createMainMenuSceneService;
        private readonly LoadMainMenuSceneService _loadMainMenuSceneService;
        private readonly IVolumeService _volumeService;
        private readonly ILoadService _loadService;
        private readonly ILocalizationService _localizationService;
        private readonly CurtainView _curtainView;

        public MainMenuSceneFactory(
            CreateMainMenuSceneService createMainMenuSceneService,
            LoadMainMenuSceneService loadMainMenuSceneService,
            IVolumeService volumeService,
            ILoadService loadService,
            ILocalizationService localizationService,
            CurtainView curtainView)
        {
            _createMainMenuSceneService = createMainMenuSceneService ?? 
                                          throw new ArgumentNullException(nameof(createMainMenuSceneService));
            _loadMainMenuSceneService = loadMainMenuSceneService ?? 
                                        throw new ArgumentNullException(nameof(loadMainMenuSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _localizationService = localizationService ??
                                   throw new ArgumentNullException(nameof(localizationService));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }
        
        public async UniTask<IScene> Create(object payload)
        {
            return new MainMenuScene(
                CreateLoadSceneService(payload),
                _volumeService,
                _localizationService,
                _curtainView);
        }
        
        private ILoadSceneService CreateLoadSceneService(object payload)
        {
            if (_loadService.HasKey(ModelId.GameData) == false)
                return _createMainMenuSceneService;

            return _loadMainMenuSceneService;
        }
    }
}