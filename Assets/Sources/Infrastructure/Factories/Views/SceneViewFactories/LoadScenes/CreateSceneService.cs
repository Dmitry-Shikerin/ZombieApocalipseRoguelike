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
using UnityEngine;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories.LoadScenes
{
    public class CreateSceneService : LoadSceneServiceBase
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IUpgradeDtoMapper _upgradeDtoMapper;
        private readonly IUpgradeCollectionService _upgradeCollectionService;

        public CreateSceneService(
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
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _upgradeDtoMapper = upgradeDtoMapper ?? throw new ArgumentNullException(nameof(upgradeDtoMapper));
            _upgradeCollectionService = upgradeCollectionService ??
                                        throw new ArgumentNullException(nameof(upgradeCollectionService));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            Debug.Log("CreateModels");
            Volume volume = new Volume();

            Level level = new Level(scenePayload.SceneId, false);

            PlayerWallet playerWallet = CreatePlayerWallet();

            Upgrader bearMassAttackUpgrader = CreateUpgrader(ModelId.BearMassAttackUpgrader);
            Upgrader bearAttackUpgrader = CreateUpgrader(ModelId.BearAttackUpgrader);
            Upgrader characterHealthUpgrader = CreateUpgrader(ModelId.CharacterHealthUpgrader);
            Upgrader sawLauncherUpgrader = CreateUpgrader(ModelId.SawLauncherUpgrader);
            Upgrader sawLauncherAbilityUpgrader = CreateUpgrader(ModelId.SawLauncherAbilityUpgrader);
            Upgrader miniGunAttackUpgrader = CreateUpgrader(ModelId.MiniGunAttackUpgrader);

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

            KillEnemyCounter killEnemyCounter = new KillEnemyCounter(ModelId.KillEnemyCounter, 0);
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

        private Upgrader CreateUpgrader(string id)
        {
            UpgradeDto upgradeDto = _upgradeDtoMapper.MapIdToDto(id);
            Upgrader upgrader = _upgradeDtoMapper.MapDtoToModel(upgradeDto);
            _entityRepository.Add(upgrader);
            _upgradeCollectionService.AddUpgrader(upgrader);

            return upgrader;
        }

        private PlayerWallet CreatePlayerWallet()
        {
            PlayerWallet playerWallet = new PlayerWallet(0, ModelId.PlayerWallet);
            _entityRepository.Add(playerWallet);

            return playerWallet;
        }
    }
}