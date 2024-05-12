using System;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.InfrastructureInterfaces.Services.ObjectPools;
using Sources.PresentationsInterfaces.Views.RewardItems;

namespace Sources.Presentations.Views.RewardItems
{
    public class RewardItemView : View, IRewardItemView
    {
        private readonly IPoolableObjectDestroyerService _poolableObjectDestroyerService = 
            new PoolableObjectDestroyerService();

        public int RewardAmount { get; private set; }


        public override void Destroy() =>
            _poolableObjectDestroyerService.Destroy(this);

        public void SetRewardAmount(int rewardAmount)
        {
            if(rewardAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(rewardAmount));
            
            RewardAmount = rewardAmount;
        }
    }
}