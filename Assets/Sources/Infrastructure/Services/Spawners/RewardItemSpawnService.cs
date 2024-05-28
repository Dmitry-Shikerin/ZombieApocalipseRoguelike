using System;
using Sources.InfrastructureInterfaces.Factories.Views.RewardItems;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.RewardItems;
using Sources.PresentationsInterfaces.Views.RewardItems;
using UnityEngine;

namespace Sources.Infrastructure.Services.Spawners
{
    public class RewardItemSpawnService : IRewardItemSpawnService
    {
        private readonly IObjectPool<RewardItemView> _objectPool;
        private readonly IRewardItemViewFactory _viewFactory;

        public RewardItemSpawnService(
            IObjectPool<RewardItemView> objectPool, 
            IRewardItemViewFactory viewFactory)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IRewardItemView Spawn(Vector3 position, int amount = 1)
        {
            IRewardItemView rewardItemView = SpawnFromPool() ?? _viewFactory.Create(position, amount);
            rewardItemView.SetRewardAmount(amount);
            rewardItemView.SetPosition(position);
            rewardItemView.Show();
            
            return rewardItemView;
        }
        
        private RewardItemView SpawnFromPool()
        {
            RewardItemView rewardItemView = _objectPool.Get<RewardItemView>();

            if (rewardItemView == null)
                return null;

            return rewardItemView;
        }
    }
}