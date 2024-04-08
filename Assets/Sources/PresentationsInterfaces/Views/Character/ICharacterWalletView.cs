using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Character
{
    public interface ICharacterWalletView
    {
        Vector3 Position { get; }
        
        void AddCoins(int coins);
    }
}