using System;
using Sources.DomainInterfaces.Models.Players;
using Sources.PresentationsInterfaces.Views.Players;

namespace Sources.Controllers.Presenters.Players
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

        public override void Enable()
        {
            OnCoinsChanged();
            _playerWallet.CoinsChanged += OnCoinsChanged;
        }

        public override void Disable() =>
            _playerWallet.CoinsChanged -= OnCoinsChanged;

        private void OnCoinsChanged() =>
            _playerWalletView.CoinsUiText.SetText(_playerWallet.Coins.ToString());
    }
}