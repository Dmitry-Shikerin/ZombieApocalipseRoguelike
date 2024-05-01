using System;
using System.Collections.Generic;
using Sources.Controllers.Bears.Attacks;
using Sources.Domain.Models.Abilities;
using Sources.Domain.Models.Bears;
using Sources.Domain.Models.Characters;
using Sources.Domain.Models.Characters.Attackers;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Setting;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Models.Upgrades;
using Sources.Domain.Models.Weapons;
using Sources.DomainInterfaces.Payloads;
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
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Saves;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Tutorials;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.RootGameObjects;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes.Gameplay
{
    public class LoadGameplaySceneService : LoadGameplaySceneServiceBase
    {
        //TODO можно ли сохранять в поле то что мы передаем дальше?
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        private readonly IUpgradeCollectionService _upgradeCollectionService;

        public LoadGameplaySceneService(
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
            IUpgradeCollectionService upgradeCollectionService, 
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
            IFormService formService) 
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
                upgradeCollectionService, 
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
                formService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _upgradeCollectionService = upgradeCollectionService ?? throw new ArgumentNullException(nameof(upgradeCollectionService));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            Debug.Log("Load Models");
            _loadService.LoadAll();
            
            Tutorial tutorial = _entityRepository.Get(ModelId.Tutorial) as Tutorial;
            
            Volume volume = _entityRepository.Get(ModelId.Volume) as Volume;

            Level level = _entityRepository.Get(scenePayload.SceneId) as Level;
            
            SavedLevel savedLevel = _entityRepository.Get(ModelId.SavedLevel) as SavedLevel;
            
            PlayerWallet playerWallet = _entityRepository.Get(ModelId.PlayerWallet) as PlayerWallet;
            
            Upgrader bearMassAttackUpgrader = _entityRepository.Get(ModelId.BearMassAttackUpgrader) as Upgrader;
            _upgradeCollectionService.AddUpgrader(bearMassAttackUpgrader);
            Upgrader bearAttackUpgrader = _entityRepository.Get(ModelId.BearAttackUpgrader) as Upgrader;
            _upgradeCollectionService.AddUpgrader(bearAttackUpgrader);
            Upgrader characterHealthUpgrader = _entityRepository.Get(ModelId.CharacterHealthUpgrader) as Upgrader;
            _upgradeCollectionService.AddUpgrader(characterHealthUpgrader);
            Upgrader sawLauncherUpgrader = _entityRepository.Get(ModelId.SawLauncherUpgrader) as Upgrader;
            _upgradeCollectionService.AddUpgrader(sawLauncherUpgrader);
            Upgrader sawLauncherAbilityUpgrader = _entityRepository.Get(ModelId.SawLauncherAbilityUpgrader) as Upgrader;
            _upgradeCollectionService.AddUpgrader(sawLauncherAbilityUpgrader);
            Upgrader miniGunAttackUpgrader = _entityRepository.Get(ModelId.MiniGunAttackUpgrader) as Upgrader;
            _upgradeCollectionService.AddUpgrader(miniGunAttackUpgrader);

            KillEnemyCounter killEnemyCounter = _entityRepository.Get(ModelId.KillEnemyCounter) as KillEnemyCounter;
            EnemySpawner enemySpawner = _entityRepository.Get(ModelId.GameplayEnemySpawner) as EnemySpawner;
            
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
    }
}