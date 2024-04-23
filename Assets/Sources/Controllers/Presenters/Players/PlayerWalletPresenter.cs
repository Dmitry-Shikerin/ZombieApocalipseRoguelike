using System;
using Sources.Controllers.Common;
using Sources.DomainInterfaces.Players;
using Sources.PresentationsInterfaces.Views.Players;

namespace Sources.Controllers.Players
{
    public class PlayerWalletPresenter : PresenterBase
    {
        private readonly IPlayerWallet _playerWallet;
        private readonly IPlayerWalletView _playerWalletView;

        public PlayerWalletPresenter(IPlayerWallet playerWallet, IPlayerWalletView playerWalletView)
        {
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            _playerWalletView = playerWalletView ?? throw new ArgumentNullException(nameof(playerWalletView));
        }

        //TODO почему не отрисовывается ТМП
        public override void Enable()
        {
            OnCoinsChanged();
            _playerWallet.CoinsChanged += OnCoinsChanged;
        }

        public override void Disable() =>
            _playerWallet.CoinsChanged -= OnCoinsChanged;

        private void OnCoinsChanged() =>
            _playerWalletView.CoinsTextView.SetText(_playerWallet.Coins.ToString());
    }
}