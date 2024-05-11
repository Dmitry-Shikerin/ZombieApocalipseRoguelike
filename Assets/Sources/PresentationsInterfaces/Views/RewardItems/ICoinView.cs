using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.PresentationsInterfaces.Views.RewardItems
{
    public interface ICoinView
    {
        int Amount { get; }
        
        void SetAmount(int amount);
        void SetCharacterWalletView(ICharacterWalletView characterWalletView);
    }
}