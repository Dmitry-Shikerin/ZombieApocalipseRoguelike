﻿using System;
using System.Collections.Generic;
using Sources.Controllers.Bears.Attacks;
using Sources.Controllers.Characters.Attackers;
using Sources.Domain.Abilities;
using Sources.Domain.Bears;
using Sources.Domain.Characters;
using Sources.Domain.Characters.Attackers;
using Sources.Domain.Data.Ids;
using Sources.Domain.Enemies;
using Sources.Domain.Players;
using Sources.Domain.Upgrades;
using Sources.Domain.Weapons;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Enemies;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Bears;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.Enemies;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.Upgrades;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories
{
    public class GameplaySceneViewFactory
    {
        private readonly GameplayHud _gameplayHud;
        private readonly GameplayFormServiceFactory _gameplayFormServiceFactory;
        private readonly CharacterViewFactory _characterViewFactory;
        private readonly BearViewFactory _bearViewFactory;
        private readonly EnemyCommonViewFactory _enemyCommonViewFactory;
        private readonly UpgradeViewFactory _upgradeViewFactory;
        private readonly UpgradeUiFactory _upgradeUiFactory;
        private readonly ILoadService _loadService;

        public GameplaySceneViewFactory(
            GameplayHud gameplayHud,
            GameplayFormServiceFactory gameplayFormServiceFactory,
            CharacterViewFactory characterViewFactory,
            BearViewFactory bearViewFactory,
            EnemyCommonViewFactory enemyCommonViewFactory,
            UpgradeViewFactory upgradeViewFactory,
            UpgradeUiFactory upgradeUiFactory,
            ILoadService loadService)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _gameplayFormServiceFactory = gameplayFormServiceFactory ?? 
                                          throw new ArgumentNullException(nameof(gameplayFormServiceFactory));
            _characterViewFactory = characterViewFactory
                                    ?? throw new ArgumentNullException(nameof(characterViewFactory));
            _bearViewFactory = bearViewFactory ?? throw new ArgumentNullException(nameof(bearViewFactory));
            _enemyCommonViewFactory = enemyCommonViewFactory ?? throw new ArgumentNullException(nameof(enemyCommonViewFactory));
            _upgradeViewFactory = upgradeViewFactory ?? throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? throw new ArgumentNullException(nameof(upgradeUiFactory));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
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
            
            _loadService.Register(sawLauncherAbilityUpgrader);
            CharacterUpgraders characterUpgraders = new CharacterUpgraders(sawLauncherUpgrader);
            
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
            Debug.Log(characterView);
            _characterViewFactory.Create(character, characterView);
            
            //Bear
            BearAttacker bearAttacker = new BearAttacker();
            Bear bear = new Bear(bearAttacker);
            BearView bearView = Object.FindObjectOfType<BearView>();
            _bearViewFactory.Create(bear, bearView);
            bearView.SetTargetFollow(characterView.CharacterMovementView);
            
            //Enemy
            EnemyAttacker enemyAttacker = new EnemyAttacker(3);
            EnemyHealth enemyHealth = new EnemyHealth(100);
            Enemy enemy = new Enemy(enemyHealth, enemyAttacker);
            EnemyView enemyView = Object.FindObjectOfType<EnemyView>();
            _enemyCommonViewFactory.Create(enemy, enemyView);
            enemyView.SetTargetFollow(characterView.CharacterMovementView);
            enemyView.SetCharacterHealth(characterView.CharacterHealthView);
            
            //CinemachineService
            _gameplayHud.CinemachineCameraService.Follow(characterView.transform);
        }
    }
}