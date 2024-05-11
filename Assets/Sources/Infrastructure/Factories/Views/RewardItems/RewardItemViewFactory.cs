using System;
using Sources.Domain.Models.Constants;
using Sources.InfrastructureInterfaces.Factories.Views.RewardItems;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.Presentations.Views.RewardItems;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using Sources.PresentationsInterfaces.Views.RewardItems;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.RewardItems
{
    public class RewardItemViewFactory : IRewardItemViewFactory
    {
        private readonly IObjectPool<RewardItemView> _objectPool;

        public RewardItemViewFactory(IObjectPool<RewardItemView> objectPool)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
        }

        public IRewardItemView Create(Vector3 position, int amount)
        {
            RewardItemView rewardItemView = CreateView();
            
            return rewardItemView;
        }

        private RewardItemView CreateView()
        {
            RewardItemView rewardItemView =
                Object.Instantiate(Resources.Load<RewardItemView>(PrefabPath.RewardItem));

            rewardItemView
                .AddComponent<PoolableObject>()
                .SetPool(_objectPool);

            return rewardItemView;
        }
    }
}