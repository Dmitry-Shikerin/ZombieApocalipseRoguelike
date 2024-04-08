using Sources.Controllers.Players;
using Sources.Domain.Players;
using Sources.DomainInterfaces.Players;
using Sources.PresentationsInterfaces.Views.Players;

namespace Sources.Infrastructure.Factories.Controllers.Players
{
    public class PlayerWalletPresenterFactory
    {
        public PlayerWalletPresenter Create(IPlayerWallet playerWallet, IPlayerWalletView playerWalletView)
        {
            return new PlayerWalletPresenter(playerWallet, playerWalletView);
        }
    }
}