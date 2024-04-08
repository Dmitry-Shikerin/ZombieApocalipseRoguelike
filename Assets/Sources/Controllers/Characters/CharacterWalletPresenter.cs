using System;
using Sources.Controllers.Common;
using Sources.Domain.Players;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Coins;

namespace Sources.Controllers.Characters
{
    public class CharacterWalletPresenter : PresenterBase
    {
        private readonly PlayerWallet _playerWallet;
        private readonly ICharacterWalletView _characterWalletView;

        public CharacterWalletPresenter(PlayerWallet playerWallet, ICharacterWalletView characterWalletView)
        {
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            _characterWalletView = characterWalletView ?? throw new ArgumentNullException(nameof(characterWalletView));
        }
        
        public void AddCoins(int amount) =>
            _playerWallet.AddCoins(amount);
    }
}