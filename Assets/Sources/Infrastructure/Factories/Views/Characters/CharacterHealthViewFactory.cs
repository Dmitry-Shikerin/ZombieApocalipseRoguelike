using System;
using Sources.Controllers.Characters.Healths;
using Sources.Domain.Models.Characters;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Views.Characters
{
    public class CharacterHealthViewFactory
    {
        private readonly CharacterHealthPresenterFactory _characterHealthPresenterFactory;

        public CharacterHealthViewFactory(CharacterHealthPresenterFactory characterHealthPresenterFactory)
        {
            _characterHealthPresenterFactory = characterHealthPresenterFactory ?? 
                                               throw new ArgumentNullException(nameof(characterHealthPresenterFactory));
        }

        public ICharacterHealthView Create(CharacterHealth characterHealth, CharacterHealthView characterHealthView)
        {
            CharacterHealthPresenter characterHealthPresenter = 
                _characterHealthPresenterFactory.Create(characterHealth, characterHealthView);
            
            characterHealthView.Construct(characterHealthPresenter);
            
            return characterHealthView;
        }
    }
}