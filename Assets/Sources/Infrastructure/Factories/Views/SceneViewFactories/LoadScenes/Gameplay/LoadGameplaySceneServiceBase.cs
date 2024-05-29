using System;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Frameworks.UiFramework.Presentation.Views.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdvertisingServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Cameras;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Factories.Views.Spawners;
using Sources.Infrastructure.Factories.Views.Upgrades.Controllers;
using Sources.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.InfrastructureInterfaces.Factories.Views.Upgrades;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.LevelCompleteds;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Cameras.Types;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.RootGameObjects;
using Sources.Presentations.Views.Spawners;
using Sources.PresentationsInterfaces.Views.Bears;
using Sources.Utils.CustomCollections;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.Gameplay
{
    public abstract class LoadGameplaySceneServiceBase : ILoadSceneService
    {
        private readonly GameplayHud _gameplayHud;
        private readonly UiCollectorFactory _uiCollectorFactory;
        private readonly CharacterViewFactory _characterViewFactory;
        private readonly BearViewFactory _bearViewFactory;
        private readonly IUpgradeUiFactory _upgradeUiFactory;
        private readonly RootGameObject _rootGameObject;
        private readonly EnemySpawnViewFactory _enemySpawnViewFactory;
        private readonly ItemSpawnerViewFactory _itemSpawnerViewFactory;
        private readonly CustomCollection<Upgrader> _upgradeCollection;
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
        private readonly ScoreCounterViewFactory _scoreCounterViewFactory;
        private readonly UpgradeControllerViewFactory _upgradeControllerViewFactory;

        protected LoadGameplaySceneServiceBase(
            GameplayHud gameplayHud,
            UiCollectorFactory uiCollectorFactory,
            CharacterViewFactory characterViewFactory,
            BearViewFactory bearViewFactory,
            IUpgradeUiFactory upgradeUiFactory,
            RootGameObject rootGameObject,
            EnemySpawnViewFactory enemySpawnViewFactory,
            ItemSpawnerViewFactory itemSpawnerViewFactory,
            CustomCollection<Upgrader> upgradeCollection,
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
            ScoreCounterViewFactory scoreCounterViewFactory,
            UpgradeControllerViewFactory upgradeControllerViewFactory)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _uiCollectorFactory = uiCollectorFactory ?? throw new ArgumentNullException(nameof(uiCollectorFactory));
            _characterViewFactory = characterViewFactory ??
                                    throw new ArgumentNullException(nameof(characterViewFactory));
            _bearViewFactory = bearViewFactory ?? throw new ArgumentNullException(nameof(bearViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? throw new ArgumentNullException(nameof(upgradeUiFactory));
            _rootGameObject = rootGameObject
                ? rootGameObject
                : throw new ArgumentNullException(nameof(rootGameObject));
            _enemySpawnViewFactory = enemySpawnViewFactory ??
                                     throw new ArgumentNullException(nameof(enemySpawnViewFactory));
            _itemSpawnerViewFactory = itemSpawnerViewFactory ??
                                      throw new ArgumentNullException(nameof(itemSpawnerViewFactory));
            _upgradeCollection = upgradeCollection ??
                                        throw new ArgumentNullException(nameof(upgradeCollection));
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
            _scoreCounterViewFactory = scoreCounterViewFactory ?? throw new ArgumentNullException(nameof(scoreCounterViewFactory));
            _upgradeControllerViewFactory = upgradeControllerViewFactory ??
                                            throw new ArgumentNullException(nameof(upgradeControllerViewFactory));
        }

        public void Load(IScenePayload scenePayload)
        {
            GameModels gameModels = LoadModels(scenePayload);

            _advertisingService.Construct(gameModels.PlayerWallet);

            _levelCompletedService.Register(gameModels.KillEnemyCounter, gameModels.EnemySpawner);

            SavedLevel savedLevel = gameModels.SavedLevel;
            gameModels.SavedLevel.SavedLevelId = scenePayload.SceneId;

            _tutorialService.Construct(gameModels.Tutorial, savedLevel);

            _volumeService.Register(gameModels.Volume);
            _volumeViewFactory.Create(gameModels.Volume, _gameplayHud.VolumeView);

            _saveService.Register(gameModels.EnemySpawner);

            for (int i = 0; i < _gameplayHud.NotAvailabilityUpgradeUis.Count; i++)
                _upgradeUiFactory.Create(_upgradeCollection[i], _gameplayHud.NotAvailabilityUpgradeUis[i]);

            _upgradeControllerViewFactory.Create(
                gameModels.UpgradeController,
                gameModels.CharacterHealth,
                gameModels.PlayerWallet,
                _gameplayHud.UpgradeControllerView);

            CharacterView characterView = _characterViewFactory.Create(gameModels.Character);

            IBearView bearView = _bearViewFactory.Create(gameModels.Bear);
            bearView.SetTargetFollow(characterView.CharacterMovementView);

            _gameOverService.Register(gameModels.CharacterHealth);

            EnemySpawnerView enemySpawnView = _rootGameObject.EnemySpawnerView;
            enemySpawnView.SetCharacterView(characterView);
            _enemySpawnViewFactory.Create(
                gameModels.EnemySpawner, gameModels.KillEnemyCounter, enemySpawnView);
            _itemSpawnerViewFactory.Create(_rootGameObject.ItemSpawnerView);

            _killEnemyCounterViewFactory.Create(
                gameModels.KillEnemyCounter, gameModels.EnemySpawner, _gameplayHud.KillEnemyCounterView);

            _backgroundMusicViewFactory.Create(_gameplayHud.BackgroundMusicView);

            _cameraService.Add(characterView);
            _cameraService.Add(_rootGameObject.AllMapPoint);
            _cameraService.SetFollower(FollowableId.Character);
            _cameraViewFactory.Create(_gameplayHud.CinemachineCameraView);

            _uiCollectorFactory.Create();
            _formService.Show(FormId.Hud);

            _scoreCounterViewFactory.Create(
                gameModels.ScoreCounter,
                gameModels.KillEnemyCounter,
                gameModels.Level,
                gameModels.CharacterHealth,
                _gameplayHud.ScoreCounterView);
        }

        protected abstract GameModels LoadModels(IScenePayload scenePayload);
    }
}