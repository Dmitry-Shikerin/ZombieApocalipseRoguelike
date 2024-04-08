using System;
using Sources.PresentationsInterfaces.Views.FirstAidKits;

namespace Sources.Presentations.Views.FirstAidKits
{
    public class FirstAidKitView : View, IFirstAidKitView
    {
        public int HealAmount { get; private set; }
        
        public void SetHealAmount(int healAmount)
        {
            if(healAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(healAmount));
            
            HealAmount = healAmount;
        }
    }
}