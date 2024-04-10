using System;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using Sources.PresentationsInterfaces.Views.RewardItems;

namespace Sources.Presentations.Views.RewardItems
{
    public class RewardItemView : View, IRewardItemView
    {
        public int RewardAmount { get; private set; }
        
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
        
        public void SetRewardAmount(int rewardAmount)
        {
            if(rewardAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(rewardAmount));
            
            RewardAmount = rewardAmount;
        }
    }
}