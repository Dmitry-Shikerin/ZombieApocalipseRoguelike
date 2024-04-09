namespace Sources.PresentationsInterfaces.Views.FirstAidKits
{
    public interface IFirstAidKitView : IView
    {
        int HealAmount { get; }
        
        void SetHealAmount(int healAmount);
    }
}