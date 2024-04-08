using System;
using Sources.Controllers.Common;
using Sources.Domain.Characters;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Controllers.Characters.Healths
{
    public class CharacterHealthPresenter : PresenterBase
    {
        private readonly CharacterHealth _characterHealth;
        private readonly ICharacterHealthView _characterHealthView;

        public CharacterHealthPresenter(
            CharacterHealth characterHealth, 
            ICharacterHealthView characterHealthView)
        {
            _characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            _characterHealthView = characterHealthView ?? throw new ArgumentNullException(nameof(characterHealthView));
        }

        public void TakeDamage(int damage)
        {
            _characterHealth.TakeDamage(damage);
        }
    }
}