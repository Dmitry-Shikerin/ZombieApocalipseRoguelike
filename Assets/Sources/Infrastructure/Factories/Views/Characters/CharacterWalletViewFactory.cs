using System;
using Sources.Controllers.Characters;
using Sources.Domain.Models.Players;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Factories.Views.Characters
{
    public class CharacterWalletViewFactory
    {
        private readonly CharacterWalletPresenterFactory _characterWalletPresenterFactory;

        public CharacterWalletViewFactory(CharacterWalletPresenterFactory characterWalletPresenterFactory)
        {
            _characterWalletPresenterFactory = characterWalletPresenterFactory ??
                                               throw new ArgumentNullException(nameof(characterWalletPresenterFactory));
        }

        public ICharacterWalletView Create(PlayerWallet playerWallet, CharacterWalletView characterWalletView)
        {
            CharacterWalletPresenter characterWalletPresenter = 
                _characterWalletPresenterFactory.Create(playerWallet, characterWalletView);
            
            characterWalletView.Construct(characterWalletPresenter);
            
            return characterWalletView;
        }
    }
}