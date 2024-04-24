using System;
using System.Collections.Generic;
using Sources.Controllers.Bears.Attacks;
using Sources.Domain.Abilities;
using Sources.Domain.Bears;
using Sources.Domain.Characters;
using Sources.Domain.Characters.Attackers;
using Sources.Domain.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Setting;
using Sources.Domain.Players;
using Sources.Domain.Setting;
using Sources.Domain.Spawners;
using Sources.Domain.Upgrades;
using Sources.Domain.Weapons;
using Sources.DomainInterfaces.Payloads;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Cameras;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Gameplay;
using Sources.Infrastructure.Factories.Views.Musics;
using Sources.Infrastructure.Factories.Views.Settings;
using Sources.Infrastructure.Factories.Views.Spawners;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Services.Providers;
using Sources.Infrastructure.Services.Repositories;
using Sources.Infrastructure.Services.Upgrades;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.InfrastructureInterfaces.Services.GameOvers;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.RootGameObjects;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes
{
    public class LoadSceneService : LoadSceneServiceBase
    {
        //TODO можно ли сохранять в поле то что мы передаем дальше?
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;

        public LoadSceneService(
            GameplayHud gameplayHud, 
            GameplayFormServiceFactory gameplayFormServiceFactory, 
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
            IVolumeService volumeService) 
            : base(
                gameplayHud, 
                gameplayFormServiceFactory, 
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
                volumeService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            _loadService.LoadAll();
            
            Volume volume = _entityRepository.Get(ModelId.Volume) as Volume;

            Level level = _entityRepository.Get(scenePayload.SceneId) as Level;
            
            PlayerWallet playerWallet = _entityRepository.Get(ModelId.PlayerWallet) as PlayerWallet;
            
            Upgrader bearMassAttackUpgrader = _entityRepository.Get(ModelId.BearMassAttackUpgrader) as Upgrader;
            Upgrader bearAttackUpgrader = _entityRepository.Get(ModelId.BearAttackUpgrader) as Upgrader;
            Upgrader characterHealthUpgrader = _entityRepository.Get(ModelId.CharacterHealthUpgrader) as Upgrader;
            Upgrader sawLauncherUpgrader = _entityRepository.Get(ModelId.SawLauncherUpgrader) as Upgrader;
            Upgrader sawLauncherAbilityUpgrader = _entityRepository.Get(ModelId.SawLauncherAbilityUpgrader) as Upgrader;
            Upgrader miniGunAttackUpgrader = _entityRepository.Get(ModelId.MiniGunAttackUpgrader) as Upgrader;

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

            KillEnemyCounter killEnemyCounter = new KillEnemyCounter();
            EnemySpawner enemySpawner = new EnemySpawner();
            
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
                enemySpawner);
        }
    }
}