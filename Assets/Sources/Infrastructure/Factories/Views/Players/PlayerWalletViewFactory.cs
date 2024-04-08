using Sources.DomainInterfaces.Players;
using Sources.Presentations.Views.Players;
using Sources.PresentationsInterfaces.Views.Players;

namespace Sources.Infrastructure.Factories.Views.Players
{
    public class PlayerWalletViewFactory
    {
        public IPlayerWalletView Create(IPlayerWallet playerWallet, PlayerWalletView playerWalletView)
        {
            return playerWalletView;
        }
    }
}