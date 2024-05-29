using Sources.Controllers.Presenters.Characters;
using Sources.Domain.Models.Players;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Characters
{
    public class CharacterWalletPresenterFactory
    {
        public CharacterWalletPresenter Create(PlayerWallet playerWallet)
        {
            return new CharacterWalletPresenter(playerWallet);
        }
    }
}