using System;
using System.Collections.Generic;
using Sources.Controllers.Bears.Attacks;
using Sources.Domain.Models.Abilities;
using Sources.Domain.Models.Bears;
using Sources.Domain.Models.Characters;
using Sources.Domain.Models.Characters.Attackers;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Setting;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Models.Upgrades;
using Sources.Domain.Models.Weapons;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Forms;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
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
using Sources.Infrastructure.Services.Upgrades;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.Interstitials;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.RootGameObjects;
using Sources.Utils.CustomCollections;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.Gameplay
{
    public class CreateGameplaySceneService : LoadGameplaySceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        private readonly IUpgradeDtoMapper _upgradeDtoMapper;
        private readonly CustomCollection<Upgrader> _upgradeCollection;
        private readonly IEnemySpawnerDtoMapper _enemySpawnerDtoMapper;

        public CreateGameplaySceneService(
            GameplayHud gameplayHud,
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
            IEnemySpawnerDtoMapper enemySpawnerDtoMapper,
            IAdvertisingService advertisingService,
            IFormService formService,
            IInterstitialShowerService interstitialShowerService)
            : base(
                gameplayHud,
                uiCollectorFactory,
                characterViewFactory,
                bearViewFactory,
                upgradeViewFactory,
                upgradeUiFactory,
                loadService,
                entityRepository,
                enemySpawnService,
                rootGameObject,
                enemySpawnViewFactory,
                itemSpawnerViewFactory,
                upgradeConfigCollectionService,
                upgradeDtoMapper,
                upgradeCollection,
                playerWalletProvider,
                killEnemyCounterViewFactory,
                backgroundMusicViewFactory,
                gameOverService,
                cameraViewFactory,
                cameraService,
                volumeViewFactory,
                volumeService,
                saveService,
                levelCompletedService,
                tutorialService,
                advertisingService,
                formService,
                interstitialShowerService)
        {
            _loadService = loadService;
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _upgradeDtoMapper = upgradeDtoMapper ?? throw new ArgumentNullException(nameof(upgradeDtoMapper));
            _upgradeCollection = upgradeCollection ?? throw new ArgumentNullException(nameof(upgradeCollection));
            _enemySpawnerDtoMapper =
                enemySpawnerDtoMapper ?? throw new ArgumentNullException(nameof(enemySpawnerDtoMapper));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            //TODO потом нужно сделать загрузку туториала
            Tutorial tutorial = CreateTutorial();

            Volume volume = CreateVolume();

            Level level = CreateLevel(scenePayload.SceneId);

            SavedLevel savedLevel = new SavedLevel(ModelId.SavedLevel, false, scenePayload.SceneId);
            _entityRepository.Add(savedLevel);

            PlayerWallet playerWallet = new PlayerWallet(0, ModelId.PlayerWallet);
            _entityRepository.Add(playerWallet);

            Upgrader bearMassAttackUpgrader = CreateUpgrader(ModelId.BearMassAttackUpgrader);
            Upgrader bearAttackUpgrader = CreateUpgrader(ModelId.BearAttackUpgrader);
            Upgrader characterHealthUpgrader = CreateUpgrader(ModelId.CharacterHealthUpgrader);
            Upgrader sawLauncherUpgrader = CreateUpgrader(ModelId.SawLauncherUpgrader);
            Upgrader sawLauncherAbilityUpgrader = CreateUpgrader(ModelId.SawLauncherAbilityUpgrader);
            Upgrader miniGunAttackUpgrader = CreateUpgrader(ModelId.MiniGunAttackUpgrader);

            KillEnemyCounter killEnemyCounter = new KillEnemyCounter(ModelId.KillEnemyCounter, 0);
            _entityRepository.Add(killEnemyCounter);

            EnemySpawner enemySpawner = CreateEnemySpawner(scenePayload.SceneId);

            MiniGun minigun = new MiniGun(miniGunAttackUpgrader, 0.1f);
            CharacterHealth characterHealth = new CharacterHealth(characterHealthUpgrader);
            Character character = new Character(
                playerWallet,
                characterHealth,
                new CharacterMovement(),
                new CharacterAttacker(minigun),
                minigun,
                new SawLauncherAbility(sawLauncherAbilityUpgrader),
                new List<SawLauncher>()
                {
                    new SawLauncher(sawLauncherUpgrader),
                    new SawLauncher(sawLauncherUpgrader),
                    new SawLauncher(sawLauncherUpgrader),
                    new SawLauncher(sawLauncherUpgrader),
                });

            BearAttacker bearAttacker = new BearAttacker(
                bearAttackUpgrader,
                bearMassAttackUpgrader);
            Bear bear = new Bear(bearAttacker);

            Debug.Log("CreateModels");
            return new GameModels(
                bearMassAttackUpgrader,
                bearAttackUpgrader,
                characterHealthUpgrader,
                sawLauncherUpgrader,
                sawLauncherAbilityUpgrader,
                miniGunAttackUpgrader,
                minigun,
                characterHealth,
                playerWallet,
                volume,
                level,
                character,
                bearAttacker,
                bear,
                killEnemyCounter,
                enemySpawner,
                savedLevel,
                tutorial);
        }

        private Upgrader CreateUpgrader(string id)
        {
            UpgradeDto upgradeDto = _upgradeDtoMapper.MapIdToDto(id);
            Upgrader upgrader = _upgradeDtoMapper.MapDtoToModel(upgradeDto);
            _entityRepository.Add(upgrader);
            _upgradeCollection.Add(upgrader);

            return upgrader;
        }

        private EnemySpawner CreateEnemySpawner(string sceneId)
        {
            EnemySpawnerDto enemySpawnerDto = _enemySpawnerDtoMapper.MapIdToDto(sceneId);
            EnemySpawner enemySpawner = _enemySpawnerDtoMapper.MapDtoToModel(enemySpawnerDto);
            _entityRepository.Add(enemySpawner);

            return enemySpawner;
        }

        private Tutorial CreateTutorial()
        {
            if (_loadService.HasKey(ModelId.Tutorial))
                return _loadService.Load<Tutorial>(ModelId.Tutorial);

            Tutorial tutorial = new Tutorial();
            _entityRepository.Add(tutorial);

            return tutorial;
        }

        private Volume CreateVolume()
        {
            if (_loadService.HasKey(ModelId.Volume))
                return _loadService.Load<Volume>(ModelId.Volume);

            Volume volume = new Volume();
            _entityRepository.Add(volume);

            return volume;
        }

        private Level CreateLevel(string sceneId)
        {
            if (_loadService.HasKey(sceneId))
                return _loadService.Load<Level>(sceneId);
            
            Level level = new Level(sceneId, false);
            _entityRepository.Add(level);

            return level;
        }
    }
}