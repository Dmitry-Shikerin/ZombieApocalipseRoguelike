using System;
using Sources.Controllers.Characters.Attackers;
using Sources.Domain.Characters;
using Sources.Infrastructure.Factories.Views.Weapons;
using Sources.Presentations.Views.Characters;

namespace Sources.Infrastructure.Factories.Views.Characters
{
    public class CharacterViewFactory
    {
        private readonly CharacterMovementViewFactory _characterMovementViewFactory;
        private readonly CharacterAttackerViewFactory _characterAttackerViewFactory;
        private readonly MiniGunViewFactory _miniGunViewFactory;

        public CharacterViewFactory(
            CharacterMovementViewFactory characterMovementViewFactory,
            CharacterAttackerViewFactory characterAttackerViewFactory,
            MiniGunViewFactory miniGunViewFactory)
        {
            _characterMovementViewFactory = characterMovementViewFactory 
                                            ?? throw new ArgumentNullException(nameof(characterMovementViewFactory));
            _characterAttackerViewFactory = characterAttackerViewFactory ??
                                            throw new ArgumentNullException(nameof(characterAttackerViewFactory));
            _miniGunViewFactory = miniGunViewFactory ?? throw new ArgumentNullException(nameof(miniGunViewFactory));
        }

        public CharacterView Create(Character character, CharacterView characterView)
        {
            _characterMovementViewFactory.Create(
                character.CharacterMovement, 
                characterView.CharacterMovementView, 
                characterView.CharacterAnimationView);

            _characterAttackerViewFactory.Create(character.CharacterAttacker, characterView.CharacterAttackerView);
            
            _miniGunViewFactory.Create(character.MiniGun, characterView.MiniGunView);
            
            return characterView;
        }
    }
}