﻿using Sources.Controllers.Characters;
using Sources.Domain.Players;
using Sources.DomainInterfaces.Players;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Controllers.Characters
{
    public class CharacterWalletPresenterFactory
    {
        public CharacterWalletPresenter Create(PlayerWallet playerWallet, ICharacterWalletView characterWalletView)
        {
            return new CharacterWalletPresenter(playerWallet, characterWalletView); 
        }
    }
}