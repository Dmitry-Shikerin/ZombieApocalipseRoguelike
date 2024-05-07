﻿using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Players;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.RewardItems;

namespace Sources.Controllers.Presenters.Characters
{
    public class CharacterWalletPresenter : PresenterBase
    {
        private readonly PlayerWallet _playerWallet;
        private readonly ICharacterWalletView _characterWalletView;

        public CharacterWalletPresenter(PlayerWallet playerWallet, ICharacterWalletView characterWalletView)
        {
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            _characterWalletView = characterWalletView ?? 
                                   throw new ArgumentNullException(nameof(characterWalletView));
        }
        
        public void AddRewardItem(IRewardItemView rewardItemView)
        {
            _playerWallet.AddCoins(rewardItemView.RewardAmount);
            rewardItemView.Destroy();
        }
    }
}