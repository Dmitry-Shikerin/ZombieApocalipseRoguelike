using System;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.DomainInterfaces.Payloads;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Volumes;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IInputServiceUpdater _inputServiceUpdater;
        private readonly ILocalizationService _localizationService;
        private readonly ILoadService _loadService;
        private readonly IUpgradeService _upgradeService;
        private readonly IGameOverService _gameOverService;
        private readonly IVolumeService _volumeService;
        private readonly LoadSceneService _loadSceneService;
        private readonly CreateSceneService _createSceneService;
        private readonly ISaveService _saveService;

        public GameplaySceneFactory(
            IUpdateService updateService,
            IInputServiceUpdater inputServiceUpdater,
            ILocalizationService localizationService,
            ILoadService loadService,
            IUpgradeService upgradeService,
            IGameOverService gameOverService,
            IVolumeService volumeService,
            LoadSceneService loadSceneService,
            CreateSceneService createSceneService,
            ISaveService saveService) 
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputServiceUpdater = inputServiceUpdater ?? throw new ArgumentNullException(nameof(inputServiceUpdater));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _createSceneService = createSceneService ?? throw new ArgumentNullException(nameof(createSceneService));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
        }

        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene(
                _updateService,
                _inputServiceUpdater,
                CreateLoadSceneService(payload),
                _localizationService,
                _loadService,
                _upgradeService,
                _gameOverService,
                _volumeService,
                _saveService);
        }

        private ILoadSceneService CreateLoadSceneService(object payload)
        {
            if (payload == null)
                return _createSceneService;

            var canLoad = payload is IScenePayload { CanLoad : true };

            if (canLoad == false)
                return _createSceneService;

            return _loadSceneService;
        }
    }
}