using Sources.Controllers.Characters;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterWalletView : PresentableView<CharacterWalletPresenter>, ICharacterWalletView
    {
        public Vector3 Position => transform.position;

        public void AddCoins(int coins)
        {
            Presenter.AddCoins(coins);
        }
    }
}