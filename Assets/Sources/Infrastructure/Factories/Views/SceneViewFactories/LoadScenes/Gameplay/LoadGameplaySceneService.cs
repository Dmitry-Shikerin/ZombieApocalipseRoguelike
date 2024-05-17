using System;
using System.Collections.Generic;
using Sources.Controllers.Bears.Attacks;
using Sources.Domain.Models.Abilities;
using Sources.Domain.Models.Bears;
using Sources.Domain.Models.Characters;
using Sources.Domain.Models.Characters.Attackers;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Setting;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Models.Upgrades;
using Sources.Domain.Models.Weapons;
using Sources.DomainInterfaces.Models.Payloads;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Cameras;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.InterstitialShowers;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Factories.Views.Spawners;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Services.Providers;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.LevelCompleteds;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Repositories;
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
    public class LoadGameplaySceneService : LoadGameplaySceneServiceBase
    {
        //TODO можно ли сохранять в поле то что мы передаем дальше?
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        private readonly CustomCollection<Upgrader> _upgradeCollection;

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
            InterstitialShowerViewFactory interstitialShowerViewFactory,
            ScoreCounterViewFactory scoreCounterViewFactory) 
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
                interstitialShowerViewFactory,
                scoreCounterViewFactory)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _upgradeCollection = upgradeCollection ?? throw new ArgumentNullException(nameof(upgradeCollection));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            Debug.Log("Load Models");
            _loadService.LoadAll();
            
            Tutorial tutorial = _entityRepository.Get<Tutorial>(ModelId.Tutorial);
            
            Volume volume = _entityRepository.Get<Volume>(ModelId.Volume);

            Level level = _entityRepository.Get<Level>(scenePayload.SceneId);
            
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            
            PlayerWallet playerWallet = _entityRepository.Get<PlayerWallet>(ModelId.PlayerWallet);
            
            Upgrader bearMassAttackUpgrader = _entityRepository.Get<Upgrader>(ModelId.BearMassAttackUpgrader);
            _upgradeCollection.Add(bearMassAttackUpgrader);
            Upgrader bearAttackUpgrader = _entityRepository.Get<Upgrader>(ModelId.BearAttackUpgrader);
            _upgradeCollection.Add(bearAttackUpgrader);
            Upgrader characterHealthUpgrader = _entityRepository.Get<Upgrader>(ModelId.CharacterHealthUpgrader);
            _upgradeCollection.Add(characterHealthUpgrader);
            Upgrader sawLauncherUpgrader = _entityRepository.Get<Upgrader>(ModelId.SawLauncherUpgrader);
            _upgradeCollection.Add(sawLauncherUpgrader);
            Upgrader sawLauncherAbilityUpgrader = _entityRepository.Get<Upgrader>(ModelId.SawLauncherAbilityUpgrader);
            _upgradeCollection.Add(sawLauncherAbilityUpgrader);
            Upgrader miniGunAttackUpgrader = _entityRepository.Get<Upgrader>(ModelId.MiniGunAttackUpgrader);
            _upgradeCollection.Add(miniGunAttackUpgrader);

            KillEnemyCounter killEnemyCounter = _entityRepository.Get<KillEnemyCounter>(ModelId.KillEnemyCounter);
            EnemySpawner enemySpawner = _entityRepository.Get<EnemySpawner>(ModelId.GameplayEnemySpawner);

            ScoreCounter scoreCounter = _entityRepository.Get<ScoreCounter>(ModelId.ScoreCounter);
            
            MiniGun miniGun = new MiniGun(miniGunAttackUpgrader, WeaponConst.AttackCooldown);

            CharacterHealth characterHealth = new CharacterHealth(characterHealthUpgrader);

            Character character = new Character(
                playerWallet,
                characterHealth,
                new CharacterMovement(),
                new CharacterAttacker(miniGun),
                miniGun,
                new SawLauncherAbility(sawLauncherAbilityUpgrader),
                new List<SawLauncher>()
                {
                    new SawLauncher(sawLauncherUpgrader),
                    new SawLauncher(sawLauncherUpgrader),
                    new SawLauncher(sawLauncherUpgrader),
                    new SawLauncher(sawLauncherUpgrader),
                });

            BearAttacker bearAttacker = new BearAttacker(bearAttackUpgrader, bearMassAttackUpgrader);
            Bear bear = new Bear(bearAttacker);


            return new GameModels(
                bearMassAttackUpgrader,
                bearAttackUpgrader,
                characterHealthUpgrader,
                sawLauncherUpgrader,
                sawLauncherAbilityUpgrader,
                miniGunAttackUpgrader,
                miniGun,
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
                tutorial,
                scoreCounter);
        }
    }
}