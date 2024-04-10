using System;
using System.Collections.Generic;
using Sources.Controllers.Bears.Attacks;
using Sources.Domain.Abilities;
using Sources.Domain.Bears;
using Sources.Domain.Characters;
using Sources.Domain.Characters.Attackers;
using Sources.Domain.Data.Ids;
using Sources.Domain.Players;
using Sources.Domain.Spawners;
using Sources.Domain.Upgrades;
using Sources.Domain.Upgrades.Configs;
using Sources.Domain.Weapons;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Enemies;
using Sources.Infrastructure.Factories.Views.Enemies.Base;
using Sources.Infrastructure.Factories.Views.Spawners;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Services.Repositories;
using Sources.Infrastructure.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Bears;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.RootGameObjects;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
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
        private readonly IEntityRepository _entityRepository;
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly EnemySpawnViewFactory _enemySpawnViewFactory;
        private readonly ItemSpawnerViewFactory _itemSpawnerViewFactory;
        private readonly IUpgradeConfigCollectionService _upgradeConfigCollectionService;
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
            IUpgradeConfigCollectionService upgradeConfigCollectionService)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _gameplayFormServiceFactory = gameplayFormServiceFactory ?? 
                                          throw new ArgumentNullException(nameof(gameplayFormServiceFactory));
            _characterViewFactory = characterViewFactory
                                    ?? throw new ArgumentNullException(nameof(characterViewFactory));
            _bearViewFactory = bearViewFactory ?? throw new ArgumentNullException(nameof(bearViewFactory));
            _upgradeViewFactory = upgradeViewFactory ?? throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? throw new ArgumentNullException(nameof(upgradeUiFactory));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _enemySpawnService = enemySpawnService ?? throw new ArgumentNullException(nameof(enemySpawnService));
            _enemySpawnViewFactory = enemySpawnViewFactory ?? 
                                     throw new ArgumentNullException(nameof(enemySpawnViewFactory));
            _itemSpawnerViewFactory = itemSpawnerViewFactory ?? 
                                      throw new ArgumentNullException(nameof(itemSpawnerViewFactory));
            _upgradeConfigCollectionService = upgradeConfigCollectionService ??
                                              throw new ArgumentNullException(nameof(upgradeConfigCollectionService));
            _rootGameObject = rootGameObject ? 
                rootGameObject : throw new ArgumentNullException(nameof(rootGameObject));
        }

        public void Create()
        {
            //FormService
            _gameplayFormServiceFactory.Create().Show<HudFormView>();

            //Upgrades
            PlayerWallet playerWallet = new PlayerWallet(10, ModelId.PlayerWallet);
            
            UpgradeConfig bearMassAttackConfig = 
                _upgradeConfigCollectionService.GetConfig(ModelId.BearMassAttackUpgrader);
            Upgrader bearMassAttackUpgrader = new Upgrader(bearMassAttackConfig);

            UpgradeConfig bearAttackConfig =
                _upgradeConfigCollectionService.GetConfig(ModelId.BearAttackUpgrader);
            Upgrader bearAttackUpgrader = new Upgrader(bearAttackConfig);

            UpgradeConfig characterHealthConfig =
                _upgradeConfigCollectionService.GetConfig(ModelId.CharacterHealthUpgrader);
            Upgrader characterHealthUpgrader = new Upgrader(characterHealthConfig);

            UpgradeConfig miniGunAttackConfig =
                _upgradeConfigCollectionService.GetConfig(ModelId.MiniGunAttackUpgrader);
            Upgrader miniGunAttackUpgrader = new Upgrader(miniGunAttackConfig);

            UpgradeConfig sawLauncherConfig =
                _upgradeConfigCollectionService.GetConfig(ModelId.SawLauncherUpgrader);
            Upgrader sawLauncherUpgrader = new Upgrader(sawLauncherConfig);

            UpgradeConfig sawLauncherAbilityConfig =
                _upgradeConfigCollectionService.GetConfig(ModelId.SawLauncherAbilityUpgrader);
            Upgrader sawLauncherAbilityUpgrader = new Upgrader(sawLauncherAbilityConfig);

            _upgradeViewFactory.Create(sawLauncherUpgrader, playerWallet, _gameplayHud.UpgradeViews[0]);
            _upgradeUiFactory.Create(sawLauncherUpgrader, _gameplayHud.UpgradeUis[0]);
            
            _upgradeViewFactory.Create(sawLauncherAbilityUpgrader, playerWallet, _gameplayHud.UpgradeViews[1]);
            _upgradeUiFactory.Create(sawLauncherAbilityUpgrader, _gameplayHud.UpgradeUis[1]);
            
            _entityRepository.Add(sawLauncherAbilityUpgrader);
            CharacterUpgraders characterUpgraders = new CharacterUpgraders(sawLauncherUpgrader);
            
            //TODO можно ли это все дело сделать на компонентах?
            //Character
            MiniGun minigun = new MiniGun(
                 miniGunAttackUpgrader,
                 0.1f);
            Character character = new Character(
                playerWallet,
                new CharacterHealth(characterHealthUpgrader),
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
                bearAttackUpgrader, bearMassAttackUpgrader);
            Bear bear = new Bear(bearAttacker);
            BearView bearView = Object.FindObjectOfType<BearView>();
            _bearViewFactory.Create(bear, bearView);
            bearView.SetTargetFollow(characterView.CharacterMovementView);
            
            //Enemy
            IEnemyView enemyView = _enemySpawnService.Spawn();
            enemyView.SetTargetFollow(characterView.CharacterMovementView);
            enemyView.SetCharacterHealth(characterView.CharacterHealthView);
            
            //CinemachineService
            _gameplayHud.CinemachineCameraService.Follow(characterView.transform);
            
            //Spawners
            _enemySpawnViewFactory.Create(new EnemySpawner(), _rootGameObject.EnemySpawnerView);
            _itemSpawnerViewFactory.Create(new ItemSpawner(), _rootGameObject.ItemSpawnerView);
        }
    }
}