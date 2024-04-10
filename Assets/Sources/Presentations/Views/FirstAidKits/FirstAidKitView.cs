using System;
using Sources.PresentationsInterfaces.Views.FirstAidKits;
using Sources.PresentationsInterfaces.Views.ObjectPools;

namespace Sources.Presentations.Views.FirstAidKits
{
    public class FirstAidKitView : View, IFirstAidKitView
    {
        public int HealAmount { get; private set; }
        
        public override void Destroy()
        {
            if (TryGetComponent(out PoolableObject poolableObject) == false)
            {
                Destroy(gameObject);
                
                return;
            }
            
            poolableObject.ReturnToPool();
            Hide();
        }
        
        public void SetHealAmount(int healAmount)
        {
            if(healAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(healAmount));
            
            HealAmount = healAmount;
        }
    }
}