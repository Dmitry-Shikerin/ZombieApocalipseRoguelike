using System;
using Sources.Controllers.Characters;
using Sources.Controllers.Players;
using Sources.DomainInterfaces.Players;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Infrastructure.Factories.Controllers.Players;
using Sources.Presentations.Views.Players;
using Sources.PresentationsInterfaces.Views.Players;

namespace Sources.Infrastructure.Factories.Views.Players
{
    public class PlayerWalletViewFactory
    {
        private readonly PlayerWalletPresenterFactory _playerWalletPresenterFactory;

        public PlayerWalletViewFactory(PlayerWalletPresenterFactory playerWalletPresenterFactory)
        {
            _playerWalletPresenterFactory = playerWalletPresenterFactory ??
                                            throw new ArgumentNullException(nameof(playerWalletPresenterFactory));
        }

        public IPlayerWalletView Create(IPlayerWallet playerWallet, PlayerWalletView playerWalletView)
        {
            PlayerWalletPresenter playerWalletPresenter =
                _playerWalletPresenterFactory.Create(playerWallet, playerWalletView);
            
            playerWalletView.Construct(playerWalletPresenter);
            
            return playerWalletView;
        }
    }
}