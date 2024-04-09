using Sources.PresentationsInterfaces.Views.RewardItems;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Spawners
{
    public interface IRewardItemSpawnService
    {
        IRewardItemView Spawn(Vector3 position, int amount = 1);
    }
}