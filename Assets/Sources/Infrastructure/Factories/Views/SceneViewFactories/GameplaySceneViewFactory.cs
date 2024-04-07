﻿using System;
using Sources.Controllers.Bears.Attacks;
using Sources.Controllers.Characters.Attackers;
using Sources.Domain.Abilities;
using Sources.Domain.Bears;
using Sources.Domain.Characters;
using Sources.Domain.Enemies;
using Sources.Domain.Upgrades;
using Sources.Domain.Weapons;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.Enemies;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Bears;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.Enemies;
using Sources.Presentations.Views.Forms.Gameplay;
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

        public GameplaySceneViewFactory(
            GameplayHud gameplayHud,
            GameplayFormServiceFactory gameplayFormServiceFactory,
            CharacterViewFactory characterViewFactory,
            BearViewFactory bearViewFactory,
            EnemyCommonViewFactory enemyCommonViewFactory,
            UpgradeViewFactory upgradeViewFactory)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _gameplayFormServiceFactory = gameplayFormServiceFactory ?? 
                                          throw new ArgumentNullException(nameof(gameplayFormServiceFactory));
            _characterViewFactory = characterViewFactory
                                    ?? throw new ArgumentNullException(nameof(characterViewFactory));
            _bearViewFactory = bearViewFactory ?? throw new ArgumentNullException(nameof(bearViewFactory));
            _enemyCommonViewFactory = enemyCommonViewFactory ?? throw new ArgumentNullException(nameof(enemyCommonViewFactory));
            _upgradeViewFactory = upgradeViewFactory ?? throw new ArgumentNullException(nameof(upgradeViewFactory));
        }

        public void Create()
        {
            //FormService
            _gameplayFormServiceFactory.Create().Show<HudFormView>();

            //Upgrades
            Upgrader sawAbilityUpgrader = new Upgrader(2, 3, 0, 2);
            // _upgradeViewFactory.Create(sawAbilityUpgrader, )
            CharacterUpgraders characterUpgraders = new CharacterUpgraders(sawAbilityUpgrader);
            
            //Character
            MiniGun minigun = new MiniGun(2, 0.5f);
            Character character = new Character(
                new CharacterMovement(),
                new CharacterAttacker(minigun),
                minigun,
                new SawLauncherAbility());
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
            EnemyHealth enemyHealth = new EnemyHealth(100);
            Enemy enemy = new Enemy(enemyHealth);
            EnemyView enemyView = Object.FindObjectOfType<EnemyView>();
            _enemyCommonViewFactory.Create(enemy, enemyView);
            enemyView.SetTargetFollow(characterView.CharacterMovementView);
            
            //CinemachineService
            _gameplayHud.CinemachineCameraService.Follow(characterView.transform);
        }
    }
}