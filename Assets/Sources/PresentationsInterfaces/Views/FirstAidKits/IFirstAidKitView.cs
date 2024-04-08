namespace Sources.PresentationsInterfaces.Views.FirstAidKits
{
    public interface IFirstAidKitView
    {
        int HealAmount { get; }
        
        void SetHealAmount(int healAmount);
    }
}