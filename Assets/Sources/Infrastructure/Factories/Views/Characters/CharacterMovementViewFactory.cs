using System;
using Sources.Controllers.Characters.Movements;
using Sources.Domain.Characters;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Views.Characters
{
    public class CharacterMovementViewFactory
    {
        private readonly CharacterMovementPresenterFactory _characterMovementPresenterFactory;

        public CharacterMovementViewFactory(CharacterMovementPresenterFactory characterMovementPresenterFactory)
        {
            _characterMovementPresenterFactory = 
                characterMovementPresenterFactory 
                ?? throw new ArgumentNullException(nameof(characterMovementPresenterFactory));
        }

        public ICharacterMovementView Create(
            CharacterMovement characterMovement,
            CharacterMovementView characterMovementView, CharacterAnimationView characterAnimationView)
        {
            CharacterMovementPresenter characterMovementPresenter = 
                _characterMovementPresenterFactory.Create(
                    characterMovement, characterMovementView, characterAnimationView);
            
            characterMovementView.Construct(characterMovementPresenter);
            
            return characterMovementView;
        }
    }
}