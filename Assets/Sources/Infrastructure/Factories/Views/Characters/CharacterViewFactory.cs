using System;
using Sources.Domain.Characters;
using Sources.Infrastructure.Factories.Views.Abilities;
using Sources.Infrastructure.Factories.Views.Weapons;
using Sources.Presentations.Views.Abilities;
using Sources.Presentations.Views.Characters;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Characters
{
    public class CharacterViewFactory
    {
        private readonly CharacterMovementViewFactory _characterMovementViewFactory;
        private readonly CharacterAttackerViewFactory _characterAttackerViewFactory;
        private readonly MiniGunViewFactory _miniGunViewFactory;
        private readonly SawLauncherAbilityViewFactory _sawLauncherAbilityViewFactory;
        private readonly SawLauncherViewFactory _sawLauncherViewFactory;
        
        public CharacterViewFactory(
            CharacterMovementViewFactory characterMovementViewFactory,
            CharacterAttackerViewFactory characterAttackerViewFactory,
            MiniGunViewFactory miniGunViewFactory,
            SawLauncherAbilityViewFactory sawLauncherAbilityViewFactory,
            SawLauncherViewFactory sawLauncherViewFactory)
        {
            _characterMovementViewFactory = characterMovementViewFactory 
                                            ?? throw new ArgumentNullException(nameof(characterMovementViewFactory));
            _characterAttackerViewFactory = characterAttackerViewFactory ??
                                            throw new ArgumentNullException(nameof(characterAttackerViewFactory));
            _miniGunViewFactory = miniGunViewFactory ?? throw new ArgumentNullException(nameof(miniGunViewFactory));
            _sawLauncherAbilityViewFactory = sawLauncherAbilityViewFactory ??
                                             throw new ArgumentNullException(nameof(sawLauncherAbilityViewFactory));
            _sawLauncherViewFactory = sawLauncherViewFactory ?? 
                                      throw new ArgumentNullException(nameof(sawLauncherViewFactory));
        }

        public CharacterView Create(Character character, CharacterView characterView)
        {
            _characterMovementViewFactory.Create(
                character.CharacterMovement, 
                characterView.CharacterMovementView, 
                characterView.CharacterAnimationView);
            _characterAttackerViewFactory.Create(character.CharacterAttacker, characterView.CharacterAttackerView);
            _miniGunViewFactory.Create(character.MiniGun, characterView.MiniGunView);

            SawLauncherAbilityView sawLauncherAbilityView = Object.FindObjectOfType<SawLauncherAbilityView>();
            sawLauncherAbilityView.SetTargetFollow(characterView.transform);

            for (int i = 0; i < sawLauncherAbilityView.SawLauncherViews.Count; i++)
                _sawLauncherViewFactory.Create(character.SawLaunchers[i], sawLauncherAbilityView.SawLauncherViews[i]);

            _sawLauncherAbilityViewFactory.Create(character.SawLauncherAbility, sawLauncherAbilityView);

            return characterView;
        }
    }
}