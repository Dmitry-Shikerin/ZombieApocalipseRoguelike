using System;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Cameras;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Factories.Views.Spawners;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Services.LevelCompleteds;
using Sources.Infrastructure.Services.Providers;
using Sources.Infrastructure.Services.Repositories;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.Interstitials;
using Sources.InfrastructureInterfaces.Services.LevelCompleteds;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Repositories;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Bears;
using Sources.Presentations.Views.Cameras.Points;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.RootGameObjects;
using Sources.Presentations.Views.Spawners;
using Sources.Utils.CustomCollections;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.Gameplay
{
    public abstract class LoadGameplaySceneServiceBase : ILoadSceneService
    {
        private readonly GameplayHud _gameplayHud;
        private readonly MVPGameplayFormServiceFactory _mvpGameplayFormServiceFactory;
        private readonly UiCollectorFactory _uiCollectorFactory;
        private readonly CharacterViewFactory _characterViewFactory;
        private readonly BearViewFactory _bearViewFactory;
        private readonly UpgradeViewFactory _upgradeViewFactory;
        private readonly UpgradeUiFactory _upgradeUiFactory;
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly RootGameObject _rootGameObject;
        private readonly EnemySpawnViewFactory _enemySpawnViewFactory;
        private readonly ItemSpawnerViewFactory _itemSpawnerViewFactory;
        private readonly IUpgradeConfigCollectionService _upgradeConfigCollectionService;
        private readonly IUpgradeDtoMapper _upgradeDtoMapper;
        private readonly CustomCollection<Upgrader> _upgradeCollection;
        private readonly PlayerWalletProvider _playerWalletProvider;
        private readonly KillEnemyCounterViewFactory _killEnemyCounterViewFactory;
        private readonly BackgroundMusicViewFactory _backgroundMusicViewFactory;
        private readonly IGameOverService _gameOverService;
        private readonly CameraViewFactory _cameraViewFactory;
        private readonly ICameraService _cameraService;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly IVolumeService _volumeService;
        private readonly ISaveService _saveService;
        private readonly ILevelCompletedService _levelCompletedService;
        private readonly ITutorialService _tutorialService;
        private readonly IAdvertisingService _advertisingService;
        private readonly IFormService _formService;
        private readonly IInterstitialShowerService _interstitialShowerService;

        protected LoadGameplaySceneServiceBase(GameplayHud gameplayHud,
            UiCollectorFactory uiCollectorFactory,
            CharacterViewFactory characterViewFactory,
            BearViewFactory bearViewFactory,
            UpgradeViewFactory upgradeViewFactory,
            UpgradeUiFactory upgradeUiFactory,
            ILoadService loadService,
            IEntityRepository entityRepository,
            IEnemySpawnService enemySpawnService,
            RootGameObject rootGameObject,
            EnemySpawnViewFactory enemySpawnViewFactory,
            ItemSpawnerViewFactory itemSpawnerViewFactory,
            IUpgradeConfigCollectionService upgradeConfigCollectionService,
            IUpgradeDtoMapper upgradeDtoMapper,
            CustomCollection<Upgrader> upgradeCollection,
            PlayerWalletProvider playerWalletProvider,
            KillEnemyCounterViewFactory killEnemyCounterViewFactory,
            BackgroundMusicViewFactory backgroundMusicViewFactory,
            IGameOverService gameOverService,
            CameraViewFactory cameraViewFactory,
            ICameraService cameraService,
            VolumeViewFactory volumeViewFactory,
            IVolumeService volumeService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            ITutorialService tutorialService,
            IAdvertisingService advertisingService,
            IFormService formService,
            IInterstitialShowerService interstitialShowerService)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _uiCollectorFactory = uiCollectorFactory ?? throw new ArgumentNullException(nameof(uiCollectorFactory));
            _characterViewFactory = characterViewFactory ?? 
                                    throw new ArgumentNullException(nameof(characterViewFactory));
            _bearViewFactory = bearViewFactory ?? throw new ArgumentNullException(nameof(bearViewFactory));
            _upgradeViewFactory = upgradeViewFactory ?? throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? throw new ArgumentNullException(nameof(upgradeUiFactory));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _enemySpawnService = enemySpawnService ?? throw new ArgumentNullException(nameof(enemySpawnService));
            _rootGameObject = rootGameObject 
                ? rootGameObject 
                : throw new ArgumentNullException(nameof(rootGameObject));
            _enemySpawnViewFactory = enemySpawnViewFactory ?? 
                                     throw new ArgumentNullException(nameof(enemySpawnViewFactory));
            _itemSpawnerViewFactory = itemSpawnerViewFactory ?? 
                                      throw new ArgumentNullException(nameof(itemSpawnerViewFactory));
            _upgradeConfigCollectionService = upgradeConfigCollectionService ?? 
                                              throw new ArgumentNullException(nameof(upgradeConfigCollectionService));
            _upgradeDtoMapper = upgradeDtoMapper ?? throw new ArgumentNullException(nameof(upgradeDtoMapper));
            _upgradeCollection = upgradeCollection ?? 
                                        throw new ArgumentNullException(nameof(upgradeCollection));
            _playerWalletProvider = playerWalletProvider ?? 
                                    throw new ArgumentNullException(nameof(playerWalletProvider));
            _killEnemyCounterViewFactory = killEnemyCounterViewFactory ?? 
                                           throw new ArgumentNullException(nameof(killEnemyCounterViewFactory));
            _backgroundMusicViewFactory = backgroundMusicViewFactory ?? 
                                          throw new ArgumentNullException(nameof(backgroundMusicViewFactory));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _cameraViewFactory = cameraViewFactory ?? throw new ArgumentNullException(nameof(cameraViewFactory));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            _levelCompletedService = levelCompletedService ?? 
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _advertisingService = advertisingService ?? throw new ArgumentNullException(nameof(advertisingService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _interstitialShowerService = interstitialShowerService ?? 
                                         throw new ArgumentNullException(nameof(interstitialShowerService));
        }

        public void Load(IScenePayload scenePayload)
        {
            GameModels gameModels = LoadModels(scenePayload);
            
            //InterstitialShower
            _interstitialShowerService.Register(gameModels.EnemySpawner);
            
            //AdvertisingService
            _advertisingService.Construct(gameModels.PlayerWallet);
            
            //LevelCompleted
            _levelCompletedService.Register(gameModels.KillEnemyCounter, gameModels.EnemySpawner);

            //SavedLevel
            SavedLevel savedLevel = gameModels.SavedLevel;
            gameModels.SavedLevel.SavedLevelId = scenePayload.SceneId;
            
            //Tutorial
            _tutorialService.Construct(gameModels.Tutorial, savedLevel);

            //Volume
            _volumeService.Register(gameModels.Volume);
            _volumeViewFactory.Create(gameModels.Volume, _gameplayHud.VolumeView);
            
            //SaveService
            _saveService.Register(gameModels.EnemySpawner);
            
            //Upgrades
            for (int i = 0; i < _gameplayHud.NotAvailabilityUpgradeUis.Count; i++)
                _upgradeUiFactory.Create(_upgradeCollection[i], _gameplayHud.NotAvailabilityUpgradeUis[i]);

            //Character
            _playerWalletProvider.PlayerWallet = gameModels.PlayerWallet;
            CharacterView characterView = Object.FindObjectOfType<CharacterView>();
            _characterViewFactory.Create(gameModels.Character, characterView);

            //Bear
            BearView bearView = Object.FindObjectOfType<BearView>();
            _bearViewFactory.Create(gameModels.Bear, bearView);
            bearView.SetTargetFollow(characterView.CharacterMovementView);

            //GameOverService
            _gameOverService.Register(gameModels.CharacterHealth);;

            //Spawners
            EnemySpawnerView enemySpawnView = _rootGameObject.EnemySpawnerView;
            enemySpawnView.SetCharacterView(characterView);
            _enemySpawnViewFactory.Create(
                gameModels.EnemySpawner, gameModels.KillEnemyCounter, enemySpawnView);
            _itemSpawnerViewFactory.Create(new ItemSpawner(), _rootGameObject.ItemSpawnerView);
            
            //Gameplay
            _killEnemyCounterViewFactory.Create(
                gameModels.KillEnemyCounter, gameModels.EnemySpawner, _gameplayHud.KillEnemyCounterView);
            
            //BackgroundMusic
            _backgroundMusicViewFactory.Create(_gameplayHud.BackgroundMusicView);

            //Camera
            _cameraService.Add<CharacterView>(characterView);
            _cameraService.Add<AllMapPoint>(_rootGameObject.AllMapPoint);
            _cameraService.SetFollower<CharacterView>();
            _cameraViewFactory.Create(_gameplayHud.CinemachineCameraView);
            
            //FormService
            _uiCollectorFactory.Create();
            _formService.Show(FormId.Hud);
        }

        protected abstract GameModels LoadModels(IScenePayload scenePayload);
    }
}