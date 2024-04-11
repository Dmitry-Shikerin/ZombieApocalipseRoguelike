using Sources.Domain.Upgrades.Configs;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Upgrades
{
    public interface IUpgradeConfigCollectionService
    {
        UpgradeConfig GetConfig(string id);
    }
}