﻿using System;
using System.Collections.Generic;
using Sources.Controllers.Bears.Attacks;
using Sources.Domain.Abilities;
using Sources.Domain.Bears;
using Sources.Domain.Characters;
using Sources.Domain.Characters.Attackers;
using Sources.Domain.Data.Common;
using Sources.Domain.Data.Ids;
using Sources.Domain.Gameplay;
using Sources.Domain.Models.Forms.Gameplay;
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
using Sources.Infrastructure.Factories.Views.Enemies.Base;
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
using Sources.Presentations.Views.Bears;
using Sources.Presentations.Views.Cameras.Points;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.RootGameObjects;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories
{
    public class GameplaySceneViewFactory
    {
        private readonly GameplayHud _gameplayHud;
        private readonly GameplayFormServiceFactory _gameplayFormServiceFactory;
        private readonly CharacterViewFactory _characterViewFactory;
        private readonly BearViewFactory _bearViewFactory;
        private readonly UpgradeViewFactory _upgradeViewFactory;
        private readonly UpgradeUiFactory _upgradeUiFactory;
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly EnemySpawnViewFactory _enemySpawnViewFactory;
        private readonly ItemSpawnerViewFactory _itemSpawnerViewFactory;
        private readonly IUpgradeConfigCollectionService _upgradeConfigCollectionService;
        private readonly IUpgradeDtoMapper _upgradeDtoMapper;
        private readonly IUpgradeCollectionService _upgradeCollectionService;
        private readonly PlayerWalletProvider _playerWalletProvider;
        private readonly KillEnemyCounterViewFactory _killEnemyCounterViewFactory;
        private readonly BackgroundMusicViewFactory _backgroundMusicViewFactory;
        private readonly IGameOverService _gameOverService;
        private readonly CameraViewFactory _cameraViewFactory;
        private readonly ICameraService _cameraService;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly IVolumeService _volumeService;
        private readonly RootGameObject _rootGameObject;
        private readonly EnemyViewFactory _enemyViewFactory;

        public GameplaySceneViewFactory(
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
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _gameplayFormServiceFactory = gameplayFormServiceFactory ??
                                          throw new ArgumentNullException(nameof(gameplayFormServiceFactory));
            _characterViewFactory = characterViewFactory
                                    ?? throw new ArgumentNullException(nameof(characterViewFactory));
            _bearViewFactory = bearViewFactory ?? throw new ArgumentNullException(nameof(bearViewFactory));
            _upgradeViewFactory = upgradeViewFactory ?? throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? throw new ArgumentNullException(nameof(upgradeUiFactory));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _enemySpawnService = enemySpawnService ?? throw new ArgumentNullException(nameof(enemySpawnService));
            _enemySpawnViewFactory = enemySpawnViewFactory ??
                                     throw new ArgumentNullException(nameof(enemySpawnViewFactory));
            _itemSpawnerViewFactory = itemSpawnerViewFactory ??
                                      throw new ArgumentNullException(nameof(itemSpawnerViewFactory));
            _upgradeConfigCollectionService = upgradeConfigCollectionService ??
                                              throw new ArgumentNullException(nameof(upgradeConfigCollectionService));
            _upgradeDtoMapper = upgradeDtoMapper ?? throw new ArgumentNullException(nameof(upgradeDtoMapper));
            _upgradeCollectionService = upgradeCollectionService ?? throw new ArgumentNullException(nameof(upgradeCollectionService));
            _playerWalletProvider = playerWalletProvider ?? throw new ArgumentNullException(nameof(playerWalletProvider));
            _killEnemyCounterViewFactory = killEnemyCounterViewFactory ?? throw new ArgumentNullException(nameof(killEnemyCounterViewFactory));
            _backgroundMusicViewFactory = backgroundMusicViewFactory ?? throw new ArgumentNullException(nameof(backgroundMusicViewFactory));
            _gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _cameraViewFactory = cameraViewFactory ?? throw new ArgumentNullException(nameof(cameraViewFactory));
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _rootGameObject = rootGameObject ? rootGameObject : throw new ArgumentNullException(nameof(rootGameObject));
        }

        public void Create(IScenePayload scenePayload)
        {
            //TODO покашто вилка тут
            Volume volume = new Volume();

            Level level = new Level(scenePayload.SceneId, false);
            
            PlayerWallet playerWallet;

            Upgrader bearMassAttackUpgrader;
            Upgrader bearAttackUpgrader;
            Upgrader characterHealthUpgrader;
            Upgrader sawLauncherUpgrader;
            Upgrader sawLauncherAbilityUpgrader;
            Upgrader miniGunAttackUpgrader;

            if (scenePayload.CanLoad == false)
            {
                playerWallet = CreatePlayerWallet();
                
                bearMassAttackUpgrader = CreateUpgrader(ModelId.BearMassAttackUpgrader);
                bearAttackUpgrader = CreateUpgrader(ModelId.BearAttackUpgrader);
                characterHealthUpgrader = CreateUpgrader(ModelId.CharacterHealthUpgrader);
                sawLauncherUpgrader = CreateUpgrader(ModelId.SawLauncherUpgrader);
                sawLauncherAbilityUpgrader = CreateUpgrader(ModelId.SawLauncherAbilityUpgrader);
                miniGunAttackUpgrader = CreateUpgrader(ModelId.MiniGunAttackUpgrader);
            }
            else
            {
                _loadService.LoadAll();
                
                playerWallet = (PlayerWallet)_entityRepository.Get(ModelId.PlayerWallet);
                
                bearMassAttackUpgrader = (Upgrader)_entityRepository.Get(ModelId.BearMassAttackUpgrader);
                bearAttackUpgrader = (Upgrader)_entityRepository.Get(ModelId.BearAttackUpgrader);
                characterHealthUpgrader = (Upgrader)_entityRepository.Get(ModelId.CharacterHealthUpgrader);
                sawLauncherUpgrader = (Upgrader)_entityRepository.Get(ModelId.SawLauncherUpgrader);
                sawLauncherAbilityUpgrader = (Upgrader)_entityRepository.Get(ModelId.SawLauncherAbilityUpgrader);
                miniGunAttackUpgrader = (Upgrader)_entityRepository.Get(ModelId.MiniGunAttackUpgrader);
            }
            
            //Volume
            _volumeService.Register(volume);
            _volumeViewFactory.Create(volume, _gameplayHud.VolumeView);
            
            //FormService
            _gameplayFormServiceFactory.Create().Show<GameplayHudForm>();

            //TODO возможно сделать древовидную структуру моделей и дто и мапить их
            //Upgrades
            IReadOnlyList<Upgrader> upgraders = _upgradeCollectionService.Get();

            for (int i = 0; i < _gameplayHud.NotAvailabilityUpgradeUis.Count; i++)
            {
                var view = _gameplayHud.NotAvailabilityUpgradeUis[i];
                var upgrader = upgraders[i];

                _upgradeUiFactory.Create(upgrader, view);
            }

            //TODO можно ли это все дело сделать на компонентах?
            //Character
            // PlayerWallet playerWallet = new PlayerWallet(10, ModelId.PlayerWallet);
            _playerWalletProvider.PlayerWallet = playerWallet;
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
            CharacterView characterView = Object.FindObjectOfType<CharacterView>();
            _characterViewFactory.Create(character, characterView);

            //Bear
            BearAttacker bearAttacker = new BearAttacker(
                bearAttackUpgrader,
                bearMassAttackUpgrader);
            Bear bear = new Bear(bearAttacker);
            BearView bearView = Object.FindObjectOfType<BearView>();
            _bearViewFactory.Create(bear, bearView);
            bearView.SetTargetFollow(characterView.CharacterMovementView);

            //GameOverService
            _gameOverService.Register(characterHealth);;

            //Spawners
            KillEnemyCounter killEnemyCounter = new KillEnemyCounter();
            EnemySpawner enemySpawner = new EnemySpawner();
            _enemySpawnViewFactory.Create(enemySpawner, killEnemyCounter, _rootGameObject.EnemySpawnerView);
            _itemSpawnerViewFactory.Create(new ItemSpawner(), _rootGameObject.ItemSpawnerView);
            
            //Gameplay
            _killEnemyCounterViewFactory.Create(killEnemyCounter, enemySpawner, _gameplayHud.KillEnemyCounterView);
            
            //BackgroundMusic
            _backgroundMusicViewFactory.Create(_gameplayHud.BackgroundMusicView);

            //Camera
            _cameraService.Add<CharacterView>(characterView);
            _cameraService.Add<AllMapPoint>(_rootGameObject.AllMapPoint);
            
            _cameraService.SetFollower<AllMapPoint>();
            
            _cameraViewFactory.Create(_gameplayHud.CinemachineCameraView);
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