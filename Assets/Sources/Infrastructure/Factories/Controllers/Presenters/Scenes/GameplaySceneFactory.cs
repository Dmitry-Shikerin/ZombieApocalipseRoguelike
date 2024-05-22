using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sources.Controllers.Presenters.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Frameworks.UiFramework.ServicesInterfaces.AudioSources;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.Focuses;
using Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.Gameplay;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.LevelCompleteds;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Curtains;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;

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
        private readonly LoadGameplaySceneService _loadGameplaySceneService;
        private readonly CreateGameplaySceneService _createGameplaySceneService;
        private readonly ISaveService _saveService;
        private readonly ILevelCompletedService _levelCompletedService;
        private readonly ITutorialService _tutorialService;
        private readonly CustomCollection<IEnemyView> _enemyCollection;
        private readonly IAudioService _audioService;
        private readonly IFocusService _focusService;
        private readonly IAdvertisingService _advertisingService;
        private readonly IPauseService _pauseService;
        private readonly IFormService _formService;
        private readonly UiCollectorFactory _uiCollectorFactory;
        private readonly CurtainView _curtainView;

        public GameplaySceneFactory(
            IUpdateService updateService,
            IInputServiceUpdater inputServiceUpdater,
            ILocalizationService localizationService,
            ILoadService loadService,
            IUpgradeService upgradeService,
            IGameOverService gameOverService,
            IVolumeService volumeService,
            LoadGameplaySceneService loadGameplaySceneService,
            CreateGameplaySceneService createGameplaySceneService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            ITutorialService tutorialService,
            CustomCollection<IEnemyView> enemyCollection,
            CurtainView curtainView,
            IAudioService audioService,
            IFocusService focusService,
            IAdvertisingService advertisingService,
            IPauseService pauseService,
            IFormService formService,
            UiCollectorFactory uiCollectorFactory) 
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputServiceUpdater = inputServiceUpdater ?? throw new ArgumentNullException(nameof(inputServiceUpdater));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _loadGameplaySceneService = loadGameplaySceneService ?? throw new ArgumentNullException(nameof(loadGameplaySceneService));
            _createGameplaySceneService = createGameplaySceneService ?? throw new ArgumentNullException(nameof(createGameplaySceneService));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            _levelCompletedService = levelCompletedService ?? throw new ArgumentNullException(nameof(levelCompletedService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            _advertisingService = advertisingService ?? throw new ArgumentNullException(nameof(advertisingService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _uiCollectorFactory = uiCollectorFactory ?? throw new ArgumentNullException(nameof(uiCollectorFactory));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
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
                _saveService,
                _levelCompletedService,
                _tutorialService,
                _enemyCollection,
                _curtainView,
                _audioService,
                _focusService,
                _advertisingService,
                _pauseService,
                _formService,
                _uiCollectorFactory);
        }

        private ILoadSceneService CreateLoadSceneService(object payload)
        {
            if (payload == null)
                return _createGameplaySceneService;

            var canLoad = payload is IScenePayload { CanLoad : true };

            if (canLoad == false)
                return _createGameplaySceneService;

            return _loadGameplaySceneService;
        }
    }
}