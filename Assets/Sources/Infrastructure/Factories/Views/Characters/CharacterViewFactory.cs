using System;
using Sources.Domain.Characters;
using Sources.Presentations.Views.Characters;

namespace Sources.Infrastructure.Factories.Views.Characters
{
    public class CharacterViewFactory
    {
        private readonly CharacterMovementViewFactory _characterMovementViewFactory;

        public CharacterViewFactory(
            CharacterMovementViewFactory characterMovementViewFactory)
        {
            _characterMovementViewFactory = characterMovementViewFactory 
                                            ?? throw new ArgumentNullException(nameof(characterMovementViewFactory));
        }

        public CharacterView Create(Character character, CharacterView characterView)
        {
            _characterMovementViewFactory.Create(
                character.CharacterMovement, 
                characterView.CharacterMovementView, 
                characterView.CharacterAnimationView);
            
            return characterView;
        }
    }
}