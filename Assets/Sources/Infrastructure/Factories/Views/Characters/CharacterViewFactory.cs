using System;
using Sources.Controllers.Characters;
using Sources.Domain.Models.Characters;
using Sources.Infrastructure.Factories.Views.Abilities;
using Sources.Infrastructure.Factories.Views.Commons;
using Sources.Infrastructure.Factories.Views.Players;
using Sources.Infrastructure.Factories.Views.Weapons;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Abilities;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.Players;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Characters
{
    public class CharacterViewFactory
    {
        private readonly GameplayHud _gameplayHud;
        private readonly CharacterMovementViewFactory _characterMovementViewFactory;
        private readonly CharacterAttackerViewFactory _characterAttackerViewFactory;
        private readonly MiniGunViewFactory _miniGunViewFactory;
        private readonly SawLauncherAbilityViewFactory _sawLauncherAbilityViewFactory;
        private readonly SawLauncherViewFactory _sawLauncherViewFactory;
        private readonly CharacterHealthViewFactory _characterHealthViewFactory;
        private readonly HealthUiFactory _healthUiFactory;
        private readonly CharacterWalletViewFactory _characterWalletViewFactory;
        private readonly PlayerWalletViewFactory _playerWalletViewFactory;
        private readonly EnemyIndicatorViewFactory _enemyIndicatorViewFactory;

        public CharacterViewFactory(
            GameplayHud gameplayHud,
            CharacterMovementViewFactory characterMovementViewFactory,
            CharacterAttackerViewFactory characterAttackerViewFactory,
            MiniGunViewFactory miniGunViewFactory,
            SawLauncherAbilityViewFactory sawLauncherAbilityViewFactory,
            SawLauncherViewFactory sawLauncherViewFactory,
            CharacterHealthViewFactory characterHealthViewFactory,
            HealthUiFactory healthUiFactory,
            CharacterWalletViewFactory characterWalletViewFactory,
            PlayerWalletViewFactory playerWalletViewFactory,
            EnemyIndicatorViewFactory enemyIndicatorViewFactory)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _characterMovementViewFactory = characterMovementViewFactory 
                                            ?? throw new ArgumentNullException(nameof(characterMovementViewFactory));
            _characterAttackerViewFactory = characterAttackerViewFactory ??
                                            throw new ArgumentNullException(nameof(characterAttackerViewFactory));
            _miniGunViewFactory = miniGunViewFactory ?? throw new ArgumentNullException(nameof(miniGunViewFactory));
            _sawLauncherAbilityViewFactory = sawLauncherAbilityViewFactory ??
                                             throw new ArgumentNullException(nameof(sawLauncherAbilityViewFactory));
            _sawLauncherViewFactory = sawLauncherViewFactory ?? 
                                      throw new ArgumentNullException(nameof(sawLauncherViewFactory));
            _characterHealthViewFactory = characterHealthViewFactory ??
                                          throw new ArgumentNullException(nameof(characterHealthViewFactory));
            _healthUiFactory = healthUiFactory ?? throw new ArgumentNullException(nameof(healthUiFactory));
            _characterWalletViewFactory = characterWalletViewFactory ?? 
                                          throw new ArgumentNullException(nameof(characterWalletViewFactory));
            _playerWalletViewFactory = playerWalletViewFactory ?? 
                                       throw new ArgumentNullException(nameof(playerWalletViewFactory));
            _enemyIndicatorViewFactory = enemyIndicatorViewFactory ??
                                         throw new ArgumentNullException(nameof(enemyIndicatorViewFactory));
        }

        public CharacterView Create(Character character, CharacterView characterView)
        {
            _characterMovementViewFactory.Create(
                character.CharacterMovement, 
                characterView.CharacterMovementView, 
                characterView.CharacterAnimationView);
            _characterAttackerViewFactory.Create(character.CharacterAttacker, characterView.CharacterAttackerView);
            _miniGunViewFactory.Create(character.MiniGun, characterView.MiniGunView);

            _characterHealthViewFactory.Create(character.CharacterHealth, characterView.CharacterHealthView);
            _healthUiFactory.Create(character.CharacterHealth, _gameplayHud.CharacterHealthUi);

            SawLauncherAbilityView sawLauncherAbilityView = Object.FindObjectOfType<SawLauncherAbilityView>();
            sawLauncherAbilityView.SetTargetFollow(characterView.transform);

            for (int i = 0; i < sawLauncherAbilityView.SawLauncherViews.Count; i++)
                _sawLauncherViewFactory.Create(character.SawLaunchers[i], sawLauncherAbilityView.SawLauncherViews[i]);

            _sawLauncherAbilityViewFactory.Create(character.SawLauncherAbility, sawLauncherAbilityView);

            foreach (PlayerWalletView playerWalletView in _gameplayHud.PlayerWalletViews) 
                _playerWalletViewFactory.Create(character.PlayerWallet, playerWalletView);
            
            _characterWalletViewFactory.Create(character.PlayerWallet,characterView.CharacterWalletView);

            _enemyIndicatorViewFactory.Create(characterView.EnemyIndicatorView);

            return characterView;
        }
    }
}