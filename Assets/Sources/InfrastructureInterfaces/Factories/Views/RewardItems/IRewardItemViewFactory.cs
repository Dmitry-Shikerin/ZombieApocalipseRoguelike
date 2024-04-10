using Sources.PresentationsInterfaces.Views.RewardItems;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Factories.Views.RewardItems
{
    public interface IRewardItemViewFactory
    {
        IRewardItemView Create(Vector3 position, int amount);
    }
}