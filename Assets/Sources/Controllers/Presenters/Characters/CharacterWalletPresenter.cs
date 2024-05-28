using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Players;
using Sources.PresentationsInterfaces.Views.RewardItems;

namespace Sources.Controllers.Presenters.Characters
{
    public class CharacterWalletPresenter : PresenterBase
    {
        private readonly PlayerWallet _playerWallet;

        public CharacterWalletPresenter(PlayerWallet playerWallet)
        {
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
        }
        
        public void AddRewardItem(IRewardItemView rewardItemView)
        {
            _playerWallet.AddCoins(rewardItemView.RewardAmount);
            rewardItemView.Destroy();
        }
    }
}