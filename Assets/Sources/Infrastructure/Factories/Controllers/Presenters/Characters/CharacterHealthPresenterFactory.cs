using Sources.Controllers.Presenters.Characters.Healths;
using Sources.Domain.Models.Characters;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Characters
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