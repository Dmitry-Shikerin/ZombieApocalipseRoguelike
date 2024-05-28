using Sources.Controllers.Presenters.Players;
using Sources.DomainInterfaces.Models.Players;
using Sources.PresentationsInterfaces.Views.Players;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Players
{
    public class PlayerWalletPresenterFactory
    {
        public PlayerWalletPresenter Create(IPlayerWallet playerWallet, IPlayerWalletView playerWalletView) =>
            new(playerWallet, playerWalletView);
    }
}