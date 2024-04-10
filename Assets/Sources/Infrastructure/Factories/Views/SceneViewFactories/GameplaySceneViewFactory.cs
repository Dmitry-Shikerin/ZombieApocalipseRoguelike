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
using Sources.Domain.Weapons;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Enemies;
using Sources.Infrastructure.Factories.Views.Enemies.Base;
using Sources.Infrastructure.Factories.Views.Spawners;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Services.Repositories;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.Spawners;
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
            ItemSpawnerViewFactory itemSpawnerViewFactory)
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
            _rootGameObject = rootGameObject ? 
                rootGameObject : throw new ArgumentNullException(nameof(rootGameObject));
        }

        public void Create()
        {
            //FormService
            _gameplayFormServiceFactory.Create().Show<HudFormView>();

            //Upgrades
            PlayerWallet playerWallet = new PlayerWallet(10, DataModelId.PlayerWallet);
            
            Upgrader sawLauncherUpgrader = new Upgrader(
                2, 3, 0, 2, 
                new List<int>()
                {
                    0,
                    0,
                    0,
                },
                DataModelId.SawLauncherUpgrader);
            Upgrader sawLauncherAbilityUpgrader = new Upgrader(
                0, 3, 0, 0,
                new List<int>()
                {
                    0,
                    0,
                    0,
                },
                DataModelId.SawLauncherAbilityUpgrader);

            _upgradeViewFactory.Create(sawLauncherUpgrader, playerWallet, _gameplayHud.UpgradeViews[0]);
            _upgradeUiFactory.Create(sawLauncherUpgrader, _gameplayHud.UpgradeUis[0]);
            
            _upgradeViewFactory.Create(sawLauncherAbilityUpgrader, playerWallet, _gameplayHud.UpgradeViews[1]);
            _upgradeUiFactory.Create(sawLauncherAbilityUpgrader, _gameplayHud.UpgradeUis[1]);
            
            _entityRepository.Add(sawLauncherAbilityUpgrader);
            CharacterUpgraders characterUpgraders = new CharacterUpgraders(sawLauncherUpgrader);
            
            //TODO можно ли это все дело сделать на компонентах?
            //Character
            MiniGun minigun = new MiniGun(2, 0.1f);
            Character character = new Character(
                playerWallet,
                new CharacterHealth(100),
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
            BearAttacker bearAttacker = new BearAttacker();
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