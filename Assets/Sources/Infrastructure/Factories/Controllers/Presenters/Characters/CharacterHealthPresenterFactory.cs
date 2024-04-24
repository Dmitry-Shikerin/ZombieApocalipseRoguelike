using Sources.Controllers.Characters.Healths;
using Sources.Domain.Models.Characters;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Controllers.Characters
{
    public class CharacterHealthPresenterFactory
    {
        public CharacterHealthPresenter Create(
            CharacterHealth characterHealth,
            ICharacterHealthView characterHealthView)
        {
            return new CharacterHealthPresenter(characterHealth, characterHealthView);
        }
    }
}