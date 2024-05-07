using Sources.Controllers.Presenters.Characters;
using Sources.Domain.Models.Players;
using Sources.DomainInterfaces.Players;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Controllers.Characters
{
    public class CharacterWalletPresenterFactory
    {
        public CharacterWalletPresenter Create(PlayerWallet playerWallet, ICharacterWalletView characterWalletView)
        {
            return new CharacterWalletPresenter(playerWallet, characterWalletView); 
        }
    }
}