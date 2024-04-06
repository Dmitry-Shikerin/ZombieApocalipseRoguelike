using System;
using Sources.Controllers.Characters.Attackers;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Views.Characters
{
    public class CharacterAttackerViewFactory
    {
        private readonly CharacterAttackerPresenterFactory _characterAttackerPresenterFactory;

        public CharacterAttackerViewFactory(CharacterAttackerPresenterFactory characterAttackerPresenterFactory)
        {
            _characterAttackerPresenterFactory = 
                characterAttackerPresenterFactory ??
                throw new ArgumentNullException(nameof(characterAttackerPresenterFactory));
        }

        public ICharacterAttackerView Create(
            CharacterAttacker characterAttacker,
            CharacterAttackerView characterAttackerView)
        {
            CharacterAttackerPresenter characterAttackerPresenter = 
                _characterAttackerPresenterFactory.Create(characterAttacker, characterAttackerView);
            
            characterAttackerView.Construct(characterAttackerPresenter);
            
            return characterAttackerView;
        }
    }
}